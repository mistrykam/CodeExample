using System;

namespace ConsoleApplication2
{
    class ClassAccessModifers
    {
        /* Class Access Modifer
            #--------------------------------------------#

            public - The type or member can be accessed by any other code in the same assembly or another assembly that references it.
            
            private - The type or member can be accessed only by code in the same class or struct.
            
            protected - The type or member can be accessed only by code in the same class or struct, or in a class that is derived from that class.
            
            internal - The type or member can be accessed by any code in the same assembly, but not from another assembly.
            
            protected internal - protected (dervived class) _or_ internal (within the assembly)

                NOTE: Protected: derived within the same assembly or another assembly
         
            #--------------------------------------------#
                     
            partial - Defines partial classes, structs and methods throughout the same assembly.
         
            sealed - Specifies that a class cannot be inherited.

            #--------------------------------------------#

            abstract - Indicates that a class is intended only to be a base class of other classes, on a method what the signature looks like.

            virtual - Indicates that a method, property, indexer, or event declaration and allow for it to be overridden in a derived class

            override - Provides a new implementation of a virtual member inherited from a base class.
                     
            #--------------------------------------------#

            static - Declares a member that belongs to the type itself instead of to a specific object. Global variable.

            readonly - A field that can only be assigned values as part of the declaration or in a constructor in the same class

            const - Specifies that the value of the field or the local variable cannot be modified.

            #--------------------------------------------#
         */

        public abstract partial class Person       // means it has to be en inherited
        {
            readonly int number1 = (new Random()).Next(1, 10000);
            readonly int number2;
            const int number3 = 10100101;

            static int number4 = (new Random()).Next(1, 10000);

            public Person()
            {                
                number2 = 99999;
            }

            public abstract void AbstractMethod(); // cannot have a body

            private void PrivateMethod()
            {
                Console.WriteLine("PrivateMethod()");
            }

            protected void ProtectedMethod()
            {
                Console.WriteLine("ProtectedMethod()");
            }

            internal void InternalMethod()
            {
                Console.WriteLine("InternalMethod()");
            }

            protected internal void ProtectedInternalMethod()
            {
                Console.WriteLine("ProtectedInternalMethod()");
            }

            public void PublicMethod()
            {
                Console.WriteLine("PublicMethod()");
            }
        }

        public partial class Person
        {
            public void AnotherBoringMethod()
            {
                Console.WriteLine("AnotherBoringMethod()");
            }
        }

        public sealed class Employee : Person
        {   
            public override void AbstractMethod()
            {
                Console.WriteLine("Employee.AnotherBoringMethod()");
            }
        }

        public static void ClassExample()
        {
            // Person person = new Person();  <---- cannot new an abstract class

            Employee employee = new Employee();

            employee.AbstractMethod();            
            employee.InternalMethod();
            employee.ProtectedInternalMethod();
            employee.PublicMethod();

            employee.AnotherBoringMethod();
        }
    }
}
