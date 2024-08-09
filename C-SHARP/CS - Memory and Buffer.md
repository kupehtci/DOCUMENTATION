
# Memory\<T>\ and Span\<T>\ usage guidelines

- Article
- 04/19/2023
- 14 contributors

## In this article

1. [Owners, consumers, and lifetime management](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#owners-consumers-and-lifetime-management)
2. [Memory\<T\> and the owner/consumer model](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#memoryt-and-the-ownerconsumer-model)
3. [Usage guidelines](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#usage-guidelines)
4. [See also](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#see-also)

.NET includes a number of types that represent an arbitrary contiguous region of memory. [Span\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) and [ReadOnlySpan\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1) are lightweight memory buffers that wrap references to managed or unmanaged memory. Because these types can only be stored on the stack, they're unsuitable for scenarios such as asynchronous method calls. To address this problem, .NET 2.1 added some additional types, including Memory\<T\>, ReadOnlyMemory\<T\>, IMemoryOwner|\<T\>, and MemoryPool\<T\>. Like Span\<T\>, Memory\<T\> and its related types can be backed by both managed and unmanaged memory. Unlike Span\<T\>, Memory\<T\>can be stored on the managed heap.

Both Span\<T\> and Memory\<T\>are wrappers over buffers of structured data that can be used in pipelines. That is, they're designed so that some or all of the data can be efficiently passed to components in the pipeline, which can process them and optionally modify the buffer. Because Memory\<T\>and its related types can be accessed by multiple components or by multiple threads, it's important to follow some standard usage guidelines to produce robust code.

[Learn.microsoft.com](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#owners-consumers-and-lifetime-management)

## Owners, consumers, and lifetime management

Buffers can be passed around between APIs and can sometimes be accessed from multiple threads, so be aware of how a buffer's lifetime is managed. There are three core concepts:

- **Ownership**. The owner of a buffer instance is responsible for lifetime management, including destroying the buffer when it's no longer in use. All buffers have a single owner. Generally the owner is the component that created the buffer or that received the buffer from a factory. Ownership can also be transferred; **Component-A** can relinquish control of the buffer to **Component-B**, at which point **Component-A** may no longer use the buffer, and **Component-B** becomes responsible for destroying the buffer when it's no longer in use.
    
- **Consumption**. The consumer of a buffer instance is allowed to use the buffer instance by reading from it and possibly writing to it. Buffers can have one consumer at a time unless some external synchronization mechanism is provided. The active consumer of a buffer isn't necessarily the buffer's owner.
    
- **Lease**. The lease is the length of time that a particular component is allowed to be the consumer of the buffer.
    

The following pseudo-code example illustrates these three concepts. `Buffer` in the pseudo-code represents a Memory\<T\> or Span\<T\> buffer of type [Char](https://learn.microsoft.com/en-us/dotnet/api/system.char). The `Main` method instantiates the buffer, calls the `WriteInt32ToBuffer` method to write the string representation of an integer to the buffer, and then calls the `DisplayBufferToConsole` method to display the value of the buffer.

C#Copy

```
using System;

class Program
{
    // Write 'value' as a human-readable string to the output buffer.
    void WriteInt32ToBuffer(int value, Buffer buffer);

    // Display the contents of the buffer to the console.
    void DisplayBufferToConsole(Buffer buffer);

    // Application code
    static void Main()
    {
        var buffer = CreateBuffer();
        try
        {
            int value = Int32.Parse(Console.ReadLine());
            WriteInt32ToBuffer(value, buffer);
            DisplayBufferToConsole(buffer);
        }
        finally
        {
            buffer.Destroy();
        }
    }
}
```

The `Main` method creates the buffer and so is its owner. Therefore, `Main` is responsible for destroying the buffer when it's no longer in use. The pseudo-code illustrates this by calling a `Destroy` method on the buffer. (Neither [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) nor [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) actually has a `Destroy` method. You'll see actual code examples later in this article.)

The buffer has two consumers, `WriteInt32ToBuffer` and `DisplayBufferToConsole`. There is only one consumer at a time (first `WriteInt32ToBuffer`, then `DisplayBufferToConsole`), and neither of the consumers owns the buffer. Note also that "consumer" in this context doesn't imply a read-only view of the buffer; consumers can modify the buffer's contents, as `WriteInt32ToBuffer` does, if given a read/write view of the buffer.

The `WriteInt32ToBuffer` method has a lease on (can consume) the buffer between the start of the method call and the time the method returns. Similarly, `DisplayBufferToConsole` has a lease on the buffer while it's executing, and the lease is released when the method unwinds. (There is no API for lease management; a "lease" is a conceptual matter.)

[](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#memoryt-and-the-ownerconsumer-model)

## Memory<T> and the owner/consumer model

As the [Owners, consumers, and lifetime management](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#owners-consumers-and-lifetime-management) section notes, a buffer always has an owner. .NET supports two ownership models:

- A model that supports single ownership. A buffer has a single owner for its entire lifetime.
    
- A model that supports ownership transfer. Ownership of a buffer can be transferred from its original owner (its creator) to another component, which then becomes responsible for the buffer's lifetime management. That owner can in turn transfer ownership to another component, and so on.
    

You use the [System.Buffers.IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) interface to explicitly manage the ownership of a buffer. [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) supports both ownership models. The component that has an [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1)reference owns the buffer. The following example uses an [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) instance to reflect the ownership of a [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) buffer.

C#Copy

```
using System;
using System.Buffers;

class Example
{
    static void Main()
    {
        IMemoryOwner<char> owner = MemoryPool<char>.Shared.Rent();

        Console.Write("Enter a number: ");
        try
        {
            string? s = Console.ReadLine();

            if (s is null)
                return;

            var value = Int32.Parse(s);

            var memory = owner.Memory;

            WriteInt32ToBuffer(value, memory);

            DisplayBufferToConsole(owner.Memory.Slice(0, value.ToString().Length));
        }
        catch (FormatException)
        {
            Console.WriteLine("You did not enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"You entered a number less than {Int32.MinValue:N0} or greater than {Int32.MaxValue:N0}.");
        }
        finally
        {
            owner?.Dispose();
        }
    }

    static void WriteInt32ToBuffer(int value, Memory<char> buffer)
    {
        var strValue = value.ToString();

        var span = buffer.Span;
        for (int ctr = 0; ctr < strValue.Length; ctr++)
            span[ctr] = strValue[ctr];
    }

    static void DisplayBufferToConsole(Memory<char> buffer) =>
        Console.WriteLine($"Contents of the buffer: '{buffer}'");
}
```

We can also write this example with the [`using` statement](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/using):

C#Copy

```
using System;
using System.Buffers;

class Example
{
    static void Main()
    {
        using (IMemoryOwner<char> owner = MemoryPool<char>.Shared.Rent())
        {
            Console.Write("Enter a number: ");
            try
            {
                string? s = Console.ReadLine();

                if (s is null)
                    return;

                var value = Int32.Parse(s);

                var memory = owner.Memory;
                WriteInt32ToBuffer(value, memory);
                DisplayBufferToConsole(memory.Slice(0, value.ToString().Length));
            }
            catch (FormatException)
            {
                Console.WriteLine("You did not enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"You entered a number less than {Int32.MinValue:N0} or greater than {Int32.MaxValue:N0}.");
            }
        }
    }

    static void WriteInt32ToBuffer(int value, Memory<char> buffer)
    {
        var strValue = value.ToString();

        var span = buffer.Slice(0, strValue.Length).Span;
        strValue.AsSpan().CopyTo(span);
    }

    static void DisplayBufferToConsole(Memory<char> buffer) =>
        Console.WriteLine($"Contents of the buffer: '{buffer}'");
}
```

In this code:

- The `Main` method holds the reference to the [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) instance, so the `Main` method is the owner of the buffer.
    
- The `WriteInt32ToBuffer` and `DisplayBufferToConsole` methods accept [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) as a public API. Therefore, they are consumers of the buffer. These methods consume the buffer one at a time.
    

Although the `WriteInt32ToBuffer` method is intended to write a value to the buffer, the `DisplayBufferToConsole` method isn't intended to. To reflect this, it could have accepted an argument of type [ReadOnlyMemory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1). For more information on [ReadOnlyMemory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1), see [Rule #2: Use ReadOnlySpan<T> or ReadOnlyMemory<T> if the buffer should be read-only](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#rule-2).

[](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#ownerless-memoryt-instances)

### "Ownerless" Memory<T> instances

You can create a [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance without using [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1). In this case, ownership of the buffer is implicit rather than explicit, and only the single-owner model is supported. You can do this by:

- Calling one of the  [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) constructors directly, passing in a `T[]`, as the following example does.
    
- Calling the [String.AsMemory](https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.asmemory#system-memoryextensions-asmemory(system-string)) extension method to produce a `ReadOnlyMemory<char>` instance.
    

C#Copy

```
using System;

class Example
{
    static void Main()
    {
        Memory<char> memory = new char[64];

        Console.Write("Enter a number: ");
        string? s = Console.ReadLine();

        if (s is null)
            return;

        var value = Int32.Parse(s);

        WriteInt32ToBuffer(value, memory);
        DisplayBufferToConsole(memory);
    }

    static void WriteInt32ToBuffer(int value, Memory<char> buffer)
    {
        var strValue = value.ToString();
        strValue.AsSpan().CopyTo(buffer.Slice(0, strValue.Length).Span);
    }

    static void DisplayBufferToConsole(Memory<char> buffer) =>
        Console.WriteLine($"Contents of the buffer: '{buffer}'");
}
```

The method that initially creates the [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance is the implicit owner of the buffer. Ownership cannot be transferred to any other component because there is no [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) instance to facilitate the transfer. (As an alternative, you can also imagine that the runtime's garbage collector owns the buffer, and all methods just consume the buffer.)

[](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#usage-guidelines)

## Usage guidelines

Because a memory block is owned but is intended to be passed to multiple components, some of which may operate upon a particular memory block simultaneously, it's important to establish guidelines for using both [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) and [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1). Guidelines are necessary because it's possible for a component to:

- Retain a reference to a memory block after its owner has released it.
    
- Operate on a buffer at the same time that another component is operating on it, in the process corrupting the data in the buffer.
    
- While the stack-allocated nature of [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) optimizes performance and makes [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) the preferred type for operating on a memory block, it also subjects [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) to some major restrictions. It's important to know when to use a [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) and when to use [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1).
    

The following are our recommendations for successfully using [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) and its related types. Guidance that applies to [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) and [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) also applies to [ReadOnlyMemory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1) and [ReadOnlySpan<T>](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1) unless noted otherwise.

**Rule #1: For a synchronous API, use Span<T> instead of Memory<T> as a parameter if possible.**

[Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) is more versatile than [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) and can represent a wider variety of contiguous memory buffers. [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) also offers better performance than [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1). Finally, you can use the [Memory<T>.Span](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1.span#system-memory-1-span) property to convert a [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance to a [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1), although Span<T>-to-Memory<T> conversion isn't possible. So if your callers happen to have a [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance, they'll be able to call your methods with [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1)parameters anyway.

Using a parameter of type [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) instead of type [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) also helps you write a correct consuming method implementation. You'll automatically get compile-time checks to ensure that you're not attempting to access the buffer beyond your method's lease (more on this later).

Sometimes, you'll have to use a [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) parameter instead of a [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) parameter, even if you're fully synchronous. Perhaps an API that you depend on accepts only [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) arguments. This is fine, but be aware of the tradeoffs involved when using [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) synchronously.

**Rule #2: Use ReadOnlySpan<T> or ReadOnlyMemory<T> if the buffer should be read-only.**

In the earlier examples, the `DisplayBufferToConsole` method only reads from the buffer; it doesn't modify the contents of the buffer. The method signature should be changed to the following.

C#Copy

```
void DisplayBufferToConsole(ReadOnlyMemory<char> buffer);
```

In fact, if we combine this rule and Rule #1, we can do even better and rewrite the method signature as follows:

C#Copy

```
void DisplayBufferToConsole(ReadOnlySpan<char> buffer);
```

The `DisplayBufferToConsole` method now works with virtually every buffer type imaginable: `T[]`, storage allocated with [stackalloc](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/stackalloc), and so on. You can even pass a [String](https://learn.microsoft.com/en-us/dotnet/api/system.string) directly into it! For more information, see GitHub issue [dotnet/docs #25551](https://github.com/dotnet/docs/issues/25551).

**Rule #3: If your method accepts Memory<T> and returns `void`, you must not use the Memory<T> instance after your method returns.**

This relates to the "lease" concept mentioned earlier. A void-returning method's lease on the [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1)instance begins when the method is entered, and it ends when the method exits. Consider the following example, which calls `Log` in a loop based on input from the console.

C#Copy

```
using System;
using System.Buffers;

public class Example
{
    // implementation provided by third party
    static extern void Log(ReadOnlyMemory<char> message);

    // user code
    public static void Main()
    {
        using (var owner = MemoryPool<char>.Shared.Rent())
        {
            var memory = owner.Memory;
            var span = memory.Span;
            while (true)
            {
                string? s = Console.ReadLine();

                if (s is null)
                    return;

                int value = Int32.Parse(s);
                if (value < 0)
                    return;

                int numCharsWritten = ToBuffer(value, span);
                Log(memory.Slice(0, numCharsWritten));
            }
        }
    }

    private static int ToBuffer(int value, Span<char> span)
    {
        string strValue = value.ToString();
        int length = strValue.Length;
        strValue.AsSpan().CopyTo(span.Slice(0, length));
        return length;
    }
}
```

If `Log` is a fully synchronous method, this code will behave as expected because there is only one active consumer of the memory instance at any given time. But imagine instead that `Log` has this implementation.

C#Copy

```
// !!! INCORRECT IMPLEMENTATION !!!
static void Log(ReadOnlyMemory<char> message)
{
    // Run in background so that we don't block the main thread while performing IO.
    Task.Run(() =>
    {
        StreamWriter sw = File.AppendText(@".\input-numbers.dat");
        sw.WriteLine(message);
    });
}
```

In this implementation, `Log` violates its lease because it still attempts to use the [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance in the background after the original method has returned. The `Main` method could mutate the buffer while `Log`attempts to read from it, which could result in data corruption.

There are several ways to resolve this:

- The `Log` method can return a [Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task) instead of `void`, as the following implementation of the `Log` method does.
    
    C#Copy
    
    ```
    // An acceptable implementation.
    static Task Log(ReadOnlyMemory<char> message)
    {
        // Run in the background so that we don't block the main thread while performing IO.
        return Task.Run(() => {
            StreamWriter sw = File.AppendText(@".\input-numbers.dat");
            sw.WriteLine(message);
            sw.Flush();
        });
    }
    ```
    
- `Log` can instead be implemented as follows:
    
    C#Copy
    
    ```
    // An acceptable implementation.
    static void Log(ReadOnlyMemory<char> message)
    {
        string defensiveCopy = message.ToString();
        // Run in the background so that we don't block the main thread while performing IO.
        Task.Run(() =>
        {
            StreamWriter sw = File.AppendText(@".\input-numbers.dat");
            sw.WriteLine(defensiveCopy);
            sw.Flush();
        });
    }
    ```
    

**Rule #4: If your method accepts a Memory<T> and returns a Task, you must not use the Memory<T> instance after the Task transitions to a terminal state.**

This is just the async variant of Rule #3. The `Log` method from the earlier example can be written as follows to comply with this rule:

C#Copy

```
// An acceptable implementation.
static Task Log(ReadOnlyMemory<char> message)
{
    // Run in the background so that we don't block the main thread while performing IO.
    return Task.Run(() =>
    {
        StreamWriter sw = File.AppendText(@".\input-numbers.dat");
        sw.WriteLine(message);
        sw.Flush();
    });
}
```

Here, "terminal state" means that the task transitions to a completed, faulted, or canceled state. In other words, "terminal state" means "anything that would cause await to throw or to continue execution."

This guidance applies to methods that return [Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task), [Task<TResult>](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1), [ValueTask<TResult>](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1), or any similar type.

**Rule #5: If your constructor accepts Memory<T> as a parameter, instance methods on the constructed object are assumed to be consumers of the Memory<T> instance.**

Consider the following example:

C#Copy

```
class OddValueExtractor
{
    public OddValueExtractor(ReadOnlyMemory<int> input);
    public bool TryReadNextOddValue(out int value);
}

void PrintAllOddValues(ReadOnlyMemory<int> input)
{
    var extractor = new OddValueExtractor(input);
    while (extractor.TryReadNextOddValue(out int value))
    {
      Console.WriteLine(value);
    }
}
```

Here, the `OddValueExtractor` constructor accepts a `ReadOnlyMemory<int>` as a constructor parameter, so the constructor itself is a consumer of the `ReadOnlyMemory<int>` instance, and all instance methods on the returned value are also consumers of the original `ReadOnlyMemory<int>` instance. This means that `TryReadNextOddValue` consumes the `ReadOnlyMemory<int>` instance, even though the instance isn't passed directly to the `TryReadNextOddValue` method.

**Rule #6: If you have a settable Memory<T>-typed property (or an equivalent instance method) on your type, instance methods on that object are assumed to be consumers of the Memory<T> instance.**

This is really just a variant of Rule #5. This rule exists because property setters or equivalent methods are assumed to capture and persist their inputs, so instance methods on the same object may utilize the captured state.

The following example triggers this rule:

C#Copy

```
class Person
{
    // Settable property.
    public Memory<char> FirstName { get; set; }

    // alternatively, equivalent "setter" method
    public SetFirstName(Memory<char> value);

    // alternatively, a public settable field
    public Memory<char> FirstName;
}
```

**Rule #7: If you have an IMemoryOwner<T> reference, you must at some point dispose of it or transfer its ownership (but not both).**

Since a [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance may be backed by either managed or unmanaged memory, the owner must call `Dispose` on [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) when work performed on the [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instance is complete. Alternatively, the owner may transfer ownership of the [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) instance to a different component, at which point the acquiring component becomes responsible for calling `Dispose` at the appropriate time (more on this later).

Failure to call the `Dispose` method on an [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) instance may lead to unmanaged memory leaks or other performance degradation.

This rule also applies to code that calls factory methods like [MemoryPool<T>.Rent](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.memorypool-1.rent). The caller becomes the owner of the returned [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) and is responsible for disposing of the instance when finished.

**Rule #8: If you have an IMemoryOwner<T> parameter in your API surface, you are accepting ownership of that instance.**

Accepting an instance of this type signals that your component intends to take ownership of this instance. Your component becomes responsible for proper disposal according to Rule #7.

Any component that transfers ownership of the [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) instance to a different component should no longer use that instance after the method call completes.

 Important

If your constructor accepts [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) as a parameter, its type should implement [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable), and your [Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) method should call `Dispose` on the [IMemoryOwner<T>](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.imemoryowner-1) object.

**Rule #9: If you're wrapping a synchronous p/invoke method, your API should accept Span<T> as a parameter.**

According to Rule #1, [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1) is generally the correct type to use for synchronous APIs. You can pin [Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1)instances via the [`fixed`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/fixed) keyword, as in the following example.

C#Copy

```
using System.Runtime.InteropServices;

[DllImport(...)]
private static extern unsafe int ExportedMethod(byte* pbData, int cbData);

public unsafe int ManagedWrapper(Span<byte> data)
{
    fixed (byte* pbData = &MemoryMarshal.GetReference(data))
    {
        int retVal = ExportedMethod(pbData, data.Length);

        /* error checking retVal goes here */

        return retVal;
    }
}
```

In the previous example, `pbData` can be null if, for example, the input span is empty. If the exported method absolutely requires that `pbData` be non-null, even if `cbData` is 0, the method can be implemented as follows:

C#Copy

```
public unsafe int ManagedWrapper(Span<byte> data)
{
    fixed (byte* pbData = &MemoryMarshal.GetReference(data))
    {
        byte dummy = 0;
        int retVal = ExportedMethod((pbData != null) ? pbData : &dummy, data.Length);

        /* error checking retVal goes here */

        return retVal;
    }
}
```

**Rule #10: If you're wrapping an asynchronous p/invoke method, your API should accept Memory<T> as a parameter.**

Since you cannot use the [`fixed`](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/fixed) keyword across asynchronous operations, you use the [Memory<T>.Pin](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1.pin) method to pin [Memory<T>](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1) instances, regardless of the kind of contiguous memory the instance represents. The following example shows how to use this API to perform an asynchronous p/invoke call.

C#Copy

```
using System.Runtime.InteropServices;

[UnmanagedFunctionPointer(...)]
private delegate void OnCompletedCallback(IntPtr state, int result);

[DllImport(...)]
private static extern unsafe int ExportedAsyncMethod(byte* pbData, int cbData, IntPtr pState, IntPtr lpfnOnCompletedCallback);

private static readonly IntPtr _callbackPtr = GetCompletionCallbackPointer();

public unsafe Task<int> ManagedWrapperAsync(Memory<byte> data)
{
    // setup
    var tcs = new TaskCompletionSource<int>();
    var state = new MyCompletedCallbackState
    {
        Tcs = tcs
    };
    var pState = (IntPtr)GCHandle.Alloc(state);

    var memoryHandle = data.Pin();
    state.MemoryHandle = memoryHandle;

    // make the call
    int result;
    try
    {
        result = ExportedAsyncMethod((byte*)memoryHandle.Pointer, data.Length, pState, _callbackPtr);
    }
    catch
    {
        ((GCHandle)pState).Free(); // cleanup since callback won't be invoked
        memoryHandle.Dispose();
        throw;
    }

    if (result != PENDING)
    {
        // Operation completed synchronously; invoke callback manually
        // for result processing and cleanup.
        MyCompletedCallbackImplementation(pState, result);
    }

    return tcs.Task;
}

private static void MyCompletedCallbackImplementation(IntPtr state, int result)
{
    GCHandle handle = (GCHandle)state;
    var actualState = (MyCompletedCallbackState)(handle.Target);
    handle.Free();
    actualState.MemoryHandle.Dispose();

    /* error checking result goes here */

    if (error)
    {
        actualState.Tcs.SetException(...);
    }
    else
    {
        actualState.Tcs.SetResult(result);
    }
}

private static IntPtr GetCompletionCallbackPointer()
{
    OnCompletedCallback callback = MyCompletedCallbackImplementation;
    GCHandle.Alloc(callback); // keep alive for lifetime of application
    return Marshal.GetFunctionPointerForDelegate(callback);
}

private class MyCompletedCallbackState
{
    public TaskCompletionSource<int> Tcs;
    public MemoryHandle MemoryHandle;
}
```

[](https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines#see-also)