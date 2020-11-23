using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList list = new LinkedList(10);

            list.append(11);
            list.append(12);
            list.append(13);
   

           
           

            for (int i = 0; i < list.printList().Count; i++)
            {
                Console.WriteLine(list.printList()[i]);
            }

            list.reverse();

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

        public Node (int value)
        {
            this.Value = value;
            this.Next = null;
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
            this.tail.Next = newNode;
            this.tail = newNode;
            this.length++;
          
        }

        public void prepend(int value)
        {
            Node newNode = new Node(value);
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

            while(currentNode != null)
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
            if(index > this.length)
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
            Node temp = pointNode.Next;
            pointNode.Next = newNode;
            newNode.Next = temp;
            this.length++;
        }

        public void remove(int index)
        {
            
            Node pointNode = this.traverse(index);

            Node unwantedNode = pointNode.Next;
            pointNode.Next = unwantedNode.Next;
            this.length--;
        }

        public void reverse()
        {
            if(this.head.Next != null) {
                Node first = this.head;
                this.tail = this.head;
                Node second = first.Next;

                while (second != null)
                {
                    Node temp = second.Next;
                    second.Next = first;
                    first = second;
                    second = temp;
                }

                this.head.Next = null;
                this.head = first;
            }
        }
    }
}
