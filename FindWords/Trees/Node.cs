using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWords.Trees
{
    public class Node
    {
        public string value { get; set; }
        public int amount { get; set; }
        public string fileName {get; set;}
        public Node left;
        public Node right;
    }
}
