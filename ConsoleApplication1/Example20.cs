using System;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public static class Example20
    {
        static byte[] values = new byte[500000000];

        static Random rand = new Random(1); // seed the same value

        private static void PopuateValues()
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (byte)rand.Next(10);
            }
        }

        public static void ExampleCode1()
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Byte array population started....");

            stopwatch.Start();
            PopuateValues();
            stopwatch.Stop();

            Console.WriteLine("\tByte array populated in {0} seconds.", stopwatch.Elapsed);

            long total = 0;

            Console.WriteLine("Started sum calculation...");

            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }

            stopwatch.Stop();

            Console.WriteLine("\tByte array total {0} calculated in {1} seconds", total, stopwatch.Elapsed);
        }
    }
}
