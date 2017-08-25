using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Example26
    {
        static Random rand = new Random();

        public static void PrintMe(int sleep)
        {
            Console.WriteLine("[{0}] Start Print Me {1}", Thread.CurrentThread.ManagedThreadId, DateTime.UtcNow);
            Thread.Sleep(sleep);
            Console.WriteLine("[{0}]\tEnd Print Me {1}", Thread.CurrentThread.ManagedThreadId, DateTime.UtcNow);
        }

        public static void PrintLine(string FirstName, string LastName = "", int age = 0)
        {
            Console.WriteLine("{0} {1} is {2} years old ", FirstName, LastName, age);
        }

        public static void ExampleCode2()
        {
            List<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            Parallel.ForEach(items, (i) => Console.WriteLine("{0}::{1}", Thread.CurrentThread.ManagedThreadId, i));
        }

        public static void ExampleCode1()
        {
            PrintLine("Jack", "Smith", 26);
            PrintLine("Sally", age: 34);

            PrintMe(rand.Next(5000));

            Task t1 = new Task(() => PrintMe(rand.Next(5000)));

            

            Task t2 = Task.Factory.StartNew(() => PrintMe(rand.Next(5000)));
            Task t3 = Task.Factory.StartNew(() => PrintMe(rand.Next(5000)));

            t1.Start();
        }
    }
}
