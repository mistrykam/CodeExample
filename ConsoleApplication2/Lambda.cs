using System;

namespace ConsoleApplication2
{
    class Lambda
    {
        /*
         Lambda Expressions:

         A lambda expression is an anonymous function that you can use to create:

            delegates       --- inline method  eg: delegate (int k) { return k * k; };
                or 
            lambda expression --- use  => to indicate that's it's a lambda expression eg: (k) => ( k* k );
            
         types. 

         NOTE: The anonymous method will be converted by the compiler into a static method that is referenced.

         An anonymous function is an "inline" statement or expression that can be used wherever a delegate type is expected. 
         You can use it to initialize a named delegate or pass it instead of a named delegate type as a method parameter.                             

         Example:
         // Create a delegate
         delegate void MyDelegateFunc(int x);

         // Instantiate the delegate using an anonymous method.
         MyDelegateFunc d = delegate(int k) {  return k*k; };

         // can also be written as an "anonymous delegate" as:
         MyDelegateFunc d = (int k) { return k*k; };

         // or even simpler as: since the type and return value is inferred from the method signature
         MyDelegateFunc d = (k) { k*k; };


         By using lambda expressions, you can write local functions that can be passed as arguments or returned 
         as the value of function calls. Lambda expressions are particularly helpful for writing LINQ query expressions.

         Example:
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };  
            int oddNumbers = numbers.Count(n => n % 2 == 1);  

        Func:
            It takes zero or more input parameter ans returns a value.

            Func<TResult>              Has one result value, no parameter.
            Func<T, TResult>           Has one result value, one parameter.
            Func<T1, T2, TResult>      Has one result value, two parameters.

        Action:
            It takes zero or more input parameters and returns nothing.

            Action<T>           Has one result value, one parameter.
            Action<T1, T2>      Has one result value, two parameters.

        Predicate:

            Predicate is a function pointer for method which returns boolean value. They are commonly used for iterating a 
            collection or to verify if the value does already exist. 

            Predicate<in T>

         */

        delegate int MyDelegateFunc(int x);

        public static void SimpleExample()
        {
            // Instantiate the delegate using an anonymous method.
            MyDelegateFunc d1 = delegate (int k) { return k * k; };

            // can also be written as an "anonymous delegate" as:
            MyDelegateFunc d2 = (int k) => { return k * k; };

            // or even simpler as: since the type and return value is inferred from the method signature
            MyDelegateFunc d3 = (k) => ( k* k );
        }

        public static void BuiltInLambda()
        {

        }
    }
}
