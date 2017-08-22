using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Extensions
    {
        public static DateTime Combined(DateTime datePart, DateTime timePart)
        {
            return new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second);
        }


        public static DateTime AddTime(this DateTime datePart, DateTime timePart)
        {
            return new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second);
        }

        public static void GooIt(this int y)
        {
            var x = y;
        }

    }

    public class Example16
    {
        public static void ExampleCode1()
        {
            DateTime datePart = new DateTime(2016, 12, 31);
            DateTime timePart = new DateTime(0001, 1, 1, 11, 59, 59);

            Console.WriteLine(datePart);
            Console.WriteLine(timePart);

            DateTime combinedDate = Extensions.Combined(datePart, timePart);

            Console.WriteLine(combinedDate);

            combinedDate = datePart.AddTime(timePart);

            Console.WriteLine(combinedDate);

            combinedDate = Extensions.AddTime(datePart, timePart);

            int w = 0;

            w.GooIt();

        }
    }
}
