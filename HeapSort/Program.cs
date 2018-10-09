using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap<int> heap = new Heap<int>(false);

            Random r = new Random();

            for (int i = 0; i < 15; i++)
            {
                int num = r.Next(100) + 1;
                Console.Write(num + " ");
                heap.Add(num);
            }
            Console.WriteLine("\n");
            heap.Print();
            Console.WriteLine("\n");

            for (int i = 0; i < 15; i++)
            {
                Console.Write(heap.Pop() + " ");
            }

            Console.ReadKey();
        }
    }
}