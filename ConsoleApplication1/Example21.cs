using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Example21
    {
        static Queue<int> queue = new Queue<int>();
        static long[] sums = new long[Environment.ProcessorCount];
        static Random random = new Random(1); // same random numbers

        static object syncObject = new object();

        static void ProduceNumbers()
        {
            for (int i = 0; i < 20; i++)
            {
                int number = random.Next(1, 10);
                Console.WriteLine("The number added to the queue is {0}", number);

                lock (syncObject)
                {
                    queue.Enqueue(number);
                }
                
                Thread.Sleep(random.Next(500));
            }
        }

        static void SumTotal(object threadNumber)
        {
            DateTime future = DateTime.Now.AddSeconds(10);
            long total = 0;

            while ((DateTime.Now < future))
            {
                int? number = null;

                lock (syncObject)
                {
                    if (queue.Count != 0)
                    {
                        number = queue.Dequeue();
                        total += (long)number;
                    }
                }

                if (number != null)
                    Console.WriteLine("\t{0}:::The number added to the sum is {1}", Thread.CurrentThread.ManagedThreadId, number);
            }

            sums[(int)threadNumber] = total;
        }

        public static void ExampleCode1()
        {
            Thread produceThread = new Thread(ProduceNumbers);
            produceThread.Start();

            Thread[] threadList = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Console.WriteLine("Creating summing thread...{0}", i);
                threadList[i] = new Thread(SumTotal);
                threadList[i].Start(i);
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                // has the thread completed? if not wait til it done
                threadList[i].Join();
            }

            long total = 0;

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                total += sums[i];
            }

            Console.WriteLine("The final total is {0}", total);
        }
    }
}
