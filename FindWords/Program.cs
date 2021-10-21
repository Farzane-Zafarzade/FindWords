using System;
using FindWords.Utillity;
using FindWords.FindWordsInFiles;
using FindWords.Trees;
using System.Collections.Generic;
using FindWords.Model;


namespace FindWords
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*List<Word> mylist = new() { new Word { amount = 1, name = "jag" }, new Word { amount = 1, name = "du" } };
            Utillity.ReadFile.pathFile = @"C:\Users\User\Desktop\me.txt";
            string test=Utillity.ReadFile.ReadingFromFile();
            string[] array = test.Split(' ');
            
            int num = Utillity.BinarySearch.Search(mylist, "du");
            Console.WriteLine(num);*/
            FindWord MyProgram = new();
           MyProgram.Run(); 
        }

        
    }
}
