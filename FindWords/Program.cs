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
           // List<Word> file1 = new();
            FindWord MyProgram = new();
            //Console.Write("\n Enter the first file path: ");
            //ReadFile.pathFile = Console.ReadLine();
            //string textOfFile1 = ReadFile.ReadingFromFile().ToLower();
           // MyProgram.InserInList(file1, textOfFile1);
           // MyProgram.GetWordsFromFile(file1,4);
            MyProgram.Run();  
        }

        
    }
}
