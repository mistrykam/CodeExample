using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApplication1
{
    public class TestAttribute : Attribute  {}
    public class TestMethodAttribute : Attribute { }

    [Test]
    public class TestSuite
    {
        public void HelperMethod()
        {
            // help with the testing
            Console.WriteLine("TestSuite::HelperMethod...shouldn't get called by reflection.");
        }

        [TestMethod]
        public void MyTest1()
        {
            Console.WriteLine("TestSuite::doing some testing...1");
        }

        [TestMethod]
        public void MyTest2()
        {
            Console.WriteLine("TestSuite::doing some testing...2");
        }
    }

    public class Example24
    {
        public static void ExampleCode2()
        {
            // find the list of classes that have TestAttribute on them
            var testSuites =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
                select t;

            foreach(Type t in testSuites)
            {
                Console.WriteLine("Activator.CreateInstance::{0}", t.FullName);

                object instance = Activator.CreateInstance(t);

                var testMethods =
                    from m in t.GetMethods()
                    where m.GetCustomAttributes(false).Any(a => a is TestMethodAttribute)
                    select m;

                foreach (MethodInfo m in testMethods)
                {
                    Console.WriteLine("\tInvoke::{0}", m.Name);

                    m.Invoke(instance, null);
                }
            }
        }

        public static void ExampleCode1()
        {
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                Console.WriteLine(t.FullName);

                foreach(Attribute a in t.GetCustomAttributes(false))
                    Console.WriteLine("\t\tCustom Attribute");
            }
        }
    }
}
