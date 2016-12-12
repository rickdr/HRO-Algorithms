using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    class Functions
    {
        public Vector2[] Buildings { get; set; }
        public Vector2 House { get; set; }

        /* Assignment 1 */
        public void MergeSort(int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeSort(start, middle);
                MergeSort(middle + 1, end);

                Merge(start, middle, end);
            }
        }

        private void Merge(int start, int middle, int end)
        {
            int left = middle - start + 1;
            int right = end - middle;
            Vector2[] leftArray = new Vector2[left + 1];
            Vector2[] rightArray = new Vector2[right + 1];

            for (int i = 0; i < left; i++)
                leftArray[i] = Buildings[start + i];

            for (int i = 0; i < right; i++)
                rightArray[i] = Buildings[middle + i + 1];

            int leftCount = 0;
            int rightCount = 0;

            for (int i = start; i <= end; i++)
            {
                if (calculateDistance(leftArray[leftCount], House) <= calculateDistance(rightArray[rightCount], House))
                {
                    Buildings[i] = leftArray[leftCount];
                    leftCount++;
                }
                else
                {
                    Buildings[i] = rightArray[rightCount];
                    rightCount++;
                }
            }
        }

        static float calculateDistance(Vector2 pos1, Vector2 pos2)
        {
            var disx = Math.Pow((pos1.X - pos2.X), 2);
            var disy = Math.Pow((pos1.Y - pos2.Y), 2);
            var res = Math.Sqrt((disx + disy));
            return (float)res;
        }
        /* Assignment 2 */

        public static IBinaryTree<int> insertToTree(IBinaryTree<int> tail, int value)
        {
            if (tail.IsEmpty)
                return new Node<int>(new Empty<int>(), value, new Empty<int>());
            if (tail.Value == value)
                return tail;
            if (value < tail.Value)
                return new Node<int>(insertToTree(tail.Left, value), tail.Value, tail.Right);
            else
                return new Node<int>(tail.Left, tail.Value, insertToTree(tail.Right, value));
        }
        static bool searchNode(IBinaryTree<int> tail, int value)
        {
            if (tail.IsEmpty)
                return false;
            else
            {
                if (tail.Value == value)
                    return searchNode(tail.Left, value);
                else
                    return searchNode(tail.Right, value);
            }
        }
        static void printPreOrder<T>(IBinaryTree<T> tail)
        {
            if (tail.IsEmpty)
                return;
            Console.WriteLine(tail.Value);
            printPreOrder(tail.Left);
            printPreOrder(tail.Right);
        }
        static void printInOrder<T>(IBinaryTree<T> tail)
        {
            if (tail.IsEmpty)
                return;
            printInOrder(tail.Left);
            Console.WriteLine(tail.Value);
            printInOrder(tail.Right);
        }
        static void printPostOrder<T>(IBinaryTree<T> tail)
        {
            if (tail.IsEmpty)
                return;
            printPostOrder(tail.Left);
            printPostOrder(tail.Right);
            Console.WriteLine(tail.Value);
        }
    }
}
