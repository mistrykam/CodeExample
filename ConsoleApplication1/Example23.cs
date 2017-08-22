using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class BoatHouse
    {
        object criticalSection1 = new object();
        object criticalSection2 = new object();
        object criticalSection3 = new object();
        object criticalSection4 = new object();

        public void UseBox1()
        {
            lock (criticalSection1)
            {
                Console.WriteLine("Using Box 1...");
                Thread.Sleep(2800);
                Console.WriteLine("\tDone Box 1.");
            }
        }

        public void UseBox2()
        {
            lock (criticalSection2)
            {
                Console.WriteLine("Using Box 2...");
                Thread.Sleep(3000);
                Console.WriteLine("\tDone Box 2.");
            }
        }

        public void UseBox3()
        {
            lock (criticalSection3)
            {
                Console.WriteLine("Using Box 3...");
                Thread.Sleep(1550);
                Console.WriteLine("\tDone Box 3.");
            }
        }

        public void UseBox4()
        {
            lock (criticalSection4)
            {
                Console.WriteLine("Using Box 4...");
                Thread.Sleep(3400);
                Console.WriteLine("\tDone Box 4.");
            }
        }
    }

    public static class Example23
    {
        public static void ExampleCode1()
        {
            BoatHouse boatHouse = new BoatHouse();

            Console.WriteLine("Starting the boat house...");

            Console.WriteLine("Thread 1 started...");
            new Thread(boatHouse.UseBox1).Start();

            Console.WriteLine("Thread 2 started...");
            new Thread(boatHouse.UseBox2).Start();

            Console.WriteLine("Thread 3 started...");
            new Thread(boatHouse.UseBox3).Start();

            Console.WriteLine("Thread 4 started...");
            new Thread(boatHouse.UseBox4).Start();
        }
    }
}
