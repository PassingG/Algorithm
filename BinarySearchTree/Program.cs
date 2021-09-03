using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            BST<int> bst = new BST<int>();

            bst.Insert(4);
            bst.Insert(2);
            bst.Insert(6);
            bst.Insert(1);
            bst.Insert(7);

            bst.PreOrderTraversal();
        }
    }

    public class BinaryTreeNode<T>
    {
        public T data {get; set;}

        public BinaryTreeNode<T> left {get; set;}
        public BinaryTreeNode<T> right {get; set;}

        public BinaryTreeNode(T data)
        {
            this.data = data;
        }
    }

    public class BST<T>
    {
        private BinaryTreeNode<T> root = null;
        private Comparer<T> comparer = Comparer<T>.Default;

        public void Insert(T val)
        {
            BinaryTreeNode<T> node = root;

            if(node == null)
            {
                root = new BinaryTreeNode<T>(val);
                return;
            }

            while(node != null)
            {
                int result = comparer.Compare(node.data, val);

                if(result == 0)
                {
                    return;
                }
                else if(result > 0)
                {
                    if(node.left == null)
                    {
                        node.left = new BinaryTreeNode<T>(val);
                        return;
                    }
                    
                    node = node.left;
                }
                else
                {
                    if(node.right == null)
                    {
                        node.right = new BinaryTreeNode<T>(val);
                        return;
                    }

                    node = node.right;
                }
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderRecursive(root);
        }

        private void PreOrderRecursive(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            Console.WriteLine(node.data);

            PreOrderRecursive(node.left);
            PreOrderRecursive(node.right);
        }
    }
}
