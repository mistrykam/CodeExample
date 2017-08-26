using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class AsyncAwait
    {
        /* Async
          
            https://www.youtube.com/watch?v=DqjIQiZ_ql4&t=894s

            NOTE: 
                The aysnc keyword goes into the method signature: example   public async int SomeMethod()
                It tells the complier that an await may appear in the method.
                                              ---------------- 
                                              
            The core of async programming are the Task and Task<T> objects, which model asynchronous operations. 
            They are supported by the async and await keywords. The model is fairly simple in most cases:
            
            For I/O-bound code, you await an operation which returns a Task or Task<T> inside of an async method.

            For CPU-bound code, you await an operation which is started on a background thread with the Task.Run method.
            
            The await keyword is where the magic happens. It yields control to the caller of the method that performed await, 
            and it ultimately allows a UI to be responsive or a service to be elastic.            
                                       --                       -------

         
            Writing I/O and CPU-bound asynchronous code is straightforward using the .NET Task-based async model. 
            
            The model is exposed by the Task and Task<T> types and the async and await keywords.

            async - specify that a method, lambda expression, or anonymous method is asynchronous
                    -------

            await  - allows your application perform useful work while a task is running by 
                     yielding control to its caller until the task is done
                     await takes a single arguement 'Task' or 'Task<T>' 

            Return types:
                
            Task    - represents a single operation which does not return a value
            Task<T> - represents a single operation which returns a value of type T                 
                      the workhorse type of the Task Parallel Library (TPL)


            NOTES: https://blog.stephencleary.com/2012/02/async-and-await.html

            The “async” keyword enables the “await” keyword in that method and changes how method results are handled. 
            That’s all the async keyword does! It does not run this method on a thread pool thread. 

            The beginning of an async method is executed just like any other method, runs synchronously 
            until it hits an “await”.

            The “await” keyword is where things can get asynchronous. 
            Await is like a unary operator: it takes a single argument, an awaitable (an “awaitable” is an asynchronous operation). 
            Await examines that awaitable to see if it has already completed; if the awaitable has already completed, 
            then the method just continues running (synchronously, just like a regular method).

            If “await” sees that the awaitable has not completed, then it acts asynchronously. 
            It tells the awaitable to run the remainder of the method when it completes, and then returns from the async method.

            Later on, when the awaitable completes, it will execute the remainder of the async method. 
            If you’re awaiting a built-in awaitable (such as a task), then the remainder of the async method will 
            execute on a “context” that was captured before the “await” returned.

            I like to think of “await” as an “asynchronous wait”. That is to say, the async method pauses 
            until the awaitable is complete (so it waits), but the actual thread is not blocked (so it’s asynchronous).

            As I mentioned, “await” takes a single argument - an “awaitable” - which is an asynchronous operation. 
            There are two awaitable types already common in the .NET framework: Task<T> and Task.

         */

        private static Random rand = new Random();

        private static int DoBigTask(string name)
        {
            Console.WriteLine("{0} started at {1}", name, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));

            int cost = 0;

            for (int i = 0; i < 10; i++)
            {
                int work = rand.Next(1, 500);
                Thread.Sleep(work);
                cost += work;
                Console.WriteLine("\t\tCompleted sub-task {0} of 10 :: {1}" , i + 1, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            }

            Console.WriteLine("{0} done at {1} cost = {2}", name, DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"), cost);

            return cost;
        }


        /* Not Async: Have to wait for the BigTask to complete first */

        public static void NotAsyncExample()
        {
            // Not ASYNC 
            int car1RepairCost = DoBigTask("Service Car #1");                        
            int car2RepairCost = DoBigTask("Service Car #2");
            int car3RepairCost = DoBigTask("Service Car #3");
        }

        // wrap the big long method into into Task to execute which is now an Async Method
        private static Task<int> DoBigTaskAsync(string name)
        {
            return Task.Run<int>(() => DoBigTask(name));
        }

        public static async void AsyncExample()
        {
            // this would make sense if it's being called from a UI or service
            int car1RepairCost = await DoBigTaskAsync("Service Car #1");
            int car2RepairCost = await DoBigTaskAsync("Service Car #2");
            int car3RepairCost = await DoBigTaskAsync("Service Car #3");
        }
    }
}
