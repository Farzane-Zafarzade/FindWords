﻿namespace FindWords
{
    using FindWords.FindWordsInFiles;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            FindWord MyProgram = new();
            MyProgram.ReadFiles();
        }
    }
}
