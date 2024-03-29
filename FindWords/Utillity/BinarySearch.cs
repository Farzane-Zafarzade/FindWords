﻿namespace FindWords.Utillity
{
    using FindWords.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="BinarySearch" />.
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Search for the keyword that match in the list.
        /// </summary>
        /// <param name="words">The list of object Word.</param>
        /// <param name="x">the keyword.</param>
        /// <returns>.</returns>
        public static int Search(List<Word> words, string x)
        {
            int l = 0;
            int r = words.Count - 1;

            if (words.Count == 0)
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
