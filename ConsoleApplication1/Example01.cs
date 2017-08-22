using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Example01
    {
        public static void ExampleCode()
        {
            var count = 100000;

            var typeCode = count.GetTypeCode();

            Console.WriteLine("The type of variable is {0}", typeCode);

            Random rand = new Random();

            Console.WriteLine("The randonm number is {0}", rand.Next());

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The randonm number is {0}", rand.Next(0, 100));
            }


            int age = 25;

            bool canDrive = age >= 16 ? true : false;

            Console.WriteLine("{0} is old enough to drive: {0} {1}", age, canDrive);

            switch (age)
            {
                case 1:
                    Console.WriteLine("One");
                    break;

                default:
                    Console.WriteLine("Nothing");
                    break;
            }

            int counter = 0;

            while (counter < 15)
            {
                counter++;

                if (counter == 5)
                    continue;

                if (counter == 10)
                    break;

                if ((counter % 2) != 0)
                    Console.Write("odd - ");
                else
                    Console.Write("even - ");

                Console.WriteLine("counter = {0}", counter);

            }

            /*
            string myAge;
            
            do
            {
                Console.Write("What is your age: ");
                myAge = Console.ReadLine();

            } while (myAge != "18");
            */

            string sentence = "This is a sentence that I am writing.";

            foreach (char c in sentence)
            {
                Console.WriteLine(c);
            }

            for (int i = 0; i < sentence.Length; i++)
            {
                Console.WriteLine(sentence[i]);
            }

            Console.WriteLine("\'sentence\' starts at {0}", sentence.IndexOf("sentence"));

            List<string> items = sentence.Split(' ').ToList();

            foreach (var part in items)
                Console.WriteLine(part);

            Console.WriteLine("This string is null or empty? {0}", string.IsNullOrEmpty(sentence));

            string[] names = new string[1];
            string[] myList = new string[] { "One", "Two" };

            Console.WriteLine("{0}", string.Join(", ", myList));

            Console.WriteLine("{0:c} {1:000.000} {2:c} {3:c}", 1.11, 2.22, 3.33, 4.44, 5.55, 6.67);

        }
    }
}
