
# MULTITHREADING USING LOCK
#CSHARP #Multithreading

Exclusive locking in threading ensures that one thread does not enter a critical section while another thread is in the critical section of code. If another thread attempts to enter a locked code, it will wait (block) until the object is released. To achieve this functionality we have to main exclusive locking constructs are,

Mutex
Lock

The lock construct is faster and more convenient. Mutex, though, has a place in that its lock can span applications in different processes on the computer.

The lock statement is used to lock a resource. The syntax for the lock statement is as follows:

```csharp
object lock = new Object(); 

lock (object resource) {
  // Code that accesses the resource
}

```

The resource parameter can be any object, but it is typically a reference to the shared resource. When the lock statement is executed, the current thread acquires a lock on the resource. Any other threads that try to acquire a lock on the resource will be blocked until the current thread releases the lock.

The lock statement is typically used to protect critical sections of code, which are blocks of code that access and modify shared resources.


```csharp
using System;
using System.Threading;
using System.Diagnostics;

namespace Threadlocking
{
    class Department
    {
        private Object thisLock = new Object();
        int salary;
        Random r = new Random();
        public Department(int initial)
        {
            salary = initial;
        }
        int Withdraw(int amount)
        {
            // This condition never is true unless the lock statement
            // is commented out.
            if (salary < 0)
            {
                throw new Exception("Negative Balance");
            }
            // Comment out the next line to see the effect of leaving out
            // the lock keyword.
            lock (thisLock)
            {
                if (salary >= amount)
                {
                    Console.WriteLine("salary before Withdrawal :  " + salary);
                    Console.WriteLine("Amount to Withdraw        : -" + amount);
                    salary = salary - amount;
                    Console.WriteLine("salary after Withdrawal  :  " + salary);
                    return amount;
                }
                else
                {
                    return 0; // transaction rejected
                }
            }
        }
        public void DoTransactions()
        {
            for (int i = 0; i < 100; i++)
            {

                Withdraw(r.Next(1, 100));
            }
        }
    }
    class Process
    {
        static void Main()
        {
            Thread[] threads = new Thread[10];
            Department dep = new Department(1000);
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(dep.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }
            Console.Read();
        }
    }
}
```

