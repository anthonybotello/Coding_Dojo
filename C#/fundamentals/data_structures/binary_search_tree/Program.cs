using System;

namespace binary_search_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(10);
            bst.Add(8);
            bst.Add(7);
            bst.Add(6);
            bst.Add(12);
            bst.Add(9);
            bst.Add(11);
            // Console.WriteLine(bst.Root.Value);
            // Console.WriteLine(bst.Root.Left.Value);
            // Console.WriteLine(bst.Root.Right.Value);
            // Console.WriteLine(bst.Root.Left.Right.Value);
            // Console.WriteLine(bst.Root.Right.Left.Value);
            // Console.WriteLine(bst.Contains(10));
            // Console.WriteLine(bst.Contains(8));
            // Console.WriteLine(bst.Contains(12));
            // Console.WriteLine(bst.Contains(9));
            // Console.WriteLine(bst.Contains(11));
            // Console.WriteLine(bst.Contains(13));
            // Console.WriteLine(bst.Contains(0));
            bst.Remove(6);
        }
    }

    public class BSTNode
    {
        public int Value;
        public BSTNode Left;
        public BSTNode Right;

        public BSTNode(int val)
        {
            Value = val;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public BSTNode Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public BinarySearchTree Add(int val)
        {
            if (this.Root == null)
            {
                this.Root = new BSTNode(val);
                return this; 
            }
            else
            {
                BSTNode runner = this.Root;
                bool endoftree = false;
                while (!endoftree)
                {
                    if (val < runner.Value)
                    {
                        if (runner.Left != null)
                        {
                            runner = runner.Left;
                        }
                        else
                        {
                            runner.Left = new BSTNode(val);
                            endoftree = true;
                        }
                    }
                    else if (val > runner.Value)
                    {
                        if (runner.Right != null)
                        {
                            runner = runner.Right;
                        }
                        else
                        {
                            runner.Right = new BSTNode(val);
                            endoftree = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Value already in binary search tree!");
                        return this;
                    }
                }
                return this;
            }
        }

        public bool Contains(int val)
        {
            if (this.Root == null)
            {
                return false;
            }
            else
            {
                BSTNode runner = this.Root;
                while (runner.Value != val)
                {
                    if (val < runner.Value)
                    {
                        if (runner.Left == null)
                        {
                            return false;
                        }
                        runner = runner.Left;
                    }
                    else if (val > runner.Value)
                    {
                        if (runner.Right == null)
                        {
                            return false;
                        }
                        runner = runner.Right;
                    }
                }
                if (runner.Value == val)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Remove(int val) //WIP
            if (!this.Contains(val))
            {
                return false;
            }
            BSTNode runner = this.Root;
            while (runner.Left.Value != val && runner.Right.Value != val)
            {
                if (val < runner.Value)
                {
                    runner = runner.Left;
                }
                else if (val > runner.Value)
                {
                    runner = runner.Right;
                }
            }
            if (val < runner.Value)
            {
                if (runner.Left.Left == null && runner.Left.Right == null)
                {
                    runner.Left = null;
                }
                else if (runner.Left.Left != null)
                {
                    BSTNode temp = runner.Left.Left;
                    runner.Left.Left = null;
                    runner.Left = temp;
                }
            }
            else if (val > runner.Value)
            {
                if (runner.Left.Left == null && runner.Left.Right == null)
                {
                runner.Right = null;
                }
            }
            return true;
        }
    }
}
