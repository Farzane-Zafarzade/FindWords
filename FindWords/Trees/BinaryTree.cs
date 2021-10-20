using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindWords.Trees
{
    class BinaryTree
    {
        

        public Node Insert(Node root, string v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v.CompareTo(root.value) == -1)
            {
                root.left = Insert(root.left, v);
            }
            else
            {
                root.right = Insert(root.right, v);
            }

            return root;
        }

        public void Traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.value + "");
            Traverse(root.left);
            Traverse(root.right);
        }
    }
}
