using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    interface ITree<T>
    {
        bool IsEmpty { get; }
        T Value { get; }
        ITree<T> Left { get; }
        ITree<T> Right { get; }
    }
    class Empty<T> : ITree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        public ITree<T> Left
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ITree<T> Right
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
    class Node<T> : ITree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return false;
            }
        }

        public ITree<T> Left
        {
            get; set;
        }

        public ITree<T> Right
        {
            get; set;
        }

        public T Value
        {
            get; set;
        }
        public Node(ITree<T> left, T value, ITree<T> right)
        {
            this.Left = left;
            this.Value = value;
            this.Right = right;
        }
    }
}