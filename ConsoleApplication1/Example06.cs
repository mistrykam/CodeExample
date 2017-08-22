using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MyClass<T>
    {
        public static int Value;

        static MyClass()
        {
            Console.WriteLine("GetType {0}", typeof(MyClass<T>));
        }
    }

    public class Example06
    {
        public static void P<T>(T args)
        {
            Console.WriteLine("Hello World '{0}' of type {1} {2}", args, args.GetType(), args.GetHashCode());
        }

        public static void ExampleCode1()
        {
            MyClass<int>.Value = 100;
            MyClass<string>.Value = 200;
            MyClass<float>.Value = 300;

            MyClass<MyClass<int>>.Value = 100;

            Console.WriteLine("MyClass<int>.Value {0}", MyClass<int>.Value);
            Console.WriteLine("MyClass<string>.Value {0}", MyClass<string>.Value);
            Console.WriteLine("MyClass<float>.Value {0}", MyClass<float>.Value);

            P(1);
            P("Jane");
            P(new Example06());
            P(new MyClass<int>());
        }
    }
}
