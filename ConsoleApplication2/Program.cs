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

            /* Arrays */
            // Arrays.SingleArrayExample();
            // Arrays.MultiDimensionArrayExample();
            // Arrays.JaggedArrayExample();

            /* Statements: Exceptions */

            // StatementExceptions.ThrowExample();
            // StatementExceptions.TryCatchExample();
            // StatementExceptions.TryCatchFinally();
            // StatementExceptions.Rethrow();
            // StatementsExceptions.UncheckedExample();

            /* Statements: Parameters */
            // StatementsParameters.ParamsExample();
            // StatementsParameters.RefExample();
            // StatementsParameters.OutExample();

            /* Class: As Is */
            //ClassAsIsOperators.ConvertObjectExample();
            //ClassAsIsOperators.CheckObjectExample();

            /* Class: New Base This */
            // ClassBaseNewThisOperators.NewHidingExample();
            // ClassBaseNewThisOperators.BaseExample();
            // ClassBaseNewThisOperators.ThisExample();
            // ClassBaseNewThisOperators.IndexerExample();

            /* Class: Access Modifers */
            // ClassAccessModifers.ClassExample();

            /* Delegates */
            // Delegates.DelegateExample();
            // Delegates.DelegateExtendingClassBehaviour();
            // Delegates.MulticastDelegate();

            /* Class: Events */
            // ClassEvent.EventExample();

            /* Task Parallel Library */
            // TaskParallelLibrary.TaskExample();
            TaskParallelLibrary.TaskContinueWithExample();

            // TaskParallelLibrary.ParallelForExample();
            //TaskParallelLibrary.ParallelForEachExample();

            /* Asyn Await */
            // AsyncPattern.AsyncExample();

            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
