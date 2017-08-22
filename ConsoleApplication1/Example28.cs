using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Example28
    {
        public static void ExampleCode1()
        {
            decimal dec = 0.3m;  // -- 128-bit with 15-16 digits  (money)  - exact values
            double dd = 0.3;     // --  64-bit with 28-29 digits  (calculations)  - approximate values
            float ff = 0.3f;     // -- 32-bit with 7 digit precision () - approximate values -- avoid using

            Console.WriteLine(dec);
            Console.WriteLine(dd);
            Console.WriteLine(ff);
        }

        public static void ExampleCode2()
        {
            string sentence = "this is a long sentence";

            Console.WriteLine(sentence);

            char[] chrarray = sentence.ToArray();

            Array.Reverse(chrarray);

            Console.WriteLine(new string(chrarray));
            
        }

        public static void ExampleCode3()
        {
            string rev1 = "";
            string rev2 = "";

            var revisions = 0;

            if (revisions > 0)
            {
                rev1 = "X";
                rev2 = "Y";
            }
            else if (string.IsNullOrEmpty(rev1) || string.IsNullOrEmpty(rev2)) // <=
            {
                Console.WriteLine("empty");
                return;
            }
        }

    }
}
