using System;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Main(string[] args)
        {
            // C# Review - August 2017

            Console.WriteLine("C# Coding Examples\n");

            /* Value Types */

            // ValueTypes.IntegerNumericTypes();
            // ValueTypes.FloatingPointNumericTypes();
            // ValueTypes.BooleanType();
            // ValueTypes.StructExample();
            // ValueTypes.EnumerationExample();

            /* Reference Types */

            // ReferenceTypes.ClassExample();
            // ReferenceTypes.DelegateExample();
            // ReferenceTypes.ObjectExample();
            // ReferenceTypes.DynamicExample();
            // ReferenceTypes.StringExample();
            // ReferenceTypes.StringBuilderExample();

            /* Statements: Selection */

            // StatementsControl.SelectionExample();
            // StatementsControl.IterationExample();
            // StatementsControl.JumpExample();

            /* Statements: Exceptions */

            // StatementExceptions.ThrowExample();
            // StatementExceptions.TryCatchExample();
            // StatementExceptions.TryCatchFinally();
            // StatementExceptions.Rethrow();
            // StatementsExceptions.UncheckedExample();

            /* Statements: Parameters */
            // StatementsParameters.ParamsExample();
            // StatementsParameters.RefExample();
            StatementsParameters.OutExample();


            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
