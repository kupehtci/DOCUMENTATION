# MULTITHREADING USING MUTEX
#CSHARP #Multithreading 

Similar to semaphores, mutex need to be locked by telling to ```mutex.WaitOne();``` to meke other threads to wait here until the mutex is released. 
Once the critical section has ended, mutex need to be released calling ```mutex.ReleaseMutex();```

```csharp

Mutex mutex = new Mutex(); 

mutex.WaitOne();

// --- CRITICAL SECTION ---

mutex.ReleaseMutex(); 

```

## MUTEX OWNERS

A mutex have an owner, that its the **thread** that calls the ```ccharpmutex.WaitOne``` 

```csharp

using System;  
using System.Collections;  
using System.Threading;  
namespace Mutexclass  
{  
class BasicMutexProgram  
    {  
        private static Mutex mutex = new Mutex();  
        private const int numhits = 1;  
        private const int numThreads = 4;  

        private static void ThreadProcess()  
        {  
            for (int i = 0; i < numhits; i++)  
            {  
                MutexFunction();  
            }  
        }  
        private static void MutexFunction()  
        {  
            mutex.WaitOne();   // Wait until it is safe to enter.  

            Console.WriteLine("{0} has entered in the C_sharpcorner.com",  Thread.CurrentThread.Name);  

            // Place code to access non-reentrant resources here.  
           	Thread.Sleep(500);    // Wait until it is safe to enter.  
            Console.WriteLine("{0} is leaving the C_sharpcorner.com\r\n",  Thread.CurrentThread.Name);  

            mutex.ReleaseMutex();    // Release the Mutex.  
        }  


       static void Main(string[] args)  
       {  
             for (int i = 0; i < numThreads; i++)  
            {  
                Thread mycorner = new Thread(new ThreadStart(ThreadProcess));  
                mycorner.Name = String.Format("Thread{0}", i + 1);  
                mycorner.Start();  
            }  
            Console.Read();  
        }  
    }  
} 

```