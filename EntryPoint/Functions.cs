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
        public static ITree<Vector2> specialBuildingsTree;
        public static List<List<Vector2>> SelectedSpecialBuildings = new List<List<Vector2>>();

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
        public static void createTree(Vector2[] specialBuildings)
        {
            specialBuildingsTree = new Empty<Vector2>() as ITree<Vector2>;
            populateTree(specialBuildings, 0, specialBuildings.Length, 0);
            Console.Write(specialBuildingsTree);
        }

        public static void populateTree(Vector2[] specialBuildings, int start, int end, int amount)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                specialBuildingsTree = insertInTree(specialBuildingsTree, specialBuildings[middle], start);
                populateTree(specialBuildings, start, middle, amount + 1);
                populateTree(specialBuildings, middle + 1, end, amount + 1);
            }
        }

        public static ITree<Vector2> insertInTree(ITree<Vector2> tail, Vector2 value, int counter)
        {
            if (tail.IsEmpty)
                return new Node<Vector2>(new Empty<Vector2>(), value, new Empty<Vector2>());

            if (tail.Value == value)
                return tail;

            if (counter % 2 == 0)
                if (value.X <= tail.Value.X)
                    return new Node<Vector2>(insertInTree(tail.Left, value, counter++), tail.Value, tail.Right);
                else
                    return new Node<Vector2>(tail.Left, tail.Value, insertInTree(tail.Right, value, counter++));

            else
                if (value.Y <= tail.Value.Y)
                    return new Node<Vector2>(insertInTree(tail.Left, value, counter++), tail.Value, tail.Right);
                else
                    return new Node<Vector2>(tail.Left, tail.Value, insertInTree(tail.Right, value, counter++));
        }
        public static void filterTree(IEnumerable<Tuple<Vector2, float>> housesAndDistances, ITree<Vector2> SpecialBuildingsTree)
        {
            if (SpecialBuildingsTree.IsEmpty)
                return;

            List<Vector2> filteredBuildingList = new List<Vector2>();

            foreach (var house in housesAndDistances)
            {
                if (calculateDistance(SpecialBuildingsTree.Value, house.Item1) <= house.Item2)
                {
                    filteredBuildingList.Add(SpecialBuildingsTree.Value);
                }
            }
            SelectedSpecialBuildings.Add(filteredBuildingList);

            filterTree(housesAndDistances, SpecialBuildingsTree.Left);
            filterTree(housesAndDistances, SpecialBuildingsTree.Right);
        }

        static bool searchNode(ITree<Vector2> tail, Vector2 value)
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
        static void printPreOrder<T>(ITree<T> tail)
        {
            if (tail.IsEmpty)
                return;
            Console.WriteLine(tail.Value);
            printPreOrder(tail.Left);
            printPreOrder(tail.Right);
        }
        static void printInOrder<T>(ITree<T> tail)
        {
            if (tail.IsEmpty)
                return;
            printInOrder(tail.Left);
            Console.WriteLine(tail.Value);
            printInOrder(tail.Right);
        }
        static void printPostOrder<T>(ITree<T> tail)
        {
            if (tail.IsEmpty)
                return;
            printPostOrder(tail.Left);
            printPostOrder(tail.Right);
            Console.WriteLine(tail.Value);
        }
    }
}
