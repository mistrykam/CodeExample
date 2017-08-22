using System;

namespace ConsoleApplication1
{
    public class Something { }

    public class Example11
    {
        public static void P<T>(T item) where T : struct
        {
            Console.WriteLine("hello {0} {1}", item, item.GetType().Name);
        }

        public static void ExampleCode1()
        {
            int i = 10;
            int j = 11;
            int k = i + j;

            Console.WriteLine("{0} + {1} = {2}", i, j, k);

            Console.WriteLine("i {0}", i.GetType().BaseType);
            Console.WriteLine("j {0}", j.GetType().BaseType);
            Console.WriteLine("k {0}", k.GetType().BaseType);

            int? ii = 10;
            int? jj = 11;
            int? kk = ii + jj;

            Console.WriteLine("{0} + {1} = {2}", ii, jj, kk);

            Console.WriteLine("ii {0}", ii.GetType().BaseType);
            Console.WriteLine("jj {0}", jj.GetType().BaseType);
            Console.WriteLine("kk {0}", kk.GetType().BaseType);

            ii = null;
            jj = 11;
            kk = ii + jj;

            Console.WriteLine("{0} + {1} = {2}", ii, jj, kk);

            Console.WriteLine("Something is {0}",  (new Something()).GetType().BaseType);

            object  ob = new object();


            string  st = "Hello World";
           
            char    ch = '0';      // all primitives are structs
            
            bool    bo  = false;
            
            byte    by   = 255;
            sbyte   sb   = 0;
            short   sh   = 0;
            ushort  us   = 0;
            int     it   = 0;
            uint    ui   = 0;
            long    lo   = long.MaxValue;
            ulong   ul   = 0;
            float   fl   = 0.0f;
            double  dou  = 0.0d;
            decimal dec  = 0.0m;

            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} ", st, ch, bo, by, sb, sh, us, it, ui, lo, ul, fl, dou, dec);

            it = (int)lo;  // conversion is allowed, runtime will copy the bits as best it can
        }

        public static void ExampleCode2()
        {
            int integer = 5;
            float f1 = 100.0f;

            P(integer);
            P(f1);
        }

    }
}
