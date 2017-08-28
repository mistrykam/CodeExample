using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApplication2
{
    class AttributeDecorators
    {
        /* Attributes
         
           Attributes provide a way of associating information with code in a declarative way. They can also provide a 
           reusable element that can be applied to a variety of targets. 

           After an attribute is associated with a program entity, the attribute can be queried at run time by using a 
           technique called reflection. 

               [Obsolete]
               public class MyClass { ... }

               [Obsolete("This class is obsolete, use another class")]
               public class MyClass {  }
           
           Each "declaration" on an attribute, can be thought of as a call to a constructor to a class. 

           Parameters to an attribute constructor are limited to simple types/literals: bool, int, double, string, Type, enums, etc and 
           arrays of those types. You can not use an expression or a variable. You are free to use positional or named parameters.

           An C#, attributes are classes that inherit from the Attribute base class.

           Any class that inherits from Attribute can be used as a sort of "tag" on other pieces of code.
           
           Attributes can be placed on classes and methods.
           
           Creating an attribute is as simple as inheriting from the Attribute base class:
           
               public MySpecialAttribute : Attribute  { ... }  

           I can use [MySpecial] attribute on a class or on method:

               [MySpecial]
               public class MyClass { ... }                    
         */

        class SampleAttribute : Attribute  // simple attribute
        {
            public string Name { get; set; }
            public int Version { get; set; }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor)]  // only allow on classes or contructors
        class AnotherAttribute : Attribute
        {

        }

        [Sample(Name = "Telsa Model", Version = 3)]
        class Car
        {
            [Sample]
            public int ModelNumber { get; set; }
        }

        public static void AttributeExample()
        {
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.GetCustomAttributes<SampleAttribute>().Count() > 0
                        select t;

            foreach (var item in types)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
