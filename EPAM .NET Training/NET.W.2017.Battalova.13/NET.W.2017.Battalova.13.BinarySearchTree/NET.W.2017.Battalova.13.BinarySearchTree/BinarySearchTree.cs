using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Battalova._13.BinarySearchTree
{

    internal sealed class TreeNode<T>
    {
        #region Fields

        private T value;
        private TreeNode<T> right;
        private TreeNode<T> left;

        #endregion

        #region Properties
        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public TreeNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        public TreeNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        #endregion

        public TreeNode(T value)
        {
            this.value = value;
        }
    }
    public class BinarySearchTree<T>: IEnumerable<T>
    {
        private TreeNode<T> head;
        private Comparison<T> comparer;
        private int count = 0;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="elements">elements to add to binary tree</param>
        /// <param name="comparer">comparer to compare two nodes of the binary tree</param>
        public BinarySearchTree(IEnumerable<T> elements, Comparison<T> comparer = null)
        {
            if (ReferenceEquals(elements, null))
            {
                throw new ArgumentNullException(@"{nameof(elements)} must not be null");
            }
            if (typeof(T).GetInterfaces().Contains(typeof(IComparable)) ||
                typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)) ||
                typeof(T).GetInterfaces().Contains(typeof(IComparer)) ||
                typeof(T).GetInterfaces().Contains(typeof(IComparer<T>)))
            {
                if (ReferenceEquals(comparer, null)) this.comparer = Comparer<T>.Default.Compare;
                else this.comparer = comparer;
            }
            else throw new ArgumentException(@"Type {nameof(T)} doesn't have default method Comparer. Grant your own comparer or implement " +
                                             @"IComparer or IComparable interfaces for your type");
            foreach (T value in elements)
            {
                Add(value);
            }
        }


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="elements">elements to add to binary tree</param>
        /// <param name="comparer">comparer to compare two nodes of the binary tree</param>
        public BinarySearchTree(IEnumerable<T> elements, IComparer<T> comparer)
            : this(elements, comparer.Compare) 
        {
        }


        /// <summary>
        /// add a new node to binary tree
        /// </summary>
        /// <param name="value">a value of the new node</param>
        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException();
            TreeNode<T> node = new TreeNode<T>(value);
            if(head == null)
            {
                head = node;
                return;
            }
            TreeNode<T> current = head, parent = null;

            while (current != null)
            {
                parent = current;
                if (comparer(value, current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (comparer(value, parent.Value) < 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }
            
            ++count;
        }

        /// <summary>
        /// add elements to the binary tree
        /// </summary>
        /// <param name="elems">elements</param>

        public void AddElements(IEnumerable<T> elements)
        {
            if (elements == null) throw new ArgumentNullException();

            foreach (T element in elements)
            {
                Add(element);
            }
        }

        /// <summary>
        /// check if there is a value in a binary tree
        /// </summary>
        /// <param name="value">a value to search</param>
        /// <returns>
        /// true if there is a value
        /// false if the value is absent
        /// </returns>
        public bool Contains(T value)
        {
            if (value == null) throw new ArgumentNullException();
            TreeNode<T> current = head;

            while (current != null)
            {
                if (comparer(current.Value, value) == 0) return true;

                if (comparer(value, current.Value) > 0) current = current.Right;
                else current = current.Left;
            }
            return false;
        }


        /// <summary>
        /// remove the value from a binary tree
        /// </summary>
        /// <param name="value">the value to be removed</param>

        public void Remove(T value)
        {
            if (value == null) throw new ArgumentNullException();
            if (!Contains(value)) return;

            TreeNode<T> current = head;
            TreeNode<T> parentCurrent = null;

            while (comparer(current.Value, value) != 0)
            {
                parentCurrent = current;
                if (comparer(value, current.Value) > 0)
                {
                    current = current.Right;
                }
                else current = current.Left;
            }

            if (current.Right == null)
            {
                if (parentCurrent == null)
                {
                    head = current.Left;
                }
                else
                {
                    if (comparer(current.Value, parentCurrent.Left.Value) == 0)
                    {
                        parentCurrent.Left = current.Left;
                    }
                    else
                    {
                        parentCurrent.Right = current.Right;
                    }
                }
            }
            else
            {
                TreeNode<T> temp = current.Right;
                TreeNode<T> parentTemp = null;

                while (temp.Left != null)
                {
                    parentTemp = temp;
                    temp = temp.Left;
                }
                if (parentTemp != null)
                {
                    parentTemp.Left = temp.Right;
                }
                else
                {
                    current.Right = temp.Right;
                }
                current.Value = temp.Value;
            }

            count--;
        }

        /// <summary>
        /// remove all elements from the binary tree
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        /// <summary>
        /// Preorder traversal.
        /// </summary>
        /// <returns> IEnumerable for preorder. </returns>
        public IEnumerable<T> PreOrder()
        {
             return PreOrder(head);
        }
            

        /// <summary>
        /// Postorder traversal.
        /// </summary>
        /// <returns> IEnumerable for postorder.</returns>
        public IEnumerable<T> PostOrder() 
        {
            return PostOrder(head);
        }

        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns> IEnumerable for inorder. </returns>
        public IEnumerable<T> InOrder()
        {
            return InOrder(head);
        }


        #region Iterator

        /// <summary>
        /// Iterator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion


        #region Private methods(PreOrder, InOrder, PostOrder)
        private IEnumerable<T> PreOrder(TreeNode<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
                foreach (var n in PreOrder(node.Left))
                    yield return n;

            if (node.Right != null)
                foreach (var n in PreOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> InOrder(TreeNode<T> node)
        {
            if (node.Left != null)
                foreach (var n in InOrder(node.Left))
                    yield return n;

            yield return node.Value;

            if (node.Right != null)
                foreach (var n in InOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> PostOrder(TreeNode<T> node)
        {
            if (node.Left != null)
                foreach (var n in PostOrder(node.Left))
                    yield return n;

            if (node.Right != null)
                foreach (var n in PostOrder(node.Right))
                    yield return n;

            yield return node.Value;
        }

        #endregion

    }
}

