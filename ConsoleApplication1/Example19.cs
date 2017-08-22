using System;
using System.Threading;

namespace ConsoleApplication1
{
    public static class Example19
    {
        public static void DifferentMethod1()
        {
            Console.WriteLine("\tHello from DifferentMethod1() {0}:::{1} ", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
        }

        public static void DifferentMethod2(object index)
        {
            while (true)
            {
                Console.WriteLine("\tHello from DifferentMethod2() {0}:::{1}:::{2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, index);
            }
        }

        static int counter = 0;
        static object synObject = new object();  // needs to be static to be shared between threads
        static Random rand = new Random();

        public static void DifferentMethod3()
        {
            while (true)
            {
                int temp = counter; 
                Thread.Sleep(rand.Next(999));
                counter = temp + 1; // not atomic operation (think assembly steps to do this)
                Console.WriteLine("\tHello from DifferentMethod3() {0}:::{1}:::Counter={2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, counter);
                Thread.Sleep(rand.Next(999));
            }
        }

        public static void DifferentMethod3Sync()
        {
            while (true)
            {
                lock (synObject)
                {
                    int temp = counter;
                    Thread.Sleep(rand.Next(999));
                    counter = temp + 1; // not atomic operation (think assembly steps to do this)
                    Console.WriteLine("\tHello from DifferentMethod3() {0}:::{1}:::Counter={2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, counter);
                }
                Thread.Sleep(rand.Next(999));
            }
        }

        public static void UseTheKitchen()
        {
            Console.WriteLine("{0}:::Entering the kitchen...", Thread.CurrentThread.ManagedThreadId);

            lock (synObject)
            {
                Console.WriteLine("\t{0}:::Obtain the lock:::", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(rand.Next(1000));
                Console.WriteLine("\t{0}:::Release the lock:::", Thread.CurrentThread.ManagedThreadId);
            }

            Console.WriteLine("{0}:::Exited the kitchen.", Thread.CurrentThread.ManagedThreadId);
        }

        public static void ExampleCode1()
        {
            Thread thread = new Thread(DifferentMethod1);
            thread.Start();
        }

        public static void ExampleCode2()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Thread thread = new Thread(DifferentMethod2);  // ParameterizedThreadStart - pass in an object
                thread.Start(i);  // foreground threads 
            }

            Console.WriteLine("Hello from Main() {0}", DateTime.Now);

            Console.WriteLine("Main has completed");
        }

        public static void ExampleCode3()
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Thread thread = new Thread(DifferentMethod2);  // ParameterizedThreadStart - pass in an object
                thread.IsBackground = true; // Background thread
                thread.Start(i);
            }

            Console.WriteLine("Hello from Main() {0}", DateTime.Now);
            Console.WriteLine("Main has completed");
        }

        public static void ExampleCode4()
        {
            Thread thread1 = new Thread(DifferentMethod3);
            Thread thread2 = new Thread(DifferentMethod3);

            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
        }

        public static void ExampleCode5()
        {
            Thread thread1 = new Thread(DifferentMethod3Sync);
            Thread thread2 = new Thread(DifferentMethod3Sync);

            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
        }

        public static void ExampleCode6()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(UseTheKitchen).Start();
                Thread.Sleep(rand.Next(1000));
            }
        }
    }
}
