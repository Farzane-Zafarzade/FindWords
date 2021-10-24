using System;
using FindWords.Utillity;
using FindWords.Model;
using FindWords.Trees;
using System.Collections.Generic;

namespace FindWords.FindWordsInFiles
{
    public class FindWord
    {
        private BinaryTree myTree = new();
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
            ShowMenu();
           /* while (keepGoing)
            {


                Console.Write("\n Enter the word you want to search: ");
                string searchWord = Console.ReadLine().ToLower().Trim();
                Word newWord = FindMaxOccurrences(searchWord);
                Console.WriteLine("\n {0} has max amount of <{1}> and it is {2}", newWord.FlieName, newWord.name, newWord.amount);
                myTree.Insert(root, newWord);
     
                Console.Write("\n Want to search another word? (y/n) ");
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "n")
                {
                    Console.WriteLine("\n Search resultat is: ");
                    myTree.Traverse(root);
                    keepGoing = false;
                    Console.WriteLine("\n Press Enter to exit");
                    Console.ReadKey();
                }
            }*/
            
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n 1.Find the max number of occurrences. ");
            Console.WriteLine("\n 2.Show the first words. ");
            Console.WriteLine("\n 3.Show the search results. ");
            Console.WriteLine("\n 4.Exit\n");
            Console.WriteLine(" \n------------------\n");
            Console.Write(" Select an option: ");
            _ = int.TryParse(Console.ReadLine(), out int choice);
            while (choice != 1 && choice != 2 && choice != 3 && choice != 4)
            {
                Console.Write("\n Invalid input, try again: ");
                _ = int.TryParse(Console.ReadLine(), out choice);
            }

            ShowSelectedOption(choice);
        }


        public void ShowSelectedOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("\n Enter the word you want to search: ");
                    string searchWord = Console.ReadLine().ToLower().Trim();
                    Word newWord = FindMaxOccurrences(searchWord);
                    Console.WriteLine("\n {0} has max amount of <{1}> and it is {2}", newWord.FlieName, newWord.name, newWord.amount);
                    myTree.Insert(root, newWord);
                    BackToMenu();
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("\n Choose the file you want to show words from that (file1 , file2 , flie3): ");
                    string fileName = Console.ReadLine().Trim().ToLower();
                    Console.Write("\n Enter The number of words: ");
                    int numberOfWords = int.Parse(Console.ReadLine());
                    switch (fileName)
                    {
                        case "file1":
                            GetWordsFromFile(file1, numberOfWords);
                            break;
                        case "file2":
                            GetWordsFromFile(file2, numberOfWords);
                            break;
                        case "file3":
                            GetWordsFromFile(file3, numberOfWords);
                            break;
                    }
                    BackToMenu();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("\n Search results : ");
                    myTree.Traverse(root);
                    BackToMenu();
                    break;

                case 4:
                    System.Environment.Exit(1);
                    break;
            }
        }

        private void BackToMenu()
        {
            Console.Write("\n Do you want to back to menu: (y/n)  ");
            string input = CheckInput(Console.ReadLine().ToLower().Trim());

            if (input == "y")
            {
                ShowMenu();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        private string CheckInput(string input)
        {
            while (input != "n" && input != "y")
            {
                Console.Write("\n Invalid input, enter 'y' or 'n': ");
                input = Console.ReadLine().ToLower().Trim();
            }

            return input;
        }


        private Word FindMaxOccurrences(string word)
        {
            Word result= new();
            int amountInFile1 = CountOccurrences(file1, word);
           
            int amountInFile2 = CountOccurrences(file2, word);
          
            int amountInFile3 = CountOccurrences(file3, word);
            
            int max = GetMaximum(amountInFile1, amountInFile2, amountInFile3);

            switch (max)
            {
                case -1:
                    result.name = word;
                    result.amount = 0;
                    break;
                case 0:
                    result.name = word;
                    result.amount = amountInFile1;
                    result.FlieName = "All";
                    break;
                case 1:
                    result.name = word;
                    result.amount = amountInFile1;
                    result.FlieName = "File 1";
                    break;
                case 2:
                    result.name = word;
                    result.amount = amountInFile2;
                    result.FlieName = "File 2";
                    break;
                case 3:
                    result.name = word;
                    result.amount = amountInFile3;
                    result.FlieName = "File 3";
                    break;
            }

            return result;
        }

        private int GetMaximum(int num1, int num2, int num3)
        {
            if(num1==num2 && num2 == num3)
            {
                if (num1 == -1)
                {
                    return -1;
                }
                return 0;
            }
            if(num1 > num2)
            {
                if(num1 > num3)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else if (num2 > num3)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private int CountOccurrences(List<Word> wordsInList, string word)  
        {
            int index=BinarySearch.Search(wordsInList, word);//O(log n)
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
                if (item.name == word) o(n)
                {
                    return item.amount;
                }
            }
            return 0;*/
        }

        private void InserInList(List<Word> words, string textFromFile)
        {
            string[] WordsIntext = textFromFile.Split(splitItems);
            foreach (var word in WordsIntext) // O(n)
            {

                int index = BinarySearch.Search(words, word); //O(log(n))
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
                        while (lenght > 0 && words[lenght - 1].name.CompareTo(newWord.name) == 1) //O(n)
                        {
                            lenght--;
                        }
                        words.Insert(lenght, newWord);

                    }

                }
                else
                {
                    words[index].amount++;

                }

            }
        }

        private void GetWordsFromFile(List<Word> file, int amount)
        {
            foreach(var item in file)
            {
                while (item.amount > 0 && amount>0)
                {
                    Console.Write(item.name + " - ");
                    item.amount--;
                    amount--;
                }
                
            }
            
        }
    }
}
