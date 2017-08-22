using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ClassOne { public ClassOne() { } }
    public class ClassTwo { public ClassTwo(int a, int b) { } }

    public class Taken<T> where T : IComparable, IConvertible
    {

    }

    public class Example07
    {
        static T Produce<T>() where T : new()
        {
            T item = default(T);

            return item;
        }


        public static void ExampleCode1()
        {
            Produce<ClassOne>();
            //Produce<ClassTwo>();
        }
    }
}
