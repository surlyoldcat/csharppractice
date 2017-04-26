using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork
{
    internal class TwoStackQueue<T>
    {
        private Stack<T> Innie = new Stack<T>();
        private Stack<T> Outie = new Stack<T>();

        public void Enqueue(T item)
        {
            Innie.Push(item);
        }

        public T Dequeue()
        {
            ProcessStacks();


            return Outie.Pop();
        }

        public T FrontOfQueue()
        {
            ProcessStacks();
            return Outie.Peek();
        }

        private void ProcessStacks()
        {
            if (Outie.Count == 0)
            {
                while (Innie.Count > 0)
                {
                    Outie.Push(Innie.Pop());
                }
            }

            if (Outie.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

        }
    }
}
