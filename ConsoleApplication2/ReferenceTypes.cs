using System;
using System.Text;

namespace ConsoleApplication2
{
    class ReferenceTypes
    {
        /*  Reference Type 
         
            -- C# has two type system: Value Type and Reference Type --        
          
            - stored on the heap and have variable size
            - created using the "new" keyword
            - the type "string" is a special reference type
            -   Each reference type 
            -   Has a "sync block root" field
            -   Pointer to it's type defintion 
            -   Pointer to it's location on the heap
                
            Heap - for dynamic memory allocation
                - memory is allocated for the intance of the object and a pointer to it returned
                - when the object is destoryed the memory is deallocated by the Garbage collector
        
            The following keywords are used to DECLARE reference types:
                - class
                - interface
                - delegate

            C# also provides the following BUILT-IN reference types:
                - string    
                - dynamic
                - object
        */

        /* Access Modifer
         
            All types and type members have an accessibility level, controls usage in your assembly or other assemblies. 

            Public
                The type or member can be accessed by any other code in the same assembly or another assembly that references it.
            
            Private
                The type or member can be accessed only by code in the same class or struct.
            
            Protected
                The type or member can be accessed only by code in the same class or struct, or in a class that is derived from that class.
            
            Internal
                The type or member can be accessed by any code in the same assembly, but not from another assembly.
            
            Protected internal
                Within a derived class in another assembly or by any code in the assembly in which it is declared. 
                Access from another assembly must take place within a class declaration that derives from the class 
                in which the protected internal element is declared, and it must take place through an instance of 
                the derived class type.        
         */

        /*
           Interface 
               An interface contains only the signatures of methods, properties, events or indexers. A class or struct 
               that implements the interface must implement the members of the interface that are specified in the 
               interface definition. In the following example, class ImplementationClass must implement a method named 
               SampleMethod that has no parameters and returns void.
         */

        interface IHouse
        {
            // method
            string GetCustomerName(int Id);

            // property
            int MyProperty { get; set; }

            // event
            event EventHandler MyEventHandler;

            // indexer            
            string this[int index] { get; set; }
        }

        /* Class
                Classes are declared using the keyword class and can have an access modifier of Public or Internal.
                Classes are Internal by default.
                Class members, including nested classes, can be public, protected internal, protected, internal, or private. 
                Members are private by default.
                Only single inheritance is allowed in C# (one base class)
                A Class can implement more than one interface.

                - None
                    class ClassA { }
                -Single
                    class DerivedClass : BaseClass { }
                - None, implements two interfaces 
                    class ImplClass : IFace1, IFace2 { }
                - Single, implements one interface    
                    class ImplDerivedClass : BaseClass, IFace1 { }

                Class can contain:

                    Constructors  - creation
                    Finalizers    - removal

                    Constants     - data
                    Fields
                    Properties          
                                                  
                    Methods       - action or function  
                    
                    Indexers      - collections
                    Operators     - calculation and comparison
                    
                    Events        - subscriber
                    Delegates     - pointer
                    
                    Interfaces    - data structure
                    Structs
                    Classes
         */

        public class BaseClass
        {
            public BaseClass()
            {
                Console.WriteLine("Created base class");
            }

            protected int GetNumber()
            {
                return new Random().Next(1, 100);
            }

            public void DisplayNumber()
            {
                Console.WriteLine("The number is {0}", GetNumber());
            }
        }

        public class DerivedClass : BaseClass
        {
            public DerivedClass()
            {
                Console.WriteLine("Created derived class");
            }
        }

        public static void ClassExample()
        {
            DerivedClass cl = new DerivedClass();

            cl.DisplayNumber();
        }

        /* Delegate
                The declaration of a delegate type is similar to a method signature. It has a return value and any number of
                parameters of any type.

                A delegate is a referencetypethat can be used to encapsulatea named or an anonymous method. Delegates are
                similar to function pointers in C++; however, delegates aretype-safeand secure
         */

        public delegate void TestDelegateA(string message);   // think of this as class/struct declaration
        public delegate long TestDelegateB(int m, int num);        public void Hello(string message)
        {
            Console.WriteLine("Hello {0}", message);
        }        public long Adder(int a, int b)
        {
            return a + b;
        }        public static void DelegateExample()
        {
            ReferenceTypes rt = new ReferenceTypes();

            TestDelegateA delegateA = rt.Hello;   // assign it value
            TestDelegateB delagateB = rt.Adder;

            delegateA("world");                   // invoke it
            long result = delagateB(100, 200);
            Console.WriteLine("Result = {0}", result);
        }
        public static void StringExample()
        {
            /* string 
             - The string type represents a sequence of zero or more Unicode characters. string is an alias for String in the .NET Framework.
             - Strings are immutable, the contents of a string object cannot be changed after the object is created
             - The [] operator can be used for readonly access to individual characters of a string
             - String literals can contain any character literal. Escape sequences are included. 
             - The following example uses escape sequence \\ for backslash, \u0066 for the letter f, and \n for newline.
             - Verbatim string literals start with @ and are also enclosed in double quotation marks. @"c:\Docs\Source\a.txt"             
             */

            string mystring = string.Format("The current date and time is {0}", DateTime.Now);

            Console.WriteLine(mystring);

            for (int i = 0; i < mystring.Length; i++)
            {
                Console.WriteLine("{0}", mystring[i]);
            }

            if (string.IsNullOrEmpty(mystring))
                Console.WriteLine("The string is empty");
            else
                Console.WriteLine("The string has a value");
        }

        public static void StringBuilderExample()
        {
            /* StringBuilder
             - String operations in .NET are highly optimized and in most cases do not significantly impact performance. 
             - However, in some scenarios such as tight loops that are executing many hundreds or thousands of times, string 
               operations can affect performance. The StringBuilder class creates a string buffer that offers better performance 
               if your program performs many string manipulations. The StringBuilder string also enables you to reassign individual 
               characters, something the built-in string data type does not support. 
             */

            StringBuilder myStringBuider = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                myStringBuider.AppendLine("Hello World");
            }

            Console.WriteLine(myStringBuider);
        }

        /* Object         
            In the unified type system of C#,all types, predefined and user-defined, reference types and value types, 
            inherit directly or indirectly from Object. You can assign values of any type to variables of type object.
            
            BOX and UNBOXING

            When a variable of a value type is converted to object, it is said to be boxed.
            When a variable of type object is converted to a value type, it is said to be unboxed.            When the CLR boxes a value type, it wraps the value inside a System.Object and stores it on the managed heap.         
         */

        class MyClass
        {
            int x = 100;

            public void Display()
            {
                Console.WriteLine("The value of x is {0}", x);
            }
        }

        public static void ObjectExample()
        {
            object a = new MyClass();
            MyClass b = new MyClass();

            ((MyClass)a).Display();

            b.Display();

            // box / unboxing

            int x = 10000;
            object y;

            // box
            y = x;
            Console.WriteLine("BOXING: The variable x put onto the heap {0}", y);

            // unboxing
            int z = (int)y;
            Console.WriteLine("UNBOXING: The variable x copied from the heap {0}", z);
        }

        /* Dynamic    
            The dynamic type enables the operations in which it occurs to bypass compile-time type checking. Instead, these
            operations areresolved at run time.
            
            Type dynamic behaves like type object in most circumstances. However, operations that contain expressions of
            type dynamic are not resolved or type checked by the compiler. The compiler packages together information
            about the operation,and that information is later used to evaluate the operation at run time. As part of the process,
            variables of type dynamic are compiled into variables of type object .Therefore, type dynamic exists only at
            compile time, not at run time.        


            NOTE: var vs dynamic, var the type is determined at compile time, whereas dynamic is at runtime.
         */

        public static void DynamicExample()
        {
            object myObject;
            dynamic myDynamic;

            myObject = "string";
            myDynamic = "string";

            Console.WriteLine("Object type = {0}", myObject.GetType());
            Console.WriteLine("Dynamic type = {0}", myDynamic.GetType());
        }
    }
}
