using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ConsoleApplication2
{
    class GenericCollections
    {
        /* Generic Collections
         
           Generic Collections implement:

           IEnumerable<T>	- This interface is required by foreach statements. This interface defines a method GetEnumerator() 
                              that returns an Enumerator that implements the IEnumerator interface.
                
           IList<T>	        - For accessing values from an index. This interface defines an indexer and provides a facility to 
                              insert and insert elements from a specific location using InsertAt(), RemoveAt() methods. This interface is 
                              derived from ICollection<T>.

           ICollection<T>	- Is implemented by a generic type of collection classes. Using this you can 
                              access the number of items in a collection using a Count property. Using Remove (), Add (), Clear () 
                              and CopyTo () methods you can remove, add collection elements, and copy to an array.

                  
           The following generic types correspond to existing collection types:

           List<T> is the generic class that corresponds to ArrayList.

           Dictionary<TKey,TValue> and ConcurrentDictionary<TKey,TValue> are the generic classes that correspond to Hashtable.
           
           Collection<T> is the generic class that corresponds to CollectionBase. Collection<T> can be used as a base class, 
           but unlike CollectionBase, it is not abstract. This makes it much easier to use.
           
           ReadOnlyCollection<T> is the generic class that corresponds to ReadOnlyCollectionBase. ReadOnlyCollection<T> is not abstract, 
           and has a constructor that makes it easy to expose an existing List<T> as a read-only collection.

           The Queue<T>, ConcurrentQueue<T>, Stack<T>, ConcurrentStack<T>, and SortedList<TKey,TValue> generic classes correspond to the 
           respective nongeneric classes with the same names.           
          
         */

        public static void CollectionExample()
        {
            int item;

            List<string> list = new List<string>();

            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.RemoveAt(2);

            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            Collection<int> collection = new Collection<int>();

            ReadOnlyCollection<int> readOnlyCollection = new ReadOnlyCollection<int>(new List<int>() { 1,2,3 }) ;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            item = queue.Dequeue();

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            item = stack.Pop();

            SortedDictionary<int, string> sortedDistionary = new SortedDictionary<int, string>();
        }
    }

}
