using System;
using System.Reflection;

namespace ConsoleApplication2
{
    class Reflection
    {
            
        /*  Reflection
         
            Reflection provides objects (of type Type) that describe assemblies, modules and types. You can use 
            reflection to dynamically create an instance of a type, bind the type to an existing object, or get 
            the type from an existing object and invoke its methods or access its fields and properties. If you are 
            using attributes in your code, reflection enables you to access them.          

            var assembly = Assembly.GetExecutingAssembly();  // get information about the current executing assembly

        */

        public static void SimpleExample()
        {
            // get type information about an instance variable
            int counter = 100;

            // runtime operator
            Type t = counter.GetType();
            Console.WriteLine(t.Name);

            // Using Reflection to get information from an Assembly:  
            Assembly info = typeof(System.Int32).Assembly;
            Console.WriteLine(info);
        }

        public static void AssemblyExample()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // fully qualified name of the Assemby
            Console.WriteLine(assembly.FullName);
            // Returns: ConsoleApplication2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

            // get the types in the assembly
            var types = assembly.GetTypes();

            foreach(var t in types)
            {
                Console.WriteLine(t.FullName);

                if (t.BaseType != null)
                    Console.WriteLine("\t" + t.BaseType.FullName);
                    
                // get all the methods for the type and print it out
                foreach (var m in t.GetMethods())
                {
                    Console.WriteLine("\t Method::{0}", m.Name);
                }
            }
        }

        public static void ExecuteClassExample()
        {
            Arrays arrayObj = new Arrays();


            var arrayType = typeof(Arrays);

            var myMethod = arrayType.GetMethod("MultiDimensionArrayExample");

            myMethod.Invoke(arrayObj, null);
        }
    }
}
