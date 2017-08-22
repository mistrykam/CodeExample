using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Gorilla : IComparable<Gorilla>
    {
        static Random random = new Random(100); // fixed seed

        public string Name { get; set; }
        public int Weight { get; set; }

        public Gorilla(string name)
        {
            Name = name;
            Weight = random.Next(1000, 5000);
        }

        public int CompareTo(Gorilla other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return string.Format("[Name = {0}, Weight = {1}]", Name, Weight);
        }
    }

    public class Example25
    {
        public static void ExampleCode2()
        {
            List<Gorilla> list = new List<Gorilla>()
            {
                new Gorilla("Bob"),
                new Gorilla("Zebbie"),
                new Gorilla("Author"),
                new Gorilla("Mickey"),
                new Gorilla("Howard"),
            };

            list.Sort();

            list.ForEach(a => Console.WriteLine(a));
        }

        public static void ExampleCode1()
        {
            // anonymous type
            var instance1 = new
            {
                FirstName = "Bob",
                LastName = "Howie",
                Age = 42,
                Height = 5.9,
                Weight = 149
            };

            Console.WriteLine(instance1);
            Console.WriteLine(instance1.GetType());
        }
    }
}
