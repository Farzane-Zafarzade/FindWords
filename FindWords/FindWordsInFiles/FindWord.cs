using System;
using FindWords.Utillity;
using FindWords.Model;
using FindWords.Trees;
using System.Collections.Generic;

namespace FindWords.FindWordsInFiles
{
    public class FindWord
    {
        private Node root = new();
        private List<Word> file1 = new();
        private List<Word> file2 = new();
        private List<Word> file3 = new();
        private bool keepGoing = true;

        private char[] splitItems = { ' ', '.', ',', '-','\t','\n',';' };

        public void Run()
        {
            Console.Write("\n Enter the first file path: ");
            ReadFile.pathFile = Console.ReadLine();
            string textOfFile1 = ReadFile.ReadingFromFile().ToLower();
            InserInList(file1, textOfFile1);
            Console.Write("\n Enter the second file path: ");
            ReadFile.pathFile = Console.ReadLine();
            string textOfFile2 = ReadFile.ReadingFromFile().ToLower();
            InserInList(file2, textOfFile2);
            Console.Write("\n Enter the third file path: ");
            ReadFile.pathFile = Console.ReadLine();
            string textOfFile3 = ReadFile.ReadingFromFile().ToLower();
            InserInList(file3, textOfFile3);
            while (keepGoing)
            {
                Console.Write("\n Enter the word you want to search: ");
                root.word.name = Console.ReadLine().ToLower().Trim();
                string FileName = FindMaxOccurrences(root.word.name);
                Console.WriteLine("\n {0} <{1}> and it is {2}", FileName, root.word.name, root.word.amount);
                Console.Write("\n Want to search another word? (y/n) ");
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "n")
                {
                    keepGoing = false;
                }
            }
            
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
            if(num1==num2 && num2 == num3)
            {
                if (num1 == -1)
                {
                    return "This word does not exist in all tree files";
                }
                return "There is equal amount in three files";
            }
            if(num1 > num2)
            {
                if(num1 > num3)
                {
                    root.word.amount = num1;
                    return "File 1 has maximum amount of";
                }
                else
                {
                    
                    root.word.amount = num3;
                    return "File 3 has maximum amount of";
                }
            }
            else if (num2 > num3)
            {
                root.word.amount = num2;
                return "File 2 has maximum amount of";
            }
            else
            {
                root.word.amount = num3;
                return "File 3 has maximum amount of";
            }
        }

        private int CountOccurrences(List<Word> wordsInList, string word)  // ToDo: BinarySearch istället för
        {
            int index=BinarySearch.Search(wordsInList, word);
            if(index>= 0)
            {
                return wordsInList[index].amount;
            }
            else
            {
                return -1;
            }

           /* foreach(var item in wordsInList)
            {
                if (item.name == word)
                {
                    return item.amount;
                }
            }
            return 0;*/
        }

        public void InserInList(List<Word> words, string textFromFile)
        {
            string[] WordsIntext = textFromFile.Split(splitItems);
            foreach (var word in WordsIntext) // O(n)
            {

                int index = BinarySearch.Search(words, word); //O( n log(n))
                if (index == -1)
                {
                    int lenght = words.Count;
                    Word newWord = new()
                    {
                        name = word,
                        amount = 1
                    };
                    
                    if (lenght == 0)
                    {
                        words.Add(newWord);
                    }
                    else
                    {
                        while (lenght > 0 && words[lenght - 1].name.CompareTo(newWord.name) == 1)
                        {
                            lenght--;
                        }
                        words.Insert(lenght, newWord);

                    }


                    // - använda merge sort O( n log(n))
                }
                else
                {
                    words[index].amount++;

                }

            }
        }
    }
}
