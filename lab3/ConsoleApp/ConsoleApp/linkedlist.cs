using System;
using System.Text;

namespace ConsoleApp
{
    class LinkedList <T> : BaseList <T> where T : IComparable<T>
    {
        class Node
        {
            public T Data { set; get; }
            public Node Next { set; get; }

            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }

        }

        private Node head;
        public LinkedList()
        {
            lenght = 0;
            head = null;
        }

        private Node find(int position)
        {
            if (position < 0) { return null; }

            int i = 0;
            Node currenNode = head;
            while (currenNode != null && i < position)
            {
                currenNode = currenNode.Next;
                i++;
            }

            if (i == position) { return currenNode; }
            else { return null; }
        }
        public override void add(T item)
        {
            Node newNode = new Node(item, null);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node tail = find(lenght - 1);
                tail.Next = newNode;
            }
            lenght++;
            check();
        }
        public override void insert(T item, int position)
        {
            if (position < 0 || position > lenght)
            {
                return;
            }
            if (position == 0)
            {
                Node newNode = new Node(item, null);
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node currentNode = find(position - 1);
                Node newNode = new Node(item, null);
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
            }
            lenght++;
            check();
        }
        public override void delete(int position)
        {
            if (position < 0 || position >= lenght)
            {
                return;
            }
            if (position == 0 && head != null)
            {
                head = head.Next;
                lenght--;
                return;
            }
            Node prevNode = find(position - 1);
            Node currentNode = find(position);

            if (currentNode != null)
            {
                prevNode.Next = currentNode.Next;
                lenght--;
            }
            check();
        }
        public override void clear()
        {
            head = null;
            lenght = 0;
        }
        public override void print()
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " ");
                currentNode = currentNode.Next;
            }
        }
        public override void sort()
        {
            Node currentNode = head;
            for (int i = 0; i < lenght - 1; i++)
            {
                Node nextNode = currentNode.Next;
                for (int j = i + 1; j < lenght; j++)
                {
                    if (currentNode.Data.CompareTo(nextNode.Data) > 0)
                    {
                        (currentNode.Data, nextNode.Data) = (nextNode.Data, currentNode.Data);
                    }
                    nextNode = nextNode.Next;
                }
                currentNode = currentNode.Next;
            }
        }
        
        protected override BaseList <T> emptyClone()
        {
            return new LinkedList<T>();
        }

        public override string toString()
        {
            Node currentNode = head;
            StringBuilder write = new StringBuilder();

            while (currentNode != null)
            {
                write.Append(currentNode.Data + "\n");
                currentNode = currentNode.Next;
            }
            return write.ToString();
        }

        public override T this[int index]
        {
            get
            {
                if (index < lenght && index >= 0)
                {
                    Node currentNode = find(index);
                    return currentNode.Data;   
                }
                throw new Exceptions.BadIndexException("Данной позиции не существует");
            }
            set
            {
                if (index < lenght && index >= 0)
                {
                    Node currentNode = find(index);
                    currentNode.Data = value;
                }
                throw new Exceptions.BadIndexException("Данной позиции не существует");
            }
        }
    }
}
