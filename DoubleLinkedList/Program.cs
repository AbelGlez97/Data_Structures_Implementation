using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList list = new LinkedList(10);

            list.append(11);
            list.append(12);
            list.append(13);
            list.remove(2);




            for (int i = 0; i < list.printList().Count; i++)
            {
                Console.WriteLine(list.printList()[i]);
            }


        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
            this.Previous = null;
        }
    }

    public class LinkedList
    {

        private Node head;
        private Node tail;
        private int length;

        public LinkedList(int value)
        {
            this.head = new Node(value);
            this.tail = head;  // tail points to the same Node so when you change tail-Next, Head-Next will also change.
            this.length = 1;
        }

        public void append(int value)
        {
            Node newNode = new Node(value);
            newNode.Previous = this.tail;
            this.tail.Next = newNode;
            this.tail = newNode;
            this.length++;

        }

        public void prepend(int value)
        {
            Node newNode = new Node(value);
            this.head.Previous = newNode;
            // Node temp = this.head;
            newNode.Next = this.head;
            this.head = newNode;
            //this.head.Next = temp;

            this.length++;
        }

        public ArrayList printList()
        {
            ArrayList myAL = new ArrayList();
            Node currentNode = this.head;

            while (currentNode != null)
            {
                myAL.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return myAL;
        }

        public Node traverse(int index)
        {
            Node currentNode = this.head;

            for (int count = index - 1; count > 0; count--)
            {

                currentNode = currentNode.Next;
            }

            return currentNode;
        }
        public void insert(int index, int value)
        {
            if (index > this.length)
            {
                this.append(value);
                return;
            }

            if (index == 0)
            {
                this.prepend(value);
                return;
            }

            Node pointNode = this.traverse(index);

            Node newNode = new Node(value);
            Node follower = pointNode.Next;
            pointNode.Next = newNode;
            newNode.Next = follower;
            newNode.Previous = pointNode;
            follower.Previous = newNode;
            this.length++;
        }

        public void remove(int index)
        {

            Node pointNode = this.traverse(index);
            Node unwantedNode = pointNode.Next;
            Node temp = unwantedNode.Next;
            pointNode.Next = unwantedNode.Next;
            temp.Previous = pointNode;
            this.length--;
        }
    }
}
