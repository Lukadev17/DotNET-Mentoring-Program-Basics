using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {

        private class Node
        {
            public T Value;
            public Node? Next;
            public Node? Prev;

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node? head;
        private Node? tail;
        private int length;

        public int Length => length;

        public void Add(T e)
        {
            var newNode = new Node(e);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            var newNode = new Node(e);

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null)
                {
                    head.Prev = newNode;
                }
                head = newNode;
                if (tail == null)
                {
                    tail = head;
                }
            }
            else if (index == length)
            {
                Add(e);
                return;
            }
            else
            {
                var current = GetNodeAt(index);
                var previous = current.Prev;

                newNode.Next = current;
                newNode.Prev = previous;

                if (previous != null)
                {
                    previous.Next = newNode;
                }
                current.Prev = newNode;
            }

            length++;
        }

        public T ElementAt(int index)
        {
            return GetNodeAt(index).Value;
        }

        public void Remove(T item)
        {
            var current = head;
            while (current != null)
            {
                if (Equals(current.Value, item))
                {
                    RemoveNode(current);
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            var node = GetNodeAt(index);
            var value = node.Value;
            RemoveNode(node);
            return value;
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!;
        }

        private void RemoveNode(Node node)
        {
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                head = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                tail = node.Prev;
            }

            length--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoublyLinkedListEnumerator : IEnumerator<T>
        {
            private Node? current;
            private readonly Node? start;

            public DoublyLinkedListEnumerator(Node? head)
            {
                start = head;
                current = null;
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = start;
                }
                else
                {
                    current = current.Next;
                }

                return current != null;
            }

            public void Reset()
            {
                current = null;
            }

            public void Dispose()
            {
            }
        }
    }
}
