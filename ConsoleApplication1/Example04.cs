using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate bool FilterMethod(int item);

    public class Example04
    {
        static void First(int item) { Console.WriteLine("Hello 1 " + item); }
        static void Second(int item) { Console.WriteLine("Hello 2 " + item);  }
        static void Third(int item) { Console.WriteLine("Hello 3 " + item); }

        static Action<int> Fourth = item => { Console.WriteLine("Hello 4 " + item); };
        static Action<int> Fifth  = item => { Console.WriteLine("Hello 5 " + item); };
        static Action<int> Sixth  = item => { Console.WriteLine("Hello 6 " + item); };

        static Action<int> myDelegates;

        public static void CallMyDelegates()
        {
            myDelegates = null;

            myDelegates += (Action<int>)First + Second + Third;
            myDelegates += (Action<int>)Fourth + Fifth + Sixth;

            try
            {
                myDelegates(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message: {0}", ex.Message);
            }

        }

        Func<int, bool> myFunct1 = (int x) => { return x > 0; };

        Func<int, bool> myFunct2 = (int x) => 
        {
            x++;
            x = x + 10;
            return x > 0;
        };

        Func<int, bool> myFunct3 = x => x > 0;


        // Closure example

        static Action GiveMeAction()
        {
            int i = 0;

            return new Action(() => i++);
        }

        static void TestAction()
        {
            Action a = GiveMeAction();
            Action b = GiveMeAction();
            a(); b(); a(); b(); a(); b();
        }



        //public static IEnumerable<int> FilterList(IEnumerable<int> list, FilterMethod filter)
        public static IEnumerable<int> FilterList(IEnumerable<int> list, Func<int, bool> filter)
        {
            foreach (var item in list)
            {
                if (filter(item))
                    yield return item;
            }
        }

        private static bool GreaterThan5(int item)
        {
            return item > 5;
        }
        
        private static bool LessThan100(int item)
        {
            return item < 100;
        }

        private static bool EqualTo4(int item)
        {
            return item == 4;
        }

        public static void TestFilterList()
        {
            FilterMethod method = null;

            method += GreaterThan5;

            foreach (var item in method.GetInvocationList())
                Console.WriteLine("[1] {0}", item.Method);

            method += LessThan100;

            foreach (var item in method.GetInvocationList())
                Console.WriteLine("[2] {0}", item.Method);

            method += EqualTo4;

            foreach (var item in method.GetInvocationList())
                Console.WriteLine("[3] {0}", item.Method);


            Console.WriteLine("method(100) {0}", method(100));

            IEnumerable<int> list = new[] { 4, 34, 56, 6, 4, 2, 4, 567, 4, 3, 3 };

            foreach (var item in FilterList(list, GreaterThan5))
            {
                Console.WriteLine("GreaterThanFive:: {0}", item);
            }

            foreach (var item in FilterList(list, LessThan100))
            {
                Console.WriteLine("LessThan100:: {0}", item);
            }

            foreach (var item in FilterList(list, n => { n--; return n > 2; }))
            {
                Console.WriteLine("n--; n > 2:: {0}", item);
            }

            foreach (var item in FilterList(list, n => n > 2))
            {
                Console.WriteLine("n > 2:: {0}", item);
            }
        }
    }
}
