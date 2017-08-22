using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Node
    {
        public Node Next;
        public int Value;
    }

    public class Example10
    {
        public static void ExampleCode1()
        {
            Node first = new Node() { Value = 0 };

            Node item = first;

            for (int i = 0; i < 10; i++)
            {
                Node next = new Node() { Value = i };
                item.Next = next;
                item = next;
            }

            item = first;

            for (int i = 0; i < 10; i++)
            {
                item = item.Next;
                Console.WriteLine("Node {0} has value {1}", item.GetHashCode(), item.Value);
            }

            int myInt = 0;

            Console.WriteLine("myInt " + myInt.GetType());
            Console.WriteLine("myInt " + myInt.GetType().BaseType);
            Console.WriteLine("myInt " + myInt.GetType().BaseType.BaseType);
            Console.WriteLine("myInt " + myInt.GetType().BaseType.BaseType.BaseType);

            Console.WriteLine("node " + first.GetType());
            Console.WriteLine("node " + first.GetType().BaseType);
            Console.WriteLine("node " + first.GetType().BaseType.BaseType);


        }
    }
}
