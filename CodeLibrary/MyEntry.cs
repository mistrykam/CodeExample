using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public class MyEntry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public MyEntry() { }

        public MyEntry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public void DisplayEntry()
        {
            Console.WriteLine("Key = {0} Value = {1}", Key, Value);
        }
    }
}
