using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> storage = new();

        public T Dequeue()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException();

            return storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            storage.Add(item); 
        }

        public T Pop()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException();

            return storage.RemoveAt(0);
        }

        public void Push(T item)
        {
            storage.AddAt(0, item); 
        }
    }
}
