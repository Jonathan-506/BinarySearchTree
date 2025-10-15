using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BST
    {
        public Node Root;


        public BST()
        {

        }

        public BST(int root)
        {
            Root = new Node(root);
        }

        public void InsertNode(int node)
        {
            Root = InsertNode(Root, node);
        }

        public void InsertNode(Node node)
        {
            Root = InsertNode(Root, node.Data);
        }

        public Node InsertNode(Node root, int value)
        {
            if (root == null)
            {
                return new Node(value);
            }
            
            if (value < root.Data)
            {
                root.Left = InsertNode(root.Left, value);
            }
            else
            {
                root.Right = InsertNode(root.Right, value);
            }

            return root;
        }

        public void RemoveNode(int node)
        {
           Root = RemoveNode(Root, node);
        }

        public Node RemoveNode(Node root, int delete)
        {
            if(root == null)
            {
                return root;
            }

            //Traverse 
            if (delete < root.Data)
            {
                root.Left = RemoveNode(root.Left, delete);
            }
            else if(delete > root.Data)
            {
                root.Right = RemoveNode(root.Right, delete);
            }
            else
            {
                //We found it!!

                //case 1
                if(root.Left == null && root.Right == null)
                {
                    return null;
                }

                //case 2

                if(root.Left == null)
                {
                    return root.Right;
                }
                else if(root.Right == null)
                {
                    return root.Left;
                }


                //case 3

                root.Data = FindMax(root);
                root.Left = RemoveNode(root.Left, root.Data);
            }

            return root;

        }

        public int FindMax(Node root)
        {
            int max = root.Data;
            while (root.Right != null)
            {
                max = root.Right.Data;
                root = root.Right;
            }
            return max;
        }


        public int FindMin(Node root)
        {
            int min = root.Data;
            while (root.Left != null)
            {
                min = root.Left.Data;
                root = root.Left;
            }
            return min;
        }

        public void InOrder()
        {
            InOrder(Root);
        }

        public void InOrder(Node node)
        {
            //retrieve data in order
            if(node == null)
            {
                return;
            }

            //LNR

            InOrder(node.Left);
            Console.WriteLine(node.Data);
            InOrder(node.Right);

        }

        public void PreOrder()
        {
            PreOrder(Root);
        }


        public void PreOrder(Node node)
        {
            //creating a copy, or serializing
            if (node == null)
            {
                return;
            }

            //NLR

            Console.WriteLine(node.Data);
            PreOrder(node.Left);
            PreOrder(node.Right);
            

        }

        public void PostOrder()
        {
            PostOrder(Root);
        }


        public void PostOrder(Node node)
        {
            //Deleting, freeing up memory
            if (node == null)
            {
                return;
            }

            //LRN

            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine(node.Data);
        }


        /*
         * In-Order to be a learner(LNR) don't pre-order the Not-learn(NLR) book. but rather Post what you learn(LRN) online.
         */

        //public void LevelOrder()
        //{
        //    LevelOrder(Root);
        //}

        public void LevelOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.WriteLine(current.Data);

                if(current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        public int DepthFinder(int target)
        {

            return DepthFinder(Root, new Node(target));
        }

        public int DepthFinder(Node node, Node target, int depth = 0)
        {
            
            if(node == null)
            {
                return -1;
            }

            if (target.Data == node.Data)
            {
                return depth;
            }
            if (target.Data < node.Data)
            {
                
               int left = DepthFinder(node.Left, target, depth+1);
                return left;
            }
            else 
            {

                int right = DepthFinder(node.Right, target, depth+1);
                return right;
            }


        }
        //public int DepthFinder(Node node, Node target, int depth)
        //{
        //    if(node == null)
        //    {
        //        return -1;
        //    }

        //    if (target.Data == node.Data)
        //    {
        //        return depth;
        //    }

        //    if (target.Data < node.Data)
        //    {
                
        //        return DepthFinder(node.Left, target, depth++);
        //    }
        //    else if (target.Data > node.Data)
        //    {
                
        //        return DepthFinder(node.Right, target, depth++);
        //    }


        //    return -1;
        //}

        public int HeightFinder()
        {
            return HeightFinder(Root);
        }
        public int HeightFinder(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            return Math.Max(HeightFinder(node.Left) , HeightFinder(node.Right)) + 1;
            
        }

        public bool RoughBalance()
        {
            int leftHeight = HeightFinder(Root.Left);

            int rightHeight = HeightFinder(Root.Right);

            if (0 == leftHeight - rightHeight || -1 == leftHeight - rightHeight || 1 == leftHeight - rightHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Node
    {
        public int Data {  get; set; }
        public  Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Data = value; 
        }

    }
}
