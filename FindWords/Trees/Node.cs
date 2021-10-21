using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWords.Model;

namespace FindWords.Trees
{
    public class Node
    {
        public Word word = new();
        public Node left;
        public Node right;
    }
}
