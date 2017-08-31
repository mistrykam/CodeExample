using System;
using System.Threading;

namespace ConsoleApplication2
{
    class Threading
    {
        /* Threading
         
          Threads are the basic unit to which an operating system allocates processor time, and more than one 
          thread can be executing code inside that process. Each thread maintains exception handlers, a scheduling priority, 
          and a set of structures the system uses to save the thread context until it is scheduled. The thread context 
          includes all the information the thread needs to seamlessly resume execution, including the thread's set of CPU 
          registers and stack, in the address space of the thread's host process.

          The .NET Framework further subdivides an operating system process into lightweight managed subprocesses, 
          called application domains, represented by System.AppDomain. One or more managed threads (represented by System.Threading.Thread) 
          can run in one or any number of application domains within the same managed process.            

          When To Use Multiple Threads:

          - Software that requires user interaction must react to the user's activities as rapidly as possible to provide a rich user experience. 
          - At the same time, however, it must do the calculations necessary to present data to the user as fast as possible.          

          Disadvantages of Multiple Threads

          It is recommended that you use as few threads as possible, thereby minimizing the use of operating-system 
          resources and improving performance. Threading also has resource requirements and potential conflicts to be 
          considered when designing your application. 

           
          NOTE:
               Starting with the .NET Framework 4, multithreaded programming is greatly simplified with the System.Threading.Tasks.Parallel 
               and System.Threading.Tasks.Task classes, Parallel LINQ (PLINQ), new concurrent collection classes in the 
               System.Collections.Concurrent namespace, and a new programming model that is based on the concept of tasks 
               rather than threads. 
         */

        internal static void MyFunction(object id)
        {
            int count = 1;
            do
            {
                Console.Write("MyFunction() {0} at {1}", id, DateTime.Now);
                Console.WriteLine("...Thread id = {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(400);
            } while (count++ < 10);
        }

        public static void SimpleExample()
        {
            // create a thread and pass it a delegate
            Thread myThread = new Thread(MyFunction);

            Console.WriteLine("IsAlive: " + myThread.IsAlive);
            Console.WriteLine("IsThreadPoolThread: " + myThread.IsThreadPoolThread);

            myThread.Start(100);

            Console.WriteLine("IsAlive: " + myThread.IsAlive);
            Console.WriteLine("IsThreadPoolThread: " + myThread.IsThreadPoolThread);

            int count = 0;

            do
            {
                Console.WriteLine("Display Main() {0}", DateTime.Now);
                Thread.Sleep(200);
            } while (count++ < 15);
        }

        static int counter = 0;


        static void IncrementCounterNoLock()
        {
            while (true)
            {
                int temp = counter;
                Thread.Sleep(1000);
                counter = temp + 1;
                Console.WriteLine("Thread Id = {0} incremented counter to {1}", Thread.CurrentThread.ManagedThreadId, counter);
            }
        }


        public static void ConflictThread()
        {
            Console.WriteLine("Hit CTRL-C to stop");

            Thread thread1 = new Thread(IncrementCounterNoLock);
            Thread thread2 = new Thread(IncrementCounterNoLock);

            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
        }

        static object box = new object();

        static void IncrementCounterLock()
        {
            while (true)
            {
                lock (box)
                {
                    int temp = counter;
                    Thread.Sleep(1000);
                    counter = temp + 1;
                }

                Console.WriteLine("Thread Id = {0} incremented counter to {1}", Thread.CurrentThread.ManagedThreadId, counter);
            }
        }

        static void IncrementCounterMonitor()
        {
            while (true)
            {
                // lock (box)
                Monitor.Enter(box);
                try
                {
                    int temp = counter;
                    Thread.Sleep(1000);
                    counter = temp + 1;
                }
                finally
                {
                    Monitor.Exit(box);
                }

                Console.WriteLine("Thread Id = {0} incremented counter to {1}", Thread.CurrentThread.ManagedThreadId, counter);
            }
        }

        public static void NoConflictThread()
        {
            Console.WriteLine("Hit CTRL-C to stop");

            Thread thread1 = new Thread(IncrementCounterLock);
            Thread thread2 = new Thread(IncrementCounterLock);

            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
        }

        public static void ThreadJoinExample()
        {
            Thread[] thread = new Thread[10]; 

            for(int i = 0; i < 10; i++)
            {
                thread[i] = new Thread(MyFunction);
                thread[i].Start();
                Console.WriteLine("Started on thread with id {0}", thread[i].ManagedThreadId);
            }

            foreach (Thread t in thread)
            {
                Console.WriteLine("Waiting on thread with id {0}", t.ManagedThreadId);
                t.Join(); // wait for the thread to finish
            }

            Console.WriteLine("All threads are done.");
        }
    }
}
