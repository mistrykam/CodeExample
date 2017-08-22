using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class StatementsExceptions
    {
        /* Exception Handling Statements
            C# provides built-in support for handling anomalous situations, known as exceptions, which may occur during the
            execution of your program. These exceptions are handled by code that is outside the normal flow of control.

            The following exception handling topics are explained in this section:

            throw               - Signals the occurrence of an exception during program execution
            try-catch           - catch the exception
            try-finally         - finally will alway execute
            try-catch-finally   - catch and handle the exception and then execute the finally block

            NOTE: Within a catch block, a single throw, will re-throw the exception and the stack exception trace is preserved
                  If the exception is thrown with a new exception the call-stack is lost.
        */

        public static void ThrowExample()
        {
            throw new ArgumentNullException();
        }

        public static void TryCatchExample()
        {
            int a = 100;
            int b = 0;

            try
            {
                Console.WriteLine("Divide {0}", a/b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide By Zero Exception {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown {0}", ex.Message);
            }
        }

        public static void TryCatchFinally()
        {
            try
            {
                throw new ApplicationException("The application is broken");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("Application Exception {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception occurred {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally statement was called");
            }
        }

        public static void Rethrow()
        {
            try
            {
                try
                {
                    throw new ApplicationException("The application made an exception");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\tCatch\n");
                    Console.WriteLine("Exception occurred {0}", ex.ToString());

                    // throw ex;  // this will discard the original call stack and you will lose the line number that threw the execption

                    throw;     // this will keep the original call stack

                    // throw new ApplicationException("Busted", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\tHandler\n");
                Console.WriteLine(ex.ToString());

                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.ToString());
            }
        }

        /* Checked/Unchecked
         The checked keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions.

        The unchecked keyword is used to suppress overflow-checking for integral-type arithmetic operations and conversions.
         */

        public static void UncheckedExample()
        {
            const long x = long.MaxValue;

            long result = unchecked(x * 2);

            Console.WriteLine("The value is {0}", result);
        }

    }
}
