using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryT binaryTree = new BinaryT();
            int[] Numbers = new int[10];
            int i;
            Console.WriteLine("Input 10 numbers: The 1st element will be the root");
            for (i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < Numbers.Length; i++)
            {
                binaryTree.Add(Numbers[i]) ;
            }
          
            Branch node = binaryTree.Find(5);
            int depth = binaryTree.GetTreeDepth();
            Console.WriteLine("PreOrder Traversal:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();
            Console.WriteLine("InOrder Traversal:");
            binaryTree.TraverseInOrder(binaryTree.Root);
            Console.WriteLine();
            Console.WriteLine("PostOrder Traversal:");
            binaryTree.TraversePostOrder(binaryTree.Root);
            Console.WriteLine();
            binaryTree.Remove(7);
            binaryTree.Remove(8);
            Console.WriteLine("PreOrder Traversal After Removing Operation:");
            binaryTree.TraversePreOrder(binaryTree.Root);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    class BinaryT
    {
        public Branch Root { get; set; }

        public bool Add(int value)
        {
            Branch before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.LeftBranch;
                else if (value > after.Data)
                    after = after.RightBranch;
                else
                {
                    return false;
                }
            }

            Branch newBranch = new Branch();
            newBranch.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newBranch;
            else
            {
                if (value < before.Data)
                    before.LeftBranch = newBranch;
                else
                    before.RightBranch = newBranch;
            }

            return true;
        }
        public Branch Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private Branch Remove(Branch parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftBranch = Remove(parent.LeftBranch, key);
            else if (key > parent.Data)
                parent.RightBranch = Remove(parent.RightBranch, key);
            else
            {

                if (parent.LeftBranch == null)
                    return parent.RightBranch;
                else if (parent.RightBranch == null)
                    return parent.LeftBranch;


                parent.Data = MinValue(parent.RightBranch);

                parent.RightBranch = Remove(parent.RightBranch, parent.Data);
            }
            return parent;
        }
        private int MinValue(Branch node)
        {
            int minv = node.Data;

            while (node.LeftBranch != null)
            {
                minv = node.LeftBranch.Data;
                node = node.LeftBranch;
            }

            return minv;
        }
        private Branch Find(int value, Branch parent)
        {
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.LeftBranch);
                else
                    return Find(value, parent.RightBranch);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        private int GetTreeDepth(Branch parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftBranch), GetTreeDepth(parent.RightBranch)) + 1;
        }

        public void TraversePreOrder(Branch parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftBranch);
                TraversePreOrder(parent.RightBranch);
            }
        }

        public void TraverseInOrder(Branch parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftBranch);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightBranch);
            }
        }

        public void TraversePostOrder(Branch parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftBranch);
                TraversePostOrder(parent.RightBranch);
                Console.Write(parent.Data + " ");
            }
        }
    }

    class Branch
    {
        public Branch LeftBranch { get; set; }
        public Branch RightBranch { get; set; }
        public int Data { get; set; }
    }

}
