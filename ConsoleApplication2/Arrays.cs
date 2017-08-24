using System;

namespace ConsoleApplication2
{
    class Arrays
    {
        /* Arrays
          
            An array has the following properties:

            - An array can be Single-Dimensional, Multidimensional or Jagged.

            - The number of dimensions and the length of each dimension are established when the array instance is created. 
              These values can't be changed during the lifetime of the instance.

            - The default values of numeric array elements are set to zero, and reference elements are set to null.

            - A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to null.

            - Arrays are zero indexed: an array with n elements is indexed from 0 to n-1.
            
            - Array elements can be of any type, including an array type.

            - Array types are reference types derived from the abstract base type Array. Since this type implements IEnumerable and IEnumerable<T>, 
              you can use foreach iteration on all arrays in C#.                     
         */

        public static void SingleArrayExample()
        {
            // single dimensional array
            int[] integers = new int[10];

            integers[0] = 0;
            integers[1] = 1;
            integers[2] = 2;
            integers[3] = 3;
            integers[4] = 4;
            integers[5] = 5;
            integers[6] = 6;
            integers[7] = 7;
            integers[8] = 8;
            integers[9] = 9;

            foreach (int x in integers)
                Console.Write("{0} ", x);

            Console.WriteLine();

            for (int i = 0; i < integers.Length; i++)
                Console.Write("{0} ", integers[i]);

            Console.WriteLine();
        }

        class Person
        {
            public string FirstName { get; private set; }
            public string LastName { get; private set; }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public override string ToString()
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public static void MultiDimensionArrayExample()
        {
            Person[,] persons = new Person[2, 5];

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 5; j++)
                    persons[i, j] = new Person("Jules" + i, "Richardson" + j);

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 5; j++)
                    Console.WriteLine("[{0},{1}] = {2}", i, j, persons[i, j]);

            int[,] array2D = new int[2, 3] { { 1, 2, 3 }, { 11, 22, 33 } };

            Console.WriteLine("array 2D lengths");

            Console.WriteLine(array2D.GetLength(0));
            Console.WriteLine(array2D.GetLength(1));

            int[,,] array3D = new int[,,] { { { 1, 2 } } };

            Console.WriteLine("array 3D lengths");

            Console.WriteLine(array3D.GetLength(0));
            Console.WriteLine(array3D.GetLength(1));
            Console.WriteLine(array3D.GetLength(2));
        }

        public static void JaggedArrayExample()
        {
            // arrays of array

            int[][] jagged = new int[3][];

            jagged[0] = new int[3] { 1, 2, 3 };
            jagged[1] = new int[4] { 4, 5, 6, 7 };
            jagged[2] = new int[5] { 8, 9, 10, 11, 12 };

            for (int i = 0; i < jagged.GetLength(0); i++)
            {
                foreach (var item in jagged[i])
                    Console.Write(item);

                Console.WriteLine();
            }
        }
    }
}
