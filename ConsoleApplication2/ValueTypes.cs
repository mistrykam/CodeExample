using System;

namespace ConsoleApplication2
{
    class ValueTypes
    {            
        /*  Value Type 

            -- C# has two type system: Value Type and Reference Type --
         
            - stored on the stack and Structs have fixed size       

                - Numerics - Precise Numbers (integers) | Approximate Numbers (floating point + decimal)
                - Enumeration

            NOTE: string and object are the other two built-in types

            - cannot store NULL value

            - const to declare a value that cannot change            
        
            - NOTE: With generics, a new type called Nullable<T> can make it null, short-hand ? 
                    eg. int? counter instead of Nullable<int> counter
               
            Stack - memory that is allocated using LIFO (Last in First Out) method.
                - when static variables are allocated they are pushed onto the stack
                - when they got out of scope they are pushed off the stack
                
            Default - each type has a type value, bool = false, numbers = 0 or struct = null 

        */

        public static void IntegerNumericTypes()
        {
            /* Integral Types: smallest to largest */

            sbyte   sbyteExample  = 127;            // -128 to 127 Signed 8 - bit integer
            byte    byteExample   = 200;            // 0 to 255    Unsigned 8 - bit integer
            char    charExample   = 'X';            // U+0000 to U+ffff    Unicode 16 - bit character  (char)88 or '\u0058' or '\x0058'
            short   shortExample  = 20000;          // -32,768 to 32,767   Signed 16 - bit integer
            ushort  ushortExample = 65000;          // 0 to 65,535 Unsigned 16 - bit integer
            int     intExample    = 39349393;       // -2,147,483,648 to 2,147,483,647 Signed 32 - bit integer
            uint    uintExample   = 83839392;       // 0 to 4,294,967,295  Unsigned 32 - bit integer
            long    longExample   = 3929292992992;  // -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 Signed 64 - bit integer
            ulong   ulongExample  = 34848393348483; // 0 to 18,446,744,073,709,551,615 Unsigned 64 - bit integer

            Console.WriteLine("{0}", sbyteExample);
            Console.WriteLine("{0}", byteExample);
            Console.WriteLine("{0}", charExample);
            Console.WriteLine("{0}", shortExample);
            Console.WriteLine("{0}", ushortExample);
            Console.WriteLine("{0}", intExample);
            Console.WriteLine("{0}", uintExample);
            Console.WriteLine("{0}", longExample);
            Console.WriteLine("{0}", ulongExample);
        }

        public static void FloatingPointNumericTypes()
        {
            /* Floating-Point Types: smallest to largest */

            float   floatExample = 123.134f;               // ±1.5e−45 to ±3.4e38 7 digits                                                System.Single
            double  doubleExample = 12393.229393d;         // ±5.0e−324 to ±1.7e308	15-16 digits                                          System.Double
            decimal decimalExample = 2388383939.39388392m; // (-7.9 x 1028 to 7.9 x 1028) / (100 to 1028)	28 - 29 significant digits    System.Decimal

            Console.WriteLine("{0}", floatExample);
            Console.WriteLine("{0}", doubleExample);
            Console.WriteLine("{0}", decimalExample);
        }

        public static void BooleanType()
        {
            /* Boolean
               It is used to declare variables to store the Boolean values, true and false.
               NOTE: No type conversion is allowed from bool to int
            */

            bool boolExample = true;

            Console.WriteLine("{0}", boolExample);
        }

        struct Points
        {
            public int x, y;

            public Points(int p1, int p2)
            {
                x = p1;
                y = p2;
            }

            public override string ToString()
            {
                return string.Format("Point X = {0} Point Y = {1}", x, y);
            }
        }

        public static void StructExample()
        {
            /* Struct
               A struct type is a value type that is typically used to encapsulate small groups of related variables, 
               such as the coordinates of a rectangle or the characteristics of an item in an inventory. 
               Structs can also contain constructors, constants, fields, methods, properties, indexers, operators, events, 
               and nested types, although if several such members are required, you should consider making your type a class instead.
               Structs can implement an interface but they cannot inherit from another struct. For that reason, struct members 
               cannot be declared as protected.
            */

            Points point;

            point.x = 10;
            point.y = 20;

            Console.WriteLine("Point {0} {1}", point.x, point.y);
            Console.WriteLine("Point {0}", point);

            // array of structs

            Points[] ListOfPoints = new Points[10];

            for (int i = 0; i < ListOfPoints.Length; i++)
            {
                ListOfPoints[i].x = i;
                ListOfPoints[i].y = i + 1;
            }

            for(int i = 0; i < ListOfPoints.Length; i++)
                Console.WriteLine("[{0}]::{1}" , i, ListOfPoints[i]);
        }

        enum enumExample
        {
            Item1,  // 0 by default
            Item2,
            Item3
        }; 

        public static void EnumerationExample()
        {
            /* Enueration
               The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants 
               called the enumerator list. Usually it is best to define an enum directly within a namespace so that 
               all classes in the namespace can access it with equal convenience. However, an enum can also be nested within a class or struct. 
               1 By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1.

                Every enumeration type is int. To integral type, such as byte, use a colon after the identifier followed by the type.
                For example: enum Days : byte {Sat=1, Sun, Mon, Tue, Wed, Thu, Fri};  
             */

            Console.WriteLine("{0} = {1}", (int)enumExample.Item1, enumExample.Item1);
            Console.WriteLine("{0} = {1}", (int)enumExample.Item2, enumExample.Item2);
            Console.WriteLine("{0} = {1}", (int)enumExample.Item3, enumExample.Item3);
        }
    }
}