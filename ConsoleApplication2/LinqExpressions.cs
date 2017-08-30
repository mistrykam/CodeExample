using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{
    class LINQExpressions
    {
        /* LINQ - Language Integrated Query
         
            LINQ provides language-level querying capabilities and a higher-order function API to C# and VB as a way to write 
            expressive, declarative code.

            LINQ is nothing but the collection of extension methods for classes that implements IEnumerable and IQueryable interface. 
            System.Linq namespace includes the necessary classes & interfaces for LINQ. Enumerable and Queryable are two main 
            static classes of LINQ API that contain extension methods.

            IEnumerable<T> - Exposes the enumerator, which supports a simple iteration over a collection of a specified type.
                           - good for in-memory collections

            IQueryable<T> - Provides functionality to evaluate queries against a specific data source wherein the type of the data is known.
                          - good for services such as SQL

            IEnumberable will expect a delegate of type Func<> | Action<> | Predicate<>
                --> converts the lambda expression into code at compiled time
                                                        =====================
                                                     
            IQueryable will expect an expression of Expression<Func<> | Action<> | Predicate<>>
                --> converts the lambda expression into data-objects not code at compiled time
                --> the data-objects are represented as a binary-tree
                --> then at run-time the data-objects are interpreted  (for example into SQL statements)

            Both support deferred execution.

            Expression<T> - is expression tree provides a method of translating executable code into data-objects, converts the lambda statement
                            into parsed data-objects.  Normally, a lambda statement is converted into C# code.

                https://blogs.msdn.microsoft.com/charlie/2008/01/31/expression-tree-basics/


            Different Libraries:

            LINQ to Objects
            LINQ to XML
            LINQ to Entities  (Entity Framework)            
            ...
            LINQ to <data source>  - data source needs to implement IQueryable interface
            
         */

        public static void SimpleExample()
        {
            string text = "This is a very long sentence about nothing much in particular";

            IEnumerable<char> vowels = from c in text.ToLower()
                                       where c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                                       orderby c descending
                                       select c;

            // same as above
            vowels = text.Where(c => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u').OrderByDescending(c => c);

            Console.WriteLine(vowels.ToArray());

            IEnumerable<IGrouping<char, char>> groupVowels = from c in text.ToLower()
                                                             where c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                                                             group c by c;

            foreach (var item in groupVowels)
            {
                Console.WriteLine("{0} by {1}", item.Key, item.Count());
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public IList<string> Subjects { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} {2}", FirstName, LastName, Age);
            }
        }

        private static List<Student> listOfStudents = new List<Student>()
                        {
                            new Student() { FirstName = "Jill", LastName = "Smith", Age = 18, Subjects = new List<string>() { "Math", "Accounting", "Biology", "English" } },
                            new Student() { FirstName = "Jennifer", LastName = "Kolina", Age = 17, Subjects = new List<string>() { "Engineering", "Science", "Biology" } },
                            new Student() { FirstName = "Susan", LastName = "Mac", Age = 25, Subjects = new List<string>() { "Arts", "Science", "Biology" } },
                            new Student() { FirstName = "Minnie", LastName = "Driver", Age = 34, Subjects = new List<string>() { "Math", "Computers", "Physic", "Accounting" } },
                            new Student() { FirstName = "Debra", LastName = "Tonie", Age = 25, Subjects = new List<string>() { "Art", "Painting", "English" } },
                            new Student() { FirstName = "Helen", LastName = "Gomez", Age = 29, Subjects = new List<string>() { "History", "Art"} },
                            new Student() { FirstName = "Samantha", LastName = "Brow", Age = 18, Subjects = new List<string>() { "Gym", "Math", "English" } }
                        };


        public static void SelectionExample()
        {

            // order by example

            var listOfVoters = from p in listOfStudents
                               where p.Age >= 19
                               orderby p.FirstName
                               select p;

            foreach (Student student in listOfVoters)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            // group by example

            var groupByAge = from p in listOfStudents
                             orderby p.Age
                             group p by p.Age;

            foreach (var group in groupByAge)
            {
                Console.WriteLine("Age {0} appears {1} time(s)", group.Key, group.Count());

                foreach (var person in listOfStudents.Where(p => p.Age == group.Key))
                {
                    Console.WriteLine("\t {0}", person);
                }
            }
        }

        public static void IEnumerablevsIQueryable()
        {
            int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10 };

            IEnumerable<int> filter1 = list.Where(p => p > 10);

            // same as the list above - Where is just an extension method
            IEnumerable<int> filter2 = Enumerable.Where(list, p => p > 10);

            // IEnumberable will expect a delegate of type Func<T,..>
            // converts the lambda expression into code

            // IQueryable will expect an expression of Expression<Func<T,...>>
            // converts the lambda expression into objects not code            

        }

        public static void MinMaxExample()
        {
            int[] listOfNumbers = new int[] { 113, 52, 73, 84, 5, 96, 7, 78, 10 };

            Console.WriteLine("Min {0}", listOfNumbers.Min());
            Console.WriteLine("Max {0}", listOfNumbers.Max());

            // get the smallest string length

            string[] listOfStrings = new string[] { "France", "England", "Germany", "Sweden", "Italy" };

            // find the string with the smallest length
            var result = (from s in listOfStrings
                          orderby s.Length
                          select s).First();

            Console.WriteLine("Min {0} ", result);

            // find the min / max of the list
            Console.WriteLine("Min {0} ", listOfStrings.Min());
            Console.WriteLine("Max {0} ", listOfStrings.Max());
        }

        public static void GroupByExample()
        {
            var group = from s in listOfStudents
                         group s by s.Age;

            foreach(var g in group)
            {
                Console.WriteLine("Age:" + g.Key + " -- Number of Students " + g.Count());

                foreach (var item in g)
                {
                    Console.WriteLine("    {0} {1}", item.FirstName, item.LastName);
                }
            }
        }

        public static void SelectManyExample()
        {
            IEnumerable<IList<string>> students = listOfStudents.Select(p => p.Subjects);

            foreach (var student in students)
            {
                foreach(var subject in student)
                    Console.WriteLine(subject);
            }

            Console.WriteLine();
            
            // SelectMany will create a flatten a list
            var list = listOfStudents.SelectMany(p => p.Subjects);

            foreach(var subjects in list)
            {
                 Console.WriteLine(subjects);
            }                        
        }

        public static void TakeSkipExample()
        {
            var results = (from s in listOfStudents
                           select s).Skip(2).Take(3);

            foreach (var student in results)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }                          
        }

    }
}
