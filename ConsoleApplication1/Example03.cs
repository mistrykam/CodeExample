using CodeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ConsoleApplication1
{
    public delegate T GetSome<T>(T one, T two);


    public class ForkLift
    {
        public Action MyProperty1 { get; set; }

        public Action<int, int> MyProperty2 { get; set; }

        public int EngineSize { get; set; }

        int? x = null;

        MyNullable<int> y = null;

        public ForkLift()
        {
            x = 1;
            x++;
            y = new MyNullable<int>();
        }
    }

    public class Shape<T>  
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public Shape() { }

    }

    public class PrintResult
    {
        public void DisplayShape<T>(Shape<T> item) 
        {
            Console.WriteLine(item.Success);
            Console.WriteLine(item.Data);
        }
    }

    public class Example03
    {
        public enum TaskState
        {
            [Description("Stopping Task")]
            Stopped = 1,

            Starting = 2,
            Stopping = 3,
            Failed = 4
        }

        public struct Customer
        {
            public string FirstName;
            public string LastName;
            public DateTime BirthDate;

            public int MyProperty { get; set; }

            public int CalculateAge()
            {
                DateTime today = DateTime.Now;

                int age = today.Year - BirthDate.Year;

                DateTime monthDay = new DateTime(today.Year, BirthDate.Month, BirthDate.Day);

                if (monthDay > today)
                    age -= 1;

                return age;
            }

           
        }

        public static void ExampleCode1()
        {
            MyEntry<int, string> entry = new MyEntry<int, string>();

            entry.Key = 1;
            entry.Value = "Dog";

            List<MyEntry<int, string>> listMyEntries = new List<MyEntry<int, string>>();

            listMyEntries.Add(new MyEntry<int, string>(1, "First"));
            listMyEntries.Add(new MyEntry<int, string>(2, "Second"));
            listMyEntries.Add(new MyEntry<int, string>(3, "Third"));
            listMyEntries.Add(new MyEntry<int, string>(4, "Fourth"));
            listMyEntries.Add(new MyEntry<int, string>(5, "Fifth"));

            foreach (var item in listMyEntries)
            {
                item.DisplayEntry();
            }
        }

        public static void ExampleCode2()
        {
            TaskState task1 = TaskState.Starting;
            Console.WriteLine("Task State = {0}", task1);

            TaskState task2 = TaskState.Stopping;
            Console.WriteLine("Task State = {0}", task2);

            Customer customer = new Customer();

            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.BirthDate = DateTime.Parse("12/29/1972");

            Console.WriteLine("You were born in {0:d} and are {1} years old today.", customer.BirthDate, customer.CalculateAge());

            Type custType = customer.GetType();

            Console.WriteLine(custType);
        }

        /// <summary>
        /// Delegate Example
        /// </summary>
        public static void ExampleCode3()
        {
            GetSome<int> pointer = delegate (int one, int two)
            {
                string name = "some name";

                name = name.ToUpper();

                return one + two;
            };

            Console.WriteLine("{0} + {1} = {2}", 10, 20, pointer(10, 20));
        }

        /// <summary>
        /// Lambda expression
        /// </summary>
        public static void ExampleCode4()
        {
            Func<int, int, decimal> someMethod = (x, y) => x + y;

            Action<int, int> anotherMethod = (x, y) =>
            {
                string myName = "John Doe";

                myName.ToLower();

                int z = (int)Math.Pow(x, 10) + y;
            };

            decimal result = someMethod(10, 12);

            Console.WriteLine("{0} + {1} = {2}", 10, 12, result);

            anotherMethod(1, 2);
        }

        public static void ExampleCode5()
        {
            List<int> myNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> oddNumbers = myNumbers.Where(x => (x % 2) == 1).ToList();

            Console.WriteLine("My numbers " + string.Join(", ", myNumbers));
            Console.WriteLine("My odd numbers " + string.Join(", ", oddNumbers));
        }

        public static void ExampleCode6()
        {
            CodeLibrary.MyNullable<int> x = new CodeLibrary.MyNullable<int>(1);

            Console.WriteLine("Has Value " + x.HasValue);
            
        }
    }
}
