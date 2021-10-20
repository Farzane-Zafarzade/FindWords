using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWords.Utillity;
using FindWords.Trees;

namespace FindWords.FindWordsInFiles
{
    public class FindWord
    {
        private Node root = new();
        private string[] file1;
        private string[] file2;
        private string[] file3;
        private char[] splitItems = { ' ', '.', ',', '-','\t','\n',';' };

        public void Run()
        {
            Console.Write("\n Enter the first file path: ");
            ReadFile.pathFile = Console.ReadLine();
            file1 = Split(ReadFile.ReadingFromFile().ToLower());
            Console.Write("\n Enter the second file path: ");
            ReadFile.pathFile = Console.ReadLine();
            file2 = Split(ReadFile.ReadingFromFile().ToLower());
            Console.Write("\n Enter the third file path: ");
            ReadFile.pathFile = Console.ReadLine();
            file3 = Split(ReadFile.ReadingFromFile().ToLower());
            Console.Write("\n Enter the word you want to search: ");
            root.value = Console.ReadLine().ToLower().Trim();
            string FileName = FindMaxOccurrences(root.value);
            Console.WriteLine("\n {0} has maximum amount of {1} and it is {2}", FileName,root.value,root.amount);
        }

        private string[] Split(string text)
        {
           string[] words = text.Split(splitItems);
            return words;  
        }

        private string FindMaxOccurrences(string word)
        {
            int amountInFile1 = CountOccurrences(file1, word);
           
            int amountInFile2 = CountOccurrences(file2, word);
          
            int amountInFile3 = CountOccurrences(file3, word);
            
            string max = GetMaximum(amountInFile1, amountInFile2, amountInFile3);
            return max;
        }

        private string GetMaximum(int num1, int num2, int num3)
        {
            if(num1 > num2)
            {
                if(num1 > num3)
                {
                    root.amount = num1;
                    return "File 1";
                }
                else
                {
                    root.amount = num3;
                    return "File 3";
                }
            }
            else if (num2 > num3)
            { 
                root.amount = num2;
                return "File 2";
            }
            else
            {
                root.amount = num3;
                return "File 3";
            }
        }

        private int CountOccurrences(string[] arrayOfWords, string word)
        {
            int count = 0;
          
            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                if (word.Equals(arrayOfWords[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
