using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApplication1
{
    public static class Example17
    {
        public static bool FilterLargerThan(int item, int minimum)
        {
            return item > minimum;
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> list, Func<T, int, bool> filter, int minimum)
        {
            foreach (var item in list)
            {
                if (filter(item, minimum))
                    yield return item;
            }
        }

        public static void ExampleCode1()
        {
            int[] x = { 1, 2, 3, 4, 5 };
            int[] y = new int[5] { 1, 2, 3, 4, 5 };

            int[] listOfNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            IEnumerable<int> result1 = from number in listOfNumbers
                                       where number > 5
                                       select number;

            // IQueryable<int> iq = null;

            Console.WriteLine();

            foreach (var item in result1)
                Console.WriteLine(item);

            // IEnumerable<int> result2 = listOfNumbers.Where((int n) => { return n > 5; }).Select(n => n);
            IEnumerable<int> result2 = listOfNumbers.Where(n => n > 5).Select(n => n);
            IEnumerable<int> result2a = listOfNumbers.Where(n => n > 5);  // same as result2

            Console.WriteLine();

            foreach (var item in result2)
                Console.WriteLine(item);

            //IEnumerable<int> result3 = Enumerable.Select(Enumerable.Where(listOfNumbers, n => n > 5), n => n);
            IEnumerable<int> result3 = Enumerable.Select(MyWhere(listOfNumbers, FilterLargerThan, 5), n => n);

            Console.WriteLine();

            foreach (var item in result3)
                Console.WriteLine(item);
        }

        public static void ExampleCode2()
        {
            Func<int, bool> myFunction1 = i => i > 5;
            Expression<Func<int, bool>> myFunction2 = j => j > 6;

            Console.WriteLine(myFunction2.Body);

        }

    }
}
