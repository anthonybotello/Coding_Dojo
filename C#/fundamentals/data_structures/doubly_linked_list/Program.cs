using System;

namespace doubly_linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList mylist = new DoublyLinkedList();
            mylist.Add(0).Add(1).Add(2).Add(3).Add(4);
            mylist.PrintValues();
            Console.WriteLine(mylist.Count());
            mylist.Reverse().PrintValues();
            mylist.RemoveLast();
            mylist.PrintValues();
            Console.WriteLine(mylist.Remove(10));
            Console.WriteLine(mylist.Remove(2));
            mylist.PrintValues();
        }
    }

    public class DllNode
    {
        public int Value;
        public DllNode Next;
        public DllNode Prev;
        
        public DllNode(int val)
        {
            Value = val;
        }
    }

    public class DoublyLinkedList
    {
        public DllNode Head;

        public DoublyLinkedList()
        {
            Head = null;
        }

        public DoublyLinkedList Add(int value)
        {
            DllNode new_node = new DllNode(value);
            if (this.Head == null)
            {
                this.Head = new_node;
                return this;
            }
            else
            {
                DllNode runner = this.Head;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                }
                runner.Next = new_node;
                new_node.Prev = runner;
                return this;
            }
        }

        public dynamic RemoveLast()
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return null;
            }
            else
            {
                DllNode runner = this.Head;
                while (runner.Next.Next != null)
                {
                    runner = runner.Next;
                }
                DllNode backnode = runner.Next;
                runner.Next = null;
                return backnode.Value;
            }
        }

        public bool Remove(int value)
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return false;
            }
            else
            {
                DllNode runner = this.Head;
                bool in_list = false;
                while (!in_list && runner.Next != null)
                {
                    if (runner.Value == value)
                    {
                        in_list = true;
                        runner.Prev.Next = runner.Next;
                        runner.Next.Prev = runner.Prev;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                return in_list;
            }
        }
        public DoublyLinkedList PrintValues()
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return this;
            }
            else
            {
                DllNode runner = this.Head;
                Console.Write("[");
                while (runner.Next != null)
                {
                    Console.Write($"{runner.Value}, ");
                    runner = runner.Next;
                }
                Console.Write($"{runner.Value}]");
                Console.WriteLine();
                return this;
            }
        }

        public int Count()
        {
            if (this.Head == null)
            {
                return 0;
            }
            else
            {
                DllNode runner = this.Head;
                int count = 0;
                while (runner != null)
                {
                    runner = runner.Next;
                    count++;
                }
                return count;
            }
        }

        public DoublyLinkedList Reverse()
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return this;
            }
            else
            {
                DllNode frontrunner = this.Head;
                DllNode backrunner = this.Head;
                while (backrunner.Next != null)
                {
                    backrunner = backrunner.Next;
                } 
                //after this loop backrunner points to the last node
                int count = 0;
                while (count < this.Count()/2)
                // stops at Count()/2 so reversal will stop at middle of list, otherwise it would re-reverse list and return original order
                {
                    int temp = frontrunner.Value;
                    frontrunner.Value = backrunner.Value;
                    backrunner.Value = temp;
                    frontrunner = frontrunner.Next;
                    backrunner = backrunner.Prev;
                    count++;
                }
                return this;
            }
        }
    }
}
