using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWords.Model;


namespace FindWords.Trees
{
    class BinaryTree
    {

        public Node Insert(Node root, Word v)
        {
            if (root == null)
            {
                root = new Node();
                root.word = v;
            }
            else if (v.name.CompareTo(root.word.name) == -1)
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
            Console.WriteLine(root.word.name + "");
            Traverse(root.left);
            Traverse(root.right);
        }
    }
}
