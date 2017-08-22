using System;
using System.Collections.Generic;

namespace CodeLibrary
{
    public class Listing<T>
    {
        T[] list = new T[5];

        int currentIndex = 0;

        public int CurrentLength { get { return currentIndex; } internal set { currentIndex = value; } }

        public void Add(T item)
        {
            if (currentIndex >= list.Length)
                ExpandList();

            list[currentIndex++] = item;
        }

        public T GetItem(int index)
        {
            if (index > list.Length)
                throw new IndexOutOfRangeException(string.Format("The array index was out of bounds, length = {0}", list.Length));

            return list[index];
        }

        private void ExpandList()
        {
            Console.WriteLine("---- Expanding list to {0}", list.Length + 10);

            T[] temp = new T[list.Length + 10];

            Array.Copy(list, temp, list.Length);

            list = temp;
        }
    }

    public class Example5
    {
        private static void PrintList<T>(Listing<T> thelist)
        {
            for (int i = 0; i < thelist.CurrentLength; i++)
            {
                Console.WriteLine("Listing[{0}] = {1}", i, thelist.GetItem(i));
            }
        }

        public static void ExampleCode1()
        {
            HashSet<string> hash = new HashSet<string>();

            hash.Add("A");
            hash.Add("A");  // hash cannot contain duplicate values, so this list will still just contain one value

            System.Collections.Generic.


            List<string> list = new List<string>();

            IEnumerable<string> enumerableList = list;

            Random rand = new Random();

            Listing<int> myListofIntegers = new Listing<int>();

            int size = 0;

            size = rand.Next(10, 25);

            for (int i = 0; i < size; i++)
            {
                myListofIntegers.Add(i * 2 + new Random().Next(1, 100) - +new Random().Next(50, 75));
            }

            PrintList<int>(myListofIntegers);

            size = rand.Next(10, 25);

            Listing<string> myListofStrings = new Listing<string>();

            for (int i = 0; i < size; i++)
            {
                myListofStrings.Add("Dog " + (i * 2 + new Random().Next(1, 100) - +new Random().Next(50, 75)));
            }

            PrintList<string>(myListofStrings);

        }
    }
}