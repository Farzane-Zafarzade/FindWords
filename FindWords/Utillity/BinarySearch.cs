using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWords.Utillity
{
    public static class BinarySearch
    {
        public static int Search(string[] words, string x)
        {
            int count = 0;
            int l = 0;
            int r = words.Length - 1;
            while (l <= r)
            {
                int m = (l + r) / 2;
                int res = x.CompareTo(words[m]);
                if (res == 0)
                {
                    for (int i = l; i <= r; i++)
                    {
                        if (x.Equals(words[i]))
                        {
                            count++;
                        }
                    }
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
