using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[] { 6, 3, 5, 20, 84, 1, 2, 49, 29, 99, 38, 12, 18 };
            Write("I:", Array);
            MergeSort(Array, 0, Array.Length - 1);
            Write("O:", Array);
            Console.ReadLine();
        }

        private static void MergeSort(int[] Array, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeSort(Array, start, middle);
                MergeSort(Array, middle + 1, end);
                Merge(Array, start, middle, end);
            }
        }

        private static void Merge(int[] Array, int start, int middle, int end)
        {
            int left = middle - start + 1;
            int right = end - middle;
            int[] leftArray = new int[left + 1];
            int[] rightArray = new int[right + 1];

            for (int i = 0; i < left; i++)
                leftArray[i] = Array[start + i];

            for (int i = 0; i < right; i++)
                rightArray[i] = Array[middle + i + 1];

            leftArray[left] = Int32.MaxValue;
            rightArray[right] = Int32.MaxValue;
            int leftCount = 0;
            int rightCount = 0;

            for (int i = start; i <= end ; i++)
            {
                if(leftArray[leftCount] <= rightArray[rightCount])
                {
                    Array[i] = leftArray[leftCount];
                    leftCount++;
                } else
                {
                    Array[i] = rightArray[rightCount];
                    rightCount++;
                }
            }
        }

        private static void Write(string prefix, int[] array)
        {
            Console.Write(prefix + " ");
            foreach (var item in array)
            {
                Console.Write(item.ToString() + ", ");
            }
            Console.WriteLine();
        }

        public string returnPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
