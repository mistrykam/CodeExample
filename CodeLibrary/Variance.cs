using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public class Base
    {
    }

    public class Derived : Base
    {
    }

    delegate Base FunctionReturnBase();
    delegate Derived FunctionReturnDerived();

    public static class Main
    {
        static Base FunctionBase() { return null; }
        static Derived FunctionDervived() { return null; }

        public static void test()
        {
            FunctionReturnBase b;
            FunctionReturnDerived d;

            b = FunctionBase;
            b = FunctionDervived;

         //   d = FunctionBase;          // no can do
            d = FunctionDervived;
        }

    }

}
