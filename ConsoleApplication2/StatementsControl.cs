using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class StatementsControl
    {
        /* Selection Statements
           A selection statement causes the program control to be transferred to a specific flow based 
           upon whether a certain condition is true or not.

               if
               if-else
               switch 

           switch(exp): In C# 6, the match expression must be an expression that returns a value of the following types:

            - char
            - string
            - bool
            - an integral value, such as an int or a long
            - enum value

         */

        public static void SelectionExample()
        {
            Random rand = new Random();

            int x = rand.Next(1, 100);
            int y = rand.Next(1, 100);

            Console.WriteLine("X = {0} Y = {1}", x, y);

            // if 
            if (x == y)
                Console.WriteLine("X and Y are the same value");

            // if else                       
            if (x > y)
                Console.WriteLine("X is greater than Y");
            else if (x < y)
                Console.WriteLine("Y is greater than X");
            else
                Console.WriteLine("X and Y are the same value");

            int z = rand.Next(1, 10);

            switch (z)
            {
                case 1:
                    Console.WriteLine("z in One");
                    break;
                case 2:
                    Console.WriteLine("z is Two");
                    break;
                case 3:
                    Console.WriteLine(" z is Three");
                    break;
                case 4:
                case 5:
                    Console.WriteLine("z is Four or Five");
                    break;
                default:
                    Console.WriteLine("z is larger than Five");
                    break;
            }
        }

        /*  Iteration Statements
            You can create loops by using the iteration statements. Iteration statements cause embedded statements to be
            executed a number of times, subject to the loop-termination criteria. These statements are executed in order,
            except when a jump statement is encountered.

            The following keywords are used in iteration statements:

                do-while
                for
                foreach            
                while         
         */

        public static void IterationExample()
        {
            int count = 0;

            // do-while
            do
            {
                Console.WriteLine("The value of count is {0}", count);
                count++;
            } while (count < 5);

            // for 
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("The value of i is {0}", i);
            }

            // foreach

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

            foreach(int j in list)
            {
                Console.WriteLine("The value of j is {0}", j);
            }

            // while

            count = 0;

            while (count < 5)
            {
                Console.WriteLine("The value of count = {0}", count);
                count++;
            }
        }

        /* Jump Statements
            Branching is performed using jump statements, which cause an immediate transfer of the program control. The
            following keywords are used in jump statements:

            break     - jump out of current statement block
            continue  - return to the top of the statement block
            goto      - AVOID
            return    - return to the caller from a method, can return a value
            throw     - signals the occurrence of an exception during program execution
         */

        public static void JumpExample()
        {
            int counter = 0;

            // break;

            do
            {
                if (counter > 5)
                    break;

                counter++;
            } while (true);

            Console.WriteLine("The value of counter is {0}", counter);

            // continue
            
            for (int i= 0; i < 10; i++)
            { 
                if (i % 2 == 0)
                    continue;

                Console.WriteLine("The value of i is {0}", i);
            }

            // return

            int x = (new Random()).Next(1, 10);

            if (x < 5)
            {
                Console.WriteLine("return");
                return;
            }
            else
            {
                Console.WriteLine("throw");
                throw new Exception("Throwing");
            }
        }
    }
}
