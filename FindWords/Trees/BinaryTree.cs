using FindWords.Model;
using System;


namespace FindWords.Trees
{
    class BinaryTree
    {
        /// <summary>
        /// Metoden för insättning av ny sökord i trädet.
        /// </summary>
        /// <param name="root">roten av träd</param>
        /// <param name="v">sökordet som ska sättas in</param>
        /// <returns>roten av trädet</returns>
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
        /// Skriv ut samtliga noder av trädet.
        /// </summary>
        /// <param name="root">Roten av det binära trädet.</param>
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
