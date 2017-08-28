using System;

namespace ConsoleApplication2
{
    // we have class that is sealed or we cannot modify it 

    sealed class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    /* create a static class 
          with a static method 
          where _this_ passed into the method of the type to extend */

    static class MyExtensions
    {
        public static int Age(this Person person)
        {
            return DateTime.Now.Year - person.DateOfBirth.Year;
        }
    }

    class ExtensionMethods
    {
        /*  Extension Methods
         
            Extension methods enable you to "add" methods to existing types without creating a new derived type, recompiling, or 
            otherwise modifying the original type. Extension methods are a special kind of static method, 
            but they are called as if they were instance methods on the extended type. For client code written in C# and Visual Basic, 
            there is no apparent difference between calling an extension method and the methods that are actually defined in a type.              

            Extension methods are defined as static methods but are called by using instance method syntax. Their first parameter 
            specifies which type the method operates on, and the parameter is preceded by the this modifier. Extension 
            methods are only in scope when you explicitly import the namespace into your source code with a using directive.         
         */

        public static void ExtensionMethodExample()
        {
            Person person = new Person() { FirstName = "Debra", LastName = "Himla", DateOfBirth = new DateTime(1982, 8, 23) };

            Console.WriteLine("The {0} {1} is {2}", person.FirstName, person.LastName, person.Age());
        }
    }
}
