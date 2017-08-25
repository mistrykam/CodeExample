using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class AsyncAwait
    {
        /* Async
          
            https://www.youtube.com/watch?v=DqjIQiZ_ql4&t=894s
         
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

        private static async Task DoSomethingAsync()
        {
            Random rand = new Random();

            Console.WriteLine("\n\tWork started... {0}", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(rand.Next(250, 1000));
                Console.WriteLine("\t\tCompleted {0} of 10", i + 1);
            }

            Console.WriteLine("\n\tWork completed {0}", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
        }

        public static void AsyncExample()
        {
            var task1 = new Task(() =>
            {
                Console.WriteLine("doing...");
                Task.Delay(1000);
                Console.WriteLine("done");
            });

            task1.Start();
        }
    }
}
