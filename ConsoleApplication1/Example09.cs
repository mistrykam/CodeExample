using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Cow
    {
        public int numberOfMoos;

        public void Moo()
        {
            numberOfMoos++;
        }

        public Cow()
        {
            numberOfMoos = 0;
        }

        public static Cow operator +(Cow c1, Cow c2)
        {
            return new Cow();
        }
    }

    public struct Wolf
    {
        public int numberOfBarks;


        public void Bark()
        {
            numberOfBarks++;
        }

        public Wolf(int x)
        {
            numberOfBarks = x;
        }        
    }

    public struct Fraction
    {
        public int Numerator;
        public int Demomantor;
    }

    public class Example09
    {
        public static void ExampleCode1()
        {
            Fraction fract;

            fract.Numerator = 1;
            fract.Demomantor = 2;

            Cow c1 = new Cow(); // class
            c1.Moo();
            c1.Moo();
            c1.Moo();
            c1.Moo();
            Console.WriteLine("The cow {0} has mooed {1} time(s).", c1.GetType().GetHashCode(), c1.numberOfMoos);

            Wolf w0;

            w0.numberOfBarks = -1;

            Wolf w1 = new Wolf(); // struct
            Wolf w2 = new Wolf(100);
            Wolf w3 = w1;

            w3.numberOfBarks = 333;

            w1.Bark();
            w1.Bark();
            w1.Bark();
            w1.Bark();

            Console.WriteLine("The wolf-0 {0} has barked {1} time(s).", w0.GetType().GetHashCode(), w0.numberOfBarks);
            Console.WriteLine("The wolf-1 {0} has barked {1} time(s).", w1.GetType().GetHashCode(), w1.numberOfBarks);
            Console.WriteLine("The wolf-2 {0} has barked {1} time(s).", w2.GetType().GetHashCode(), w2.numberOfBarks);

            int i = 10;
            object o = i;

            i += 100;

            Console.WriteLine("integer i {0} {1} {2}", i, i.GetType(), i.GetType().BaseType);
            Console.WriteLine("object  o {0} {1} {2}", o, o.GetType(), i.GetType().BaseType);
        }
    }
}
