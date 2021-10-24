using System;
using FindWords.Utillity;
using FindWords.FindWordsInFiles;
using FindWords.Trees;
using System.Collections.Generic;
using FindWords.Model;
using FindWords.Trees;


namespace FindWords
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FindWord MyProgram = new();
            MyProgram.Run();  
        }

        
    }
}
