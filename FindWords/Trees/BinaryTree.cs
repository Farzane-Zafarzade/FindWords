using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWords.Model;


namespace FindWords.Trees
{
    /// <summary>
    /// Class of the data structure where the search results are storing.
    /// </summary>
    class BinaryTree
    {
        /// <summary>
        /// Method for insserting each new word of searching in the tree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="v"></param>
        /// <returns>root</returns>
        public Node Insert(Node root, Word v)
        {
            if (root == null)
            {
                root = new Node();
                root.word = v;
                Console.WriteLine("\n <{0}> is add to data structure",root.word.name);
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

        /// <summary>
        /// Print out the nodes of the tree
        /// </summary>
        /// <param name="root"></param>
        public void Traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(" - " + root.word.name);
            Traverse(root.left);
            Traverse(root.right);
        }
    }
}
