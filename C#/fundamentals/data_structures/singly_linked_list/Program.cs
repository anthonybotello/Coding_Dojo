using System;

namespace singly_linked_list
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList mylist = new SinglyLinkedList();
            mylist.AddBack(0).AddBack(1).AddBack(2).AddFront(-1).AddFront(-2).PrintValues();
            // mylist.RemoveFront();
            // mylist.RemoveBack();
            // mylist.PrintValues();
            // mylist.InsertAt(100,1).PrintValues();
        }
    }

    public class SllNode
    {
        public int Value;
        public SllNode Next;

        public SllNode(int value)
        {
            Value = value;
            Next = null;
        }
    }
    public class SinglyLinkedList
    {
        public SllNode Head;
        
        public SinglyLinkedList()
        {
            Head = null;
        }

        public SinglyLinkedList AddBack(int value)
        {
            SllNode new_node = new SllNode(value);
            if (Head == null)
            {
                Head = new_node;
                return this; 
                // returning "this" keyword allows method chaining.
            }
            else
            {
                SllNode runner = Head;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                }
                runner.Next = new_node;
                return this;
            }
        }

        public SinglyLinkedList AddFront(int value)
        {
            SllNode new_node = new SllNode(value);
            new_node.Next = this.Head;
            this.Head = new_node;
            return this;
        }
        public dynamic RemoveBack() 
        //set dynamic return type to account for possiblity of different return types -- in this case, type "null" and type "int"
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return null;
            }
            else
            {
                SllNode runner = this.Head;
                while (runner.Next.Next != null)
                {
                    runner = runner.Next;
                }
                SllNode backnode = runner.Next;
                runner.Next = null;
                return backnode.Value;
            }
        }

        public dynamic RemoveFront()
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return null;
            }
            else
            {
                SllNode frontnode = this.Head;
                this.Head = this.Head.Next;
                return frontnode.Value;
            }
        }

        public SinglyLinkedList PrintValues()
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return this;
            }
            else
            {
                SllNode runner = this.Head;
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

        public SllNode Find(int val)
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty list.");
                return null;
            }
            else
            {
                SllNode runner = this.Head;
                while (runner.Value != val && runner.Next != null)
                {
                    runner = runner.Next;
                }
                if (runner.Next == null && runner.Value != val)
                {
                    Console.WriteLine("Value not stored in list.");
                    return null;
                }
                else
                {
                    return runner;
                }
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
                SllNode runner = this.Head;
                int count = 0;
                while (runner != null)
                {
                    runner = runner.Next;
                    count++;
                }
                return count;
            }
        }

        public SinglyLinkedList RemoveAt(int idx)
        {
            if (this.Head == null)
            {
                Console.WriteLine("Empty List.");
                return this;
            }
            else if (idx < 0 || idx >= this.Count())
            {
                Console.WriteLine("Specified index outside of list range.");
                return this;
            }
            else
            {
                int index = 0;
                SllNode runner = this.Head;
                while (index < idx - 1)
                {
                    runner = runner.Next;
                    index++;
                }
                SllNode temp = runner.Next.Next;
                runner.Next.Next = null;
                runner.Next = temp;
                return this;
            }
        }

        public SinglyLinkedList InsertAt(int value, int idx)
        {
            if (this.Head == null && idx != 0)
            {
                Console.WriteLine("Specified index outside of list range.");
                return this;
            }
            else if (idx < 0 || idx > this.Count())
            {
                Console.WriteLine("Specified index outside of list range.");
                return this;
            }
            else if (idx == 0)
            {
                this.AddFront(value);
                return this;
            }
            else if (idx == this.Count())
            {
                this.AddBack(value);
                return this;
            }
            else
            {
                int index = 0;
                SllNode runner = this.Head;
                while (index < idx - 1)
                {
                    runner = runner.Next;
                    index++;
                }
                SllNode temp = runner.Next;
                runner.Next = new SllNode(value);
                runner.Next.Next = temp;
                return this;
            }
        }
    }
}
