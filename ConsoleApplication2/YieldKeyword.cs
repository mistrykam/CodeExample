using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class YieldKeyword
    {
        /* Yield
         
           Yield allows each iteration in a foreach-loop be generated only when needed - against a collection that 
           implements IEnumerator<T> .

           The following example shows the two forms of the yield statement:

                yield return <expression>;  
                yield break; 
         
           You use a 'yield return <expression>' statement to return each element one at a time.

                for (int i = 0; i < 10; i++)
                {
                    result = result * number;
                    yield return result;
                }                    
         */

        static IEnumerable<int> CalcExponent(int x, int y)
        {
            int result = 1;

            for (int index = 1; index <= y; index++)
            {
                result = result * index;
                yield return result;
            }
        }

        public static void SimpleExample()
        {
            var result = CalcExponent(10, 10);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static Random rand = new Random();

        static IEnumerable<int> GetRandomNumber(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return rand.Next(1, 100);
            }
        }

        public static void PrintNumbers()
        {
            var list = GetRandomNumber(12);

            foreach(int n in list)
                Console.WriteLine(n);
        }

        internal class Person
        {
            internal string FirstName { get; set; }
            internal string LastName { get; set; }
            internal int Age { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} {2}", FirstName, LastName, Age);
            }
        }

        static IEnumerable<Person> GetPerson()
        {
            List<Person> personList = new List<Person>()
                                    {
                                        new Person() { FirstName = "Jill", LastName = "Wong", Age = 10 },
                                        new Person() { FirstName = "Bob", LastName = "Frank", Age = 13 },
                                        new Person() { FirstName = "Kim", LastName = "Frank", Age = 13 },
                                        new Person() { FirstName = "Susan", LastName = "Frank", Age = 13 },
                                        new Person() { FirstName = "Mona", LastName = "Frank", Age = 13 }
                                    };

            foreach (Person person in personList)
            {
                yield return person;
            }
        }

        public static void PrintListExample()
        {
            foreach (var person in GetPerson())
            {
                Console.WriteLine(person);
            }
        }
    }
}
