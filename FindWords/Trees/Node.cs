using FindWords.Model;

namespace FindWords.Trees
{
    /// <summary>
    /// The class of template 
    /// for the keywords of searching.
    /// </summary>
    public class Node
    {
        public Word word = new();
        public Node left;
        public Node right;
    }
}
