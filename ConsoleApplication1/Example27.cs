using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Operations
    {
        static Random rand = new Random();

        public bool IsCompleted { get; set; }

        public async void DoWork()
        {
            IsCompleted = false;

            Console.WriteLine("Starting work....");
            await LongOperations();
            Console.WriteLine("Done!");

            IsCompleted = true;
        }

        private Task LongOperations()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.Write("\tWorking");
                for (int i = 0; i < 10; i++)
                { 
                    Thread.Sleep(rand.Next(1000));
                }
            });
        }

        public static int SumPages(List<Uri> lists)
        {
            Console.WriteLine("Sync way");

            int total = 0;

            foreach (var link in lists)
            {
                Console.Write("Downloading {0}...", link);
                var page = new WebClient().DownloadData(link);
                total += page.Length;
                Console.WriteLine();
            }

            return total;
        }

        public static async Task<int> SumPagesAsync(List<Uri> lists)
        {
            Console.WriteLine("Async way");

            int total = 0;

            foreach (var link in lists)
            {
                Console.Write("Downloading {0}", link);
                var page = await new WebClient().DownloadDataTaskAsync(link);
                total += page.Length;
                Console.WriteLine();

            }

            return total;
        }

    }

    public class Example27
    {
        public static async void ExampleCode1()
        {
            Operations ops = new Operations();

            ops.DoWork();

            while(!ops.IsCompleted)
            {                                
                await Task.Delay(100);
                Console.Write(".");
            }
        }

        public static void ExampleCode2()
        {
            List<Uri> websites = new List<Uri>()
                            {
                                new Uri(@"http://www.millennial-revolution.com/"),
                                new Uri(@"http://jlcollinsnh.com/stock-series/"),
                                new Uri(@"http://rootofgood.com/"),
                                new Uri(@"http://www.gocurrycracker.com/"),
                                new Uri(@"http://www.donebyforty.com/"),
                                new Uri(@"http://www.financialsamurai.com/"),
                                new Uri(@"http://www.budgetsaresexy.com/"),
                                new Uri(@"http://rockstarfinance.com/")
                            };

            //Console.WriteLine("{0} size of pages ", Operations.SumPages(websites));

            Task<int> sum = Operations.SumPagesAsync(websites);

            Task.WhenAll(sum);

            while (!sum.IsCompleted)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.WriteLine("{0} size of pages ", sum.Result);
        }
    }
}
