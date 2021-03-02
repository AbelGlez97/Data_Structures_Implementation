using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(25);
            tree.Insert(1);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(30);

            Console.WriteLine("Found number :" + tree.Lookup(30) + " in the tree");

            Console.ReadLine();
        }
    }

    class Node
    {
        public Node left { get; set; }
        public Node right { get; set;}
        public int value { get; set; }

        public Node(int value)
        {
            this.left = null;
            this.right = null;
            this.value = value;
        }      
    }

    class BinarySearchTree
    {
        private Node root;
        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);

            if(root == null)
            {
                this.root = newNode;
            }
            else
            {
                Node currentNode = this.root;
                while(true)
                {
                    if (value < currentNode.value)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = newNode;
                            return;
                        }
                        currentNode = currentNode.left; 
                    }
                    else
                    {
                        if(currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            return;
                        }
                        currentNode = currentNode.right;
                    }
                }
            }

            //else if(newNode.value > this.root.value)
            //{
            //    this.root.right = newNode;
            //}

            //else if (newNode.value < this.root.value)
            //{
            //    this.root.left = newNode;
            //}
        }

        public Node Lookup(int value)
        {
            if (this.root == null)
            {
                return null;
            }

            Node currentNode = this.root;
            while (currentNode != null)
            {
                if (value < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if(value > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else 
                {
                    return currentNode;
                }
            }
            return null;
        }

        public void remove(int value)
        {
            if(this.root == null)
            {
                return;
            }
            Node currentNode = this.root;
            Node parentNode = null;

            while (currentNode != null)
            {
                if (value < currentNode.value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.left;
                }
                else if (value > currentNode.value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.right;
                }
                else if (value == currentNode.value)
                {
                    //option 1: No right child
                    if (currentNode.right == null)
                    {
                        if (parentNode == null) //checks if the value is the root
                        {
                            this.root = currentNode.left;
                        }
                        else
                        {
                            if (currentNode.value < parentNode.value)
                            {
                                parentNode.left = currentNode.left;
                            }
                            else if (currentNode.value > parentNode.value)
                            {
                                parentNode.right = currentNode.left;
                            }
                        }

                    }
                    //option 2: Right child which doesn't have a left child
                    else if (currentNode.right.left == null)
                    {
                        if (parentNode == null)
                        {
                            this.root = currentNode.left;
                        }
                        else
                        {
                            currentNode.right.left = currentNode.left;

                            if (currentNode.value < parentNode.value)
                            {
                                parentNode.left = currentNode.right;
                            }
                            else if (currentNode.value > parentNode.value)
                            {
                                parentNode.right = currentNode.right;
                            }
                        }
                    }
                    //option 3; Right child that has a left child
                    else if (currentNode.right.left != null)
                    {
                        //find the Right child's left most child
                        Node leftmost = currentNode.right.left;
                        Node leftmostParent = currentNode.right;
                        while(leftmost.left != null)
                        {
                            leftmostParent = leftmost;
                            leftmost = leftmost.left;
                        }

                        //parent's left subtree is now  leftmost's right subtree
                        leftmostParent.left = leftmost.right;  // this a temp variable, not real change in leftmost in tree
                        leftmost.left = currentNode.left;
                        leftmost.right = currentNode.right;

                        if(parentNode ==null)
                        {
                            this.root = leftmost;
                        }
                        else
                        {
                            if(currentNode.value < parentNode.value)
                            {
                                parentNode.left = leftmost;
                            }
                            else if(currentNode.value > parentNode.value){
                                parentNode.right = leftmost;
                            }
                        }
                    }
                    else  //Option 4 : No Left Child But Got Right Child
                    {
                            
                            if (parentNode == null)
                            {
                                this.root = currentNode.right;
                            }
                            else
                            {
                                //insert left
                                if (currentNode.value < parentNode.value)
                                {
                                    parentNode.left = currentNode.right;
                                }
                                //insert right
                                else if (currentNode.value > parentNode.value)
                                {
                                    parentNode.right = currentNode.right;
                                }
                            }
                        }
                }
            }
        }
    }
    
}


//       10
//   5        25
// 1   8    15   30


