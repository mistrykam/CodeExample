using System;

delegate int MyDelegate1(int x, int y);  // it's function pointer - but the CLR makes it into a class with a constructor
delegate void MyDelegate2(string name);

namespace ConsoleApplication2
{
    class Delegates
    {
        /* Delegates
         * 
           Are type-safe function pointers. 

           It's actually a class - synatax is converted into a class: 

            eg:
                delegate int MyFunc(int a, int b);
                int TheHanderMethod(int a, int b) { return a+b; }

                When assigning it a value, you write:
                    MyFunc = TheHandlerMethod;

                Which is the same-as:
                    MyFunc = new MyFunc(TheHandlerMethod);

           All delegate are multicast delegates.
         
           The declaration of a delegate type is similar to a method signature. It has a return value and any number of parameters of any type.

              public delegate void TestDelegate(string message);
              public delegate int TestDelegate(MyType m, long num);

           A delegate is a reference type that can be used to encapsulate a named or an anonymous method. Delegates are 
           similar to function pointers in C++; however, delegates are type-safe and secure.

           Delegates are the basis for Events.
           
           A delegate can be instantiated by associating it either with a named or anonymous method. For more information,
           see Named Methods and Anonymous Methods.

           The delegate must be instantiated with a method or lambda expression that has a compatible return type and input
           parameters. For more information on the degree of variance that is allowed in the method signature, see Variance
           in Delegates. For use with anonymous methods, the delegate and the code to be associated with it are declared
           together. Both ways of instantiating delegates are discussed in this section.

         */

        public class Calculator
        {
            public int Calc(int a, int b)
            {
                return a + b;
            }
        }

        public static void DelegateExample()
        {
            Calculator calculator = new Calculator();

            MyDelegate1 func1 = calculator.Calc;

            Console.WriteLine("Call the delegate func1 {0} + {1} = {2}", 100, 200, func1(100, 200));

            MyDelegate1 func2 = new MyDelegate1(calculator.Calc);

            Console.WriteLine("Call the delegate func2 {0} + {1} = {2}", 500, 600, func2(500, 600));

            MyDelegate1 func3 = (x, y) => x * y;

            Console.WriteLine("Call the delegate func3 {0} * {1} = {2}", 12, 13, func3(12, 13));   // anonymouse delegate

            MyDelegate1 func4 = (x, y) => { int a = x * y; return a + 100; };

            Console.WriteLine("Call the delegate func4 {0} * {1} + 100 = {2}", 12, 13, func3(12, 13));   // anonymouse delegate


            MyDelegate2 func5 = (x) => { Console.WriteLine("My name is {0}", x); };

            func5("Brenda Hamilton");
        }

        /* inject a logic into a class - open/closed principle */

        public delegate float PayTaxes(Employee employee);

        public class Employee
        {
            public string FullName { get; private set; }
            public int YearsOfExperience { get; private set; }
            public int Salary { get; private set; }

            PayTaxes PromtableCalc;

            public Employee(string fullName, int yearsOfExperience, int salary, PayTaxes promotable)
            {
                FullName = fullName;
                YearsOfExperience = yearsOfExperience;
                Salary = salary;
                PromtableCalc = promotable;
            }

            public void EmployeeTaxes()
            {
                Console.WriteLine("The employee taxes are {0:C2} on a salary of {1:C2}", PromtableCalc(this), Salary);
            }
        }

        public static void DelegateExtendingClassBehaviour()
        {
            Employee[] employees = new Employee[5];

            PayTaxes promotableDecider;

            promotableDecider = emp => (float)(emp.Salary * 0.25); // first tax calculator

            employees[0] = new Employee("Brenda", 10, 100000, promotableDecider);
            employees[1] = new Employee("Martha", 11, 90000, promotableDecider);
            employees[2] = new Employee("Julia", 12, 110000, promotableDecider);

            promotableDecider = emp => (float)(emp.Salary * 0.30); // updated tax calculator

            employees[3] = new Employee("Linda", 13, 140000, promotableDecider);
            employees[4] = new Employee("Sally", 14, 100000, promotableDecider);

            employees[0].EmployeeTaxes();
            employees[1].EmployeeTaxes();
            employees[2].EmployeeTaxes();
            employees[3].EmployeeTaxes();
            employees[4].EmployeeTaxes();
        }

        /* Multicast delegate example */

        internal delegate void MyDelegateMethod(string name);

        internal static void Method1(string name)
        {
            Console.WriteLine("Method1::{0}", name);
        }

        internal static void Method2(string name)
        {
            Console.WriteLine("Method2::{0}", name);
        }

        internal static void Method3(string name)
        {
            Console.WriteLine("Method3::{0}", name);
        }

        internal static void Method4(string name)
        {
            Console.WriteLine("Method4::{0}", name);
        }
       
        public static void MulticastDelegate()
        {
            MyDelegateMethod myDelegate;
            myDelegate = Method1;
            myDelegate += Method2;
            myDelegate += Method3;
            myDelegate += Method4;

            myDelegate("Jennifer Lawerence");
        }

        internal static void MyMethod(string name, MyDelegateMethod method)
        {
            method(name);
        }

        /* Delegate as a paramter */

        public static void DelegateAsAParameter()
        {
            MyMethod("Billy Rindle", Method1);
            MyMethod("Sally Rindle", Method2);

            // anonymous delegate methods - type get inferred

            MyMethod("Anon1 Delegate1", (string x) => Console.WriteLine(x));

            MyMethod("Anon2 Delegate2", (x) => Console.WriteLine(x));

        }
    }
}