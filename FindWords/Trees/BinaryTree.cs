using FindWords.Model;
using System;


namespace FindWords.Trees
{
    /// <summary>
    /// Class of the data structure where the search results are stored.
    /// </summary>
    class BinaryTree
    {
        /// <summary>
        /// Insert each new word of searching in the tree.
        /// </summary>
        /// <param name="root">the root of the tree.</param>
        /// <param name="v">the inserted word</param>
        /// <returns>root</returns>
        public Node Insert(Node root, Word v)
        {
            if (root == null)
            {
                root = new Node();
                root.word = v;
                Console.WriteLine("\n <{0}> is add to tree",root.word.name);
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
        /// <param name="root">The root of the binary tree.</param>
        public void Traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine( " " + root.word.name);
            Traverse(root.left);
            Traverse(root.right);
        }
    }
}
