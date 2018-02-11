using System;
using DataLibrary;

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

            /* Generics */

            // Generics

            /* Generic Collection */
            // GenericCollections.CollectionExample();

            /* Yield */

            // YieldKeyword.SimpleExample();
            // YieldKeyword.PrintListExample();
            // YieldKeyword.PrintNumbers();

            /* Extension Methods */

            // ExtensionMethods.ExtensionMethodExample();

            /* Attributes */

            // AttributeDecorators.AttributeExample();

            /* Reflection */

            // Reflection.SimpleExample();
            // Reflection.AssemblyExample();
            // Reflection.ExecuteClassExample();

            /* Delegates */

            // Delegates.DelegateExample();
            // Delegates.DelegateExtendingClassBehaviour();
            // Delegates.MulticastDelegate();
            // Delegates.DelegateAsAParameter();

            /* Class: Events */

            // ClassEvent.EventExample();

            /* Lambda Expressions */
            // Lambda.SimpleExample();

            /* LINQ */

            // LINQExpressions.SimpleExample();
            // LINQExpressions.SelectionExample();
            // LINQExpressions.IEnumerablevsIQueryable();
            // LINQExpressions.MinMaxExample();
            // LINQExpressions.SelectManyExample();
            // LINQExpressions.TakeSkipExample();
            // LINQExpressions.GroupByExample();

            /* Threading */

            // Threading.SimpleExample();
            // Threading.ConflictThread();
            // Threading.NoConflictThread();
            // Threading.ThreadJoinExample();      

            /* Task Parallel Library */

            // TaskParallelLibrary.TaskExample();
            // TaskParallelLibrary.TaskContinueWithExample();
            // TaskParallelLibrary.ParallelForExample();
            // TaskParallelLibrary.ParallelForEachExample();

            /* Asyn Await */

            // AsyncAwait.NotAsyncExample();
            // AsyncAwait.AsyncExample();

            /* Entity Framework */

            // See the C:\Users\Kam\Documents\Visual Studio 2015\Projects\VideoStoreWebApplication

            // This does not work - library reference fails
            //DataLibrary.VideoStore.AddVideo(1, "Finding Nemo", "Clown fish loses his son and goes looking for him.");
            //DataLibrary.VideoStore.GetAllVideos();


            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
