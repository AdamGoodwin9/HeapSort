using System;
using System.Collections.Generic;
using System.Text;

namespace HeapSort
{
    class Heap<T> where T : IComparable
    {
        private T[] heap;
        private readonly bool max;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public Heap(bool max = true, int capacity = 10)
        {
            this.max = max;
            Capacity = capacity;
            heap = new T[Capacity];
            Count = 0;
        }

        public void Add(T element)
        {
            if (Count == Capacity)
            {
                Capacity *= 2;

                T[] temp = new T[Capacity];

                for (int i = 0; i < heap.Length; i++)
                {
                    temp[i] = heap[i];
                }
                temp[heap.Length] = element;
                heap = temp;
            }
            else
            {
                heap[Count] = element;
            }
            Count++;
            HeapifyUp(Count - 1);
        }

        public T Pop()
        {
            T temp = heap[0];
            heap[0] = heap[Count - 1];
            heap[Count - 1] = default(T);
            Count--;
            HeapifyDown(0);
            return temp;
        }

        public void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            bool parentIsLess = heap[parentIndex].CompareTo(heap[index]) < 0;

            if ((parentIsLess && max) || (!parentIsLess && !max))
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;

                HeapifyUp(parentIndex);
            }

        }

        public void HeapifyDown(int index)
        {
            int leftChild = (index * 2) + 1;
            int rightChild = leftChild + 1;

            if (leftChild >= Count)
            {
                return;
            }

            if (rightChild >= Count)
            {
                bool leftIsBigger = heap[leftChild].CompareTo(heap[index]) > 0;
                if ((leftIsBigger && max) || (!leftIsBigger && !max))
                {
                    T temp = heap[index];
                    heap[index] = heap[leftChild];
                    heap[leftChild] = temp;
                }
                return;
            }

            bool biggerThanBothChildren = heap[index].CompareTo(heap[leftChild]) > 0 && heap[index].CompareTo(heap[rightChild]) > 0;
            if ((biggerThanBothChildren && max) || (!biggerThanBothChildren && !max))
            {
                return;
            }

            bool leftBiggerThanRight = heap[leftChild].CompareTo(heap[rightChild]) > 0;
            if ((leftBiggerThanRight && max) || (!leftBiggerThanRight && !max))
            {
                T temp = heap[index];
                heap[index] = heap[leftChild];
                heap[leftChild] = temp;
                HeapifyDown(leftChild);
            }
            else
            {
                T temp = heap[index];
                heap[index] = heap[rightChild];
                heap[rightChild] = temp;
                HeapifyDown(rightChild);
            }
        }

        public void Print()
        {
            int row = 1;
            int col = 1;
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < 5 - row; j++)
                {
                    Console.Write("    ");
                }
                Console.Write(heap[i]);
                if (col >= (int)Math.Pow(2, row - 1))
                {
                    Console.WriteLine();
                    col = 1;
                    row++;
                }
                else
                {
                    col++;
                }
            }
        }
    }
}