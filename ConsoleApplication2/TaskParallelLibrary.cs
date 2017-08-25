using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class TaskParallelLibrary
    {
        /* Task Parallel Library
          
           See Video: https://www.youtube.com/watch?v=gfkuD_eWM5Y 
            
           The Task Parallel Library (TPL) is based on the concept of a task, which represents an asynchronous operation. 
           In some ways, a task is like a thread, but at a higher level of abstraction. 
           The term task parallelism refers to one or more independent tasks running concurrently. 
           
           Tasks provide two primary benefits:

           - More efficient and more scalable use of system resources. Behind the scenes, tasks are queued to the ThreadPool.
           - More programmatic control than is possible with a thread or work item.

           Tasks and the framework built around them provide a rich set of APIs that support waiting, cancellation, 
           continuations, robust exception handling, detailed status, custom scheduling, and more.

           Creating and running tasks explicitly:
           
           There are two tasks you can create:
           
           Task    - represents a single operation which does not return a value
                   - Example:  
                        Task task = new Task()(() => { Console.WriteLine("...running..."); });
                        task.Start();
            
           Task<T> - represents a single operation which returns a value of type T                 
                   - Example:  
                        Task task = new Task<int>()(() => { Console.WriteLine("...running..."); return 100*200; });
                        task.Start();

                   Note: You can use Task.Run( ...lambda expression...) to start the task write away.

           Parallel.For() 
           Parallel.ForEach() - provides library-based data parallel replacements for common operations such as for loops, 
                                for each loops, and execution of a set of statements.
         
         */

        private static void MyAction(int id, int delayInMilliSeconds)
        {
            Console.WriteLine("Runing task id = {0} at {1}...", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Thread.Sleep(delayInMilliSeconds);
            Console.WriteLine("..done task id = {0} at {1}", id, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
        }

        private static int MyFunc(int id, int delayInSeconds, int count)
        {
            MyAction(id, delayInSeconds);

            return count * 2;
        }

        public static void TaskExample()
        {
            // Create a task and Start it

            Task task1 = new Task(() => MyAction(1, 3000));
            task1.Start();

            Task task2 = new Task<int>(() => MyFunc(2, 1, 5000));
            task2.Start();

            // Create and Start the task in one line (more options can be supplied on StartNew method)

            Task task3 = Task.Factory.StartNew(() => MyAction(3, 1700));

            Task task4 = Task<int>.Factory.StartNew(() => MyFunc(4, 1, 3000));

            // Simplified with Run: Create and Start task

            Task task5 = Task.Run(() => MyAction(5, 500));

            Task task6 = Task<int>.Run(() => MyFunc(6, 1, 1000));

            // This mean wait til all these tasks are completed before going to the next step
            Task.WaitAll(new Task[] { task1, task2, task3, task4, task5, task6 });

            Console.WriteLine("Done all the Tasks");
        }

        public static void TaskContinueWithExample()
        {
            // once the first task is completed, it will pass it the next task
            // If first task was Task<T> the Result field has the output

            Task task = Task<int>.Factory.StartNew(() => MyFunc(1, 1000, 100)).ContinueWith(t => Console.WriteLine(t.Result));
        }

        public static void ParallelForExample()
        {
            // executed in parallel tasks

            Parallel.For(1, 11, (i) => Console.WriteLine("hello {0}", i));

            // blocked here until the Parallel statements are done
            Console.WriteLine("Done the Parallel For");
        }

        public static void ParallelForEachExample()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 9, 8, 7, 5, 4, 3, 2, 1 };

            // executed in parallel tasks

            Parallel.ForEach(list, (i) => Console.WriteLine("Value is {0}", i) );

            // blocked here until the Parallel statements are done
            Console.WriteLine("Done the Parallel ForEach"); 

        }
    }
}
