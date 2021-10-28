﻿using FindWords.Model;
using System.Collections.Generic;

namespace FindWords.Utillity
{
    public static class BinarySearch
    {
        /// <summary>
        /// Söka sökordet som matchar i listan.
        /// </summary>
        /// <param name="words">listan av objekt Word</param>
        /// <param name="x">sökord</param>
        /// <returns>Index för sökordet i listan, -1 om ordet inte finns.</returns>
        /// Tidskomplexiteten O (log n)
        public static int Search(List<Word> words, string x)
        {
            int l = 0;
            int r = words.Count - 1;

            if(words.Count == 0)
            {
                return -1;
            }
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
           
            return -1;
        }
    }
}
