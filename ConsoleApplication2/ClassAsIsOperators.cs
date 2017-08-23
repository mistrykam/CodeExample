using System;

namespace ConsoleApplication2
{
    class ClassAsIsOperators
    {
        /*  Operators
         *  
            Used to perform miscellaneous actions such as creating objects, checking the run-time type of an object, obtaining
            the size of a type, and other actions. 
            
            This section introduces the following keywords:

            as - Converts an object to a compatible type.
            is - Checks the run-time type of an object.
            
            
                        
            new - operator Creates objects (StringBuilder sb = new StringBuilder())            
            new - constraint Qualifies a type parameter.    -- class ItemFactory<T> where T : new()
         */

        internal class Animal
        {
            internal virtual void Speak()
            {
                Console.WriteLine("The Animal is speaking");
            }
        }

        internal class Dog : Animal
        {
            internal override void Speak()
            {
                Console.WriteLine("The Dog is speaking");
            }
        }

        /* as
           You can use the as operator to perform certain types of conversions between compatible reference types or nullable types.
           The as operator is like a cast operation. However, if the conversion isn't possible, as returns null instead of raising an exception.
         */

        public static void ConvertObjectExample()
        {
            Dog dog = new Dog();

            Console.WriteLine("Dog::{0}", dog.GetType());
            dog.Speak();

            // convert dog to animal
            Animal animal;

            animal = dog as Animal;  // still pointing the Dog class

            Console.WriteLine("Animal::{0}", animal.GetType());
            animal.Speak();
        }

        /* is
           The is keyword evaluates type compatibility at runtime. It determines whether an object instance or the result of
           an expression can be converted to a specified type. The is statement is true if expr is non-null and the object that results from
           evaluating the expression can be converted to type; otherwise, it returns false.          
         */

        public static void CheckObjectExample()
        {
            Dog dog = new Dog();
            Animal animal = new Animal();

            if (dog is Animal)
                Console.WriteLine("Dog is an Animal.");
            else
                Console.WriteLine("Dog is NOT an Animal.");

            if (animal is Dog)
                Console.WriteLine("Animal is an Dog.");
            else
                Console.WriteLine("Animal is NOT an Dog.");
        }
    }
}
