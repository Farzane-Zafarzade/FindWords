using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWords.Model;

namespace FindWords.Utillity
{
    public static class BinarySearch
    {
        public static int Search(List<Word> words, string x)
        {
            int count = 0;
            int l = 0;
            int r = words.Count - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                int res = x.CompareTo(words[m].name);
                if (res == 0)
                {
                    return m;
                }
                if (res > 0)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
           
            return count;
        }
    }
}
