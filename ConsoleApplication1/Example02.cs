using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Example02
    {
        interface IShape
        {
            double CalculateArea();

            T Display<T>(T viewport);
        }

        class Rectangle : IShape
        {
            private float _length;
            private float _width;

            private Rectangle() { }

            public Rectangle(float length, float width)
            {
                _length = length;
                _width = width;
            }

            public T Process<T>(T arguments)
            {
                return default(T);
            }

            public virtual double CalculateArea()
            {
                return _length * _width;
            }

            public T Display<T>(T viewport)
            {
                Console.WriteLine("Display port {0}", viewport);

                return viewport;
            }

            public static Rectangle operator +(Rectangle rect1, Rectangle rect2)
            {
                Rectangle addedRect = new Rectangle();

                addedRect._length = rect1._length + rect2._length;
                addedRect._width = rect1._width + rect2._width;

                return addedRect;
            }
        }

        public static void ExampleCode1()
        {
            StringBuilder sb = new StringBuilder();
            string sentence = "";

            int duration = 50000;

            Console.WriteLine("{0} -- START", DateTime.Now);

            for (int i = 0; i < duration; i++)
                sb.Append("string");

            Console.WriteLine("{0} -- END", DateTime.Now);


            Console.WriteLine("{0} -- START", DateTime.Now);

            for (int i = 0; i < duration; i++)
                sentence += "string";

            Console.WriteLine("{0} -- END", DateTime.Now);
        }

        public static void ExampleCode2()
        {
            int[] grades = new int[] { 1, 1, 1, 10, 1, 1, 1, 1 };

            int[] marks = { 1, 1, 1, 1, 1, 1, 1, 1 };

            int[] items;

            items = new int[] { 1, 2, 3 };

            int location = Array.IndexOf(grades, 10);

            Console.WriteLine("lenght of the array {0}", grades.Length);
            Console.WriteLine("lenght of the array {0}", marks.Length);
            Console.WriteLine("location {0}", location);

            int[,] mult = new int[5, 5];


            mult = new int [5, 5] 
                {
                    { 1,2,3,4,5 },
                    { 10,2,3,4,5 },
                    { 100,2,3,4,5 },
                    { 1000,2,3,4,5 },
                    { 10000,2,3,4,5 },
                };

            for (int i = 0; i < mult.GetLength(0); i++)
                for (int j = 0; j < mult.GetLength(1); j++)
                    Console.WriteLine("{0} {1} = {2}", i,j, mult[i,j]);

            int[][] arrayof = new int[2][]
                    {
                        new int[] {1,2,3 },
                        new int[] {1,2,3,4,5 },
                    };

            Console.WriteLine("lenght of the array {0}", mult.GetLength(0));
            Console.WriteLine("lenght of the array {0}", mult.GetLength(1));
        }

        public static void ExampleCode3()
        {
            List<int> myList1 = new List<int>(new int[] { 1, 2, 43, 4 });

            foreach(var item in myList1)
            {
                Console.WriteLine(item);
            }

            int location = myList1.IndexOf(43);

            Console.WriteLine("Location of 43 is {0}", location);

            Console.WriteLine("Contains {0}", myList1.Contains(2));

            List<string> nameList = new List<string>(new string[]{ "Tom", "Jerry", "Fred", "Mark" });

            Console.WriteLine("Find /'tom/' {0}", nameList.Contains("tom", StringComparer.OrdinalIgnoreCase));

            Console.WriteLine("Unsorted:: {0}", string.Join(", ", nameList));


            nameList.Sort();

            Console.WriteLine("Sorted:: {0}", string.Join(", ", nameList));

        }

        public static void ExampleCode4()
        {
            try
            {
                int divider;
                double result = 0;

                Console.Write("Enter a number to divide 10.0 by: ");
                if (int.TryParse(Console.ReadLine(), out divider))
                {
                    result = 10 / divider;
                }

                Console.Write("10 / {0} = {1} ", divider, result);

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Exception Type: {0}", ex.GetType().Name);
                Console.WriteLine("Divide by zero exception occurred: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Type: {0}", ex.GetType().Name);
                Console.WriteLine("General Exception occurred: {0}", ex.Message);
            }
        }


        public class Animal
        {
            private static int _counter = 0;

            public string Name { get; set; }
            public string Sound { get; set; }
            public int Height { get; set; }

            private float _weight;

            public float Weight
            {
                get { return _weight; }
                set { _weight = value; }
            }

            public void FeedMe(int item1 = 1, int item2 = 10)
            {
                _weight += item1 + item2;
            }

            public static int GetCreationCount()
            {
                return _counter;
            }

            public override string ToString()
            {
                return Name;
            }

            public Animal()
            {
                Console.WriteLine("Calling Animal default constructor.");

                _weight = 0;
                _counter++;
            }

            public Animal(string myName) : this()
            {
                Console.WriteLine("Calling Animal(string myName) constructor.");
                Name = myName;
            }

            public Animal(string myName, string mySound)
            {
                Console.WriteLine("Calling Animal(string myName, string mySound) constructor.");
                Name = myName;
                Sound = mySound;
                _counter++;
            }

        }

        public class Dog : Animal
        {
            public Dog() : base("other")
            {
                Console.WriteLine("Calling dog default constructor.");
            }

            public Dog(string myName, string mySound)
            {
                Console.WriteLine("Calling Dog(string myName, string mySound) constructor.");
                Name = myName;
                Sound = mySound;
            }

        }

        public static void CreateAnimals()
        {
            /*
            Animal animal1 = new Animal();

            animal1.Name = "Bunny";

            Console.WriteLine("Animal : {0}", animal1.ToString());
            Console.WriteLine("Creation Count : {0}", Animal.GetCreationCount());
            animal1.FeedMe(100);

            ///

            Animal animal2 = new Animal("Bird") { Height = 1, Weight = 2, Sound = "Tweet, Tweet" };

            Console.WriteLine("Animal : {0}", animal2.ToString());
            Console.WriteLine("Creation Count : {0}", Animal.GetCreationCount());

            animal2.FeedMe(100, 200);

            ///
            

            Animal animal3 = new Animal("Duck", "Quack, Quack");
            Console.WriteLine("Animal : {0}", animal3.ToString());
            Console.WriteLine("Creation Count : {0}", Animal.GetCreationCount());
            */
            ///

            Dog dog = new Dog("Dog", "barf, barf");

            dog.FeedMe(1, 2);

            Console.WriteLine("Animal : {0}", dog.ToString());
            Console.WriteLine("Creation Count : {0}", Animal.GetCreationCount());
        }

        public static void ExampleCode5()
        {
            IShape shape1 = new Rectangle(10.0F, 20.3F);
            IShape shape2 = new Rectangle(5.0F, 17.3F);

            Console.WriteLine("Area of the Rectangle-1 is {0} ", shape1.CalculateArea());
            Console.WriteLine("Area of the Rectangle-2 is {0} ", shape2.CalculateArea());

            Rectangle shape3 = (Rectangle)shape1 + (Rectangle)shape2;

            Console.WriteLine("Area of the Rectangle-3 is {0} ", shape3.CalculateArea());

            string result = shape3.Process<string>("list");

            int out1 = shape1.Display<int>(1);
            int out2 = shape2.Display<int>(2);

        }
    }
}
