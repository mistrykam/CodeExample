using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Example08
    {
        public static void Goo(int a, int b, double c)
        {
            int item1 = 1;
            int item2 = 2;
            double item3 = 3.0D;

            a += item1;
            b += item2;
            c += item3;
        }

        public static void ExampleCode1()
        {
            int itemex1 = 10;
            int itemex2 = 20;
            double itemex3 = 30.0D;

            Goo(itemex1, itemex2, itemex3);
            Goo(itemex1, itemex2, itemex3);
            Goo(itemex1, itemex2, itemex3);
        }
    }
}
