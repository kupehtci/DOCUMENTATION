#CSHARP 

While developing with C#, we can fall into memory leak situations for many reasons. To solve these issues, we have to analyze annoying dump files.

If we have an idea of where the problem is, maybe we can debug with visual studio, take memory snapshots at regular intervals, detect objects that should not stay in memory, and deepen our examination of that object.

I think, these ways are very long and we have to do these each time we suspect that there is a memory leak issue in our application.

It was boring to do these, so I decided to find a way to detect memory leaks automatically and easily. That’s when I found the “WeakReference” class.

**Step 1**

First of all, we should understand the “GC” (Garbage Collector). The “GC” is an enormous mechanism within CLR. **Simply** it counts references of an object. There are a few intervals and some logic in the “GC” to check reference counts. The “GC” releases objects when there aren’t any references tied to them.

Two references represent the same object in this example.

The “GC” knows that and traces the object references.

The “GC” decreases the reference count when we set the “reference1” as null. The “reference2” is the only reference for the same object now.

When we set the “reference2” as null, the “GC” knows there is no reference tied to the object anymore. The object is now available to remove from the memory. The “GC” has some logic and intervals to remove it from the memory. It doesn’t happen immediately. You can also read [this article](https://www.geeksforgeeks.org/garbage-collection-in-c-sharp-dot-net-framework/).

**Step 2**

When we register a method to an event handler, the event handler holds a reference that is tied to the object of the method. It is a common mistake to get a memory leak issue.

**Step 3**

All of the references I mentioned before are strong references. The “GC" only counts strong references, so we can trace an object using a weak reference which isn’t going to cause a memory leak issue. We can store an object as a weak reference, we can access the object and its status.

![](https://miro.medium.com/v2/resize:fit:1400/1*uWlHMRb-UugWppJ3ixBthg.png)

It has the “IsAlive" property. It determines the status of the object. If it is false, the “GC" had removed it from the memory and “Target” is “null” now.

**A Simple Tracer**

Our tracer stores references with its creation date and type name, when we call the “AddObject” method. It sets its done date when we call the “SetAsDone” method.

Our “FindSuspectedMemoryLeaks” detects whether there are any memory leak issues, or not. An item is set as done and also it is still alive, this situation is a suspected cause for us, so we can add a log line into our returned string.

**Note:** I have mentioned before, the “GC” doesn’t run immediately. “GC.Collect()” forces the “GC” to clean the objects. But it isn’t a good practice, we just want to find leakages, so it is useful on only test environments, not on prod environments.

**Demo**

The following example shows us memory leak issues and how we can detect or solve them.

We have a console app to simulate the issues. “ProgramClosed” event and “_tempWindow” will help us to make memory leak issues.

Our first case doesn’t cause any memory leak issues. It simply creates an instance of the “CustomWindow”. Our example adds it into our tracer and sets as done when we don’t need it anymore.

You can see its output.

![](https://miro.medium.com/v2/resize:fit:844/1*cCBYplAakPCJtL1LTW3WSA.png)

Our second case causes a memory leakage because in the “CauseAMemoryLeakByReferenceCount” we assign our object to another reference that lives in our program context, not in the current method.

When we set “_tempWindow” as null, the memory leakage will resolve.

You can see the output of the second case.

![](https://miro.medium.com/v2/resize:fit:1400/1*ShpqB9tBrwytiOMvVHamKw.png)

Our last case causes a memory leakage because the “CauseAMemoryLeakByRegisteredEvent” method registers our “ProgramClosed” event and doesn't unregister when the current scope is completed.

Also, the “NoMemoryLeakByUnRegisteredEvent” method doesn’t cause any memory leak issues, because it unregisters the event at the last line of the method.

When we set “ProgramClosed” as null, the memory leakage will resolve.

You can see the output of the last case.

![](https://miro.medium.com/v2/resize:fit:1400/1*s8d6oF9mk2kgBg2unukl5g.png)

If you don’t fix the issue, the “OnProgramClosed” method runs for the window with the name “CauseAMemoryLeakByRegisteredEvent” when we invoke the “ProgramClosed” event at the last line of the “Main” method.

![](https://miro.medium.com/v2/resize:fit:1400/1*8oYMqUeomdGhGXRPvHkXiA.png)

**Note:** I am using its extended version on our test environment to find leakages, but I am not running it on our prod environment because of performance issues and to prevent unexpected exceptions. It is tied to a timer on our test environment and we check the logs periodically. We just use it for suspected references not all of the references in our application.

Please visit the following links to access the source code.

[https://github.com/serhatzor/medium.git](https://github.com/serhatzor/Medium.git)

[https://github.com/serhatzor/medium/tree/main/medium/weakeeferenceexample](https://github.com/serhatzor/Medium/tree/main/Medium/WeakReferenceExample)