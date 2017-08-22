using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Pig
    {
        public Pig(string name)
        {
            Console.WriteLine("The name of the pig is {0}", name);
        }
    }

    public class Farm
    {
        Pig pig1 = new Pig("Howard");
        Pig pig2 = new Pig("Martha");

        public Farm()
        {
            Console.WriteLine("Create my farm");

            if (pig1 == null || pig2 == null)
                Console.WriteLine("Pigs have not been created yet!!!");
            else
                Console.WriteLine("Pigs exist and can be used referenced in the constructor!!!");
        }
    }

    public static class Example13
    {
        public static void ExampleCode1()
        {
            Farm farm = new Farm();
        }
    }
}
