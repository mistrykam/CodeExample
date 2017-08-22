using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SynQueue<T>
    {
        private Queue<T> _Queue;

        public SynQueue()
        {
            _Queue = new Queue<T>();
        }

        public void EnQueue(T item)
        {
            _Queue.Enqueue(item);
        }

        public T DeQueue()
        {
            return _Queue.Dequeue();
        }

        public int Count
        {
            get { return _Queue.Count; }         
        }
    }


    public static class Example22
    {
        public static void ExampleCode1()
        {
            SynQueue<int> synQueue = new SynQueue<int>();

            synQueue.EnQueue(100);
        }
    }
}
