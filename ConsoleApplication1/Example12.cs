using System;

namespace ConsoleApplication1
{
    public class Scooter
    {
        public int Mileage { get; set; }

        public static implicit operator Car(Scooter scooter)
        {
            return new Car() { Milage = scooter.Mileage };
        }
    }

    public class Car
    {
        public int Milage { get; set; }
    }

    public class Shape
    {
        public string Colour { get; set; }
    }

    public class Rectangle : Shape
    {
        public void Print()
        {
            Console.WriteLine("Rectangle print");
        }
    }

    public class Example12
    {
        public static void ExampleCode1()
        {
            Scooter scooter = new Scooter();

            Car car = scooter;

            Rectangle rectangle = new Rectangle();
            rectangle.Colour = "red";

            Console.WriteLine("Object is {0} and colour is {1}", rectangle.GetType().Name, rectangle.Colour);

            Shape shape = rectangle;

            Console.WriteLine("Object is {0} and colour is {1}", shape.GetType().Name, shape.Colour);

            // Rectangle r2 = (Rectangle)new Shape();  // this conversion will fail since a Shape can't be converted into a Rectangle (more specialized typed)

            bool randBool = new Random().Next() % 2 == 0;

            Console.WriteLine("Bool = {0}", randBool);

            Shape s2;

            if (randBool)
                s2 = new Rectangle();
            else
                s2 = new Shape();

            Rectangle r2 = null;

            if (s2 is Rectangle)     // this will work
                r2 = (Rectangle)s2;

            if (r2 != null)
                Console.WriteLine("Shape into Rectangle");
            else
                Console.WriteLine("Conversion was not allowed");

            r2 = s2 as Rectangle;  // the 'as' will try to convert it, if it can't then it returns null

            if (r2 != null)
                Console.WriteLine("Shape into Rectangle");
            else
                Console.WriteLine("Conversion was not allowed");
        }
    }
}