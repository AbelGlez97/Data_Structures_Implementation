using System;
using System.ComponentModel.DataAnnotations;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray arr1 = new MyArray();

            arr1.push("hi");
            arr1.push("hello");
            arr1.push("heyyyyy");
            arr1.push("Holaaa");

           

            arr1.remove(1);

            for (int i = 0; i < arr1.length; i++)
            {
                Console.WriteLine("values: " + arr1.get(i));
            }

            Console.ReadLine();
        }
    }

    class MyArray
    {
        public int length;
        private Object[] data;

        public MyArray()
        {
            this.length = 0;
            this.data = new Object[1];

        }

        public Object get(int index)
        {
            return data[index];
        }

        public Object push (Object item)
        {
            if(this.data.Length == this.length)
            {
                Object[] temp = new Object[this.length];
                Array.Copy(this.data, temp, length);
                this.data = new Object[length + 1];
                Array.Copy(temp, this.data, length);
            }
            this.data[this.length] = item;
            this.length++;
            return this.data;
        }

        public Object pop()
        {

            Object poped = data[this.length-1];
            this.length--;
            return poped;
        }

        public Object remove(int index)
        {
            Object lastItem = this.data[this.length -1];
            this.shiftItems(index);
            return lastItem;
        }

        private void shiftItems(int index)
        {
            for (int i = index; i < this.length-1; i++)
            {
                this.data[i] = this.data[i + 1];
               
              
            }
            this.length--;
            
        }
    }
}

