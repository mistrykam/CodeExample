using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class StatementsParameters
    {
        /*
         Method Parameters
         
         If a parameter is declared for a method without ref or out, the parameter can have a value associated with it. That
         value can be changed in the method, but the changed value will not be retained when control passes back to the
         calling procedure. By using a method parameter keyword, you can change this behavior. 

         - params - variable number of arguements list or array of the specified type
         - ref    - pass by reference (initialized)
         - out    - which lets pass an argument to a method by reference rather than by value         
         */

        /* Params */

        private static void MyParamMethod(int a, params long[] list)
        {
            Console.WriteLine("The value of a = {0}", a);

            if (list != null)
            {
                for (int i = 0; i < list.Length; i++)
                    Console.WriteLine("params[{0}] = {1}", i, list[i]);
            }
        }

        public static void ParamsExample()
        {
            MyParamMethod(100);
            MyParamMethod(100, new long[] { 11, 22, 33, 44, 55 });
        }

        /* Ref example */

        private static void MyRefMethod(ref int a, ref int b, int c)
        {
            int temp = a;
            a = b;
            b = temp;

            c = 10000;
        }

        public static void RefExample()
        {
            int a = 1;
            int b = 10;
            int c = -1;

            Console.WriteLine("a = {0} b = {1} c = {2}", a, b, c);

            MyRefMethod(ref a, ref b, c);

            Console.WriteLine("a = {0} b = {1} c = {2}", a, b, c);
        }

        /* Out example */

        private static void OutMethod(out int a, out int b, int c)
        {
            a = 10;
            b = 100;
            c = c + 10;
        }

        public static void OutExample()
        {
            int a;        // doesn't have to be assigned a value
            int b;        // doesn't have to be assigned a value
            int c = 1000;

            OutMethod(out a, out b, c);

            Console.WriteLine("a = {0} b = {1} c = {2}", a, b, c);
        }
    }
}