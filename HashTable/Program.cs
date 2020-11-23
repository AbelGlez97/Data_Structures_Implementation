using System;
using System.Collections.Generic;
using System.Globalization;

namespace HashTableImp
{
    class Program
    {
        static void Main(string[] args)
        {

            HashTable hash = new HashTable(20);
            hash.Set("Abel", 23);
            hash.Set("Gerardo", 40);
            hash.Set("Victor", 28);

            foreach (var item in hash.keys())
            {
                Console.WriteLine(item);
            }
          

            Console.WriteLine(hash.get("Victor"));
            Console.ReadLine();
        }
    }

    class MyNode
    {
        public string key { get; set; }
        public int value { get; set; }
        public MyNode(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    class HashTable
    {
        private class MyNodes : List<MyNode> { }  // ":" colon means inheritance, MyNode is inhereting from the List class
        private int length;
        private MyNodes[] data;

        public HashTable(int size)
        {
            this.length = size;
            this.data = new MyNodes[size];
        }

        private int Hash(string key)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int)key[i] * i) % this.length;
            }
            return hash;
        }

        public void Set(string key, int value)
        {
            int index = Hash(key);
            if (this.data[index] == null)
            {
                this.data[index] = new MyNodes();
            }
            this.data[index].Add(new MyNode(key, value));


        }

        public int get(string key)
        {
            int index = Hash(key);
            if (this.data[index] == null)
            {
                return 0;
            }

            foreach (var node in this.data[index])
            {
                if (node.key.Equals(key))
                {
                    return node.value;
                }
            }
            return 0;
        }
        public List<string> keys()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    for (int j = 0; j < this.data[i].Count; j++)
                    {
                            result.Add(this.data[i][j].key);
                    }
                }
                    
            }
            return result;
        }
    }
}
