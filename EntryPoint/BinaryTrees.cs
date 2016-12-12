using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    interface IBinaryTree<T>
    {
        bool IsEmpty { get; }
        T Value { get; }
        IBinaryTree<T> Left { get; }
        IBinaryTree<T> Right { get; }
    }
    class Empty<T> : IBinaryTree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        public IBinaryTree<T> Left
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IBinaryTree<T> Right
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
    class Node<T> : IBinaryTree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        public IBinaryTree<T> Left
        {
            get; set;
        }

        public IBinaryTree<T> Right
        {
            get; set;
        }

        public T Value
        {
            get; set;
        }
        public Node(IBinaryTree<T> left, T value, IBinaryTree<T> right)
        {
            this.Left = left;
            this.Value = value;
            this.Right = right;
        }
    }
}
