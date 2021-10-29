using System;
using FindWords.Utillity;
using FindWords.Model;
using FindWords.Trees;
using System.Collections.Generic;

namespace FindWords.FindWordsInFiles
{
    public class FindWord
    {
        // Instans av binära trädet för att lagra vår söknings resultat
        private BinaryTree myTree = new();
        // Det första nodet av trädet
        private Node root = new();
        // En list för att lagra ord som läsas in från textfilen.
        private List<Word> file1 = new();
        private List<Word> file2 = new();
        private List<Word> file3 = new();
        //Tecken som separerar ordena i filerna.
        private string[] splitItems = { " ", ".", ",", "-", "–", ";", ":", "?", "!" ,"\n", "\t", "(", ")", "\r", "\'", " \"", "\\", "“", "”", "/", "{", "}", "[", "]", "_", "|", "#", "$", "%"};

        //Metoden som initialiserar programmet.
        public void Run()
        {
            Console.Write("\n Enter the first file path: ");
            ReadFile.pathFile = Console.ReadLine();
            string textOfFile1 = ReadFile.ReadingFromFile().ToLower();
            InsertInList(file1, textOfFile1);
            Console.Write("\n Enter the second file path: ");
            ReadFile.pathFile = Console.ReadLine();
            string textOfFile2 = ReadFile.ReadingFromFile().ToLower();
            InsertInList(file2, textOfFile2);
            Console.Write("\n Enter the third file path: ");
            ReadFile.pathFile = Console.ReadLine();
            string textOfFile3 = ReadFile.ReadingFromFile().ToLower();
            InsertInList(file3, textOfFile3);
            ShowMenu();
        }

        //Visa huvudmeny för valen i programmet för användare.
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

        //Visa kommande steg som användaren har valt i huvudmenyn.
        public void ShowSelectedOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.Write("\n Enter the word you want to search: ");
                    string searchWord = Console.ReadLine().ToLower().Trim();
                    Word newWord = FindMaxOccurrences(searchWord);
                    Console.WriteLine("\n Max amount of {0} is {1} in {2}", newWord.name, newWord.amount, newWord.FileName);
                    myTree.Insert(root, newWord);
                    BackToMenu();
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("\n Choose the file you want to show words from that (file1 , file2 , file3): ");
                    string fileName = Console.ReadLine().Trim().ToLower();
                    Console.Write("\n Enter The number of words: ");
                    _= int.TryParse(Console.ReadLine(), out int numberOfWords);
                    if(numberOfWords <= 0)
                    {
                        Console.WriteLine("Invalid input, please enter a positive number.");
                        Console.Write("\n Enter The number of words: ");
                        _= int.TryParse(Console.ReadLine(), out numberOfWords);
                    }
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

        /// <summary>
        /// Visa alternativt val om användaren vill återgå tillbaka 
        /// till huvudmenyn eller att avsluta.
        /// </summary>
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

        /// <summary>
        /// Kontrollera om användaren har rätt typ av inmatning.
        /// </summary>
        /// <param name="input">Användarens inmatning</param>
        /// <returns>inmatning i sträng</returns>
        private string CheckInput(string input)
        {
            while (input != "n" && input != "y")
            {
                Console.Write("\n Invalid input, enter 'y' or 'n': ");
                input = Console.ReadLine().ToLower().Trim();
            }
            return input;
        }


        /// <summary>
        /// Att hitta den mest förekommande ord som användare söker.
        /// </summary>
        /// <param name="word">sökord</param>
        /// <returns>Lista av ord</returns>
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
                    result.FileName = " none of files ";
                    break;
                case 0:
                    result.name = word;
                    result.amount = amountInFile1;
                    result.FileName = "all files";
                    break;
                case 1:
                    result.name = word;
                    result.amount = amountInFile1;
                    result.FileName = "File 1";
                    break;
                case 2:
                    result.name = word;
                    result.amount = amountInFile2;
                    result.FileName = "File 2";
                    break;
                case 3:
                    result.name = word;
                    result.amount = amountInFile3;
                    result.FileName = "File 3";
                    break;
            }
            return result;
        }

        /// <summary>
        /// Metoden ger det största talet utav 3 tal som inparametrar.
        /// </summary>
        /// <param name="num1">tal1</param>
        /// <param name="num2">tal2</param>
        /// <param name="num3">tal3</param>
        /// <returns>det största talet</returns>
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

        /// <summary>
        /// Sökmetoden för att hitta ett ords förekomster i en lista av ord.
        /// </summary>
        /// <param name="wordsInList">lista av ord</param>
        /// <param name="word">sökord</param>
        /// <returns>Förekomster av ordet i listan.</returns>
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
        }

        /// <summary>
        /// Metoden tar emot ord i en lista. Om ordet finns i listan, ökar ordets antal(amount) med 1.
        /// Om ordet inte finns, läggs ordet till i listan.
        /// </summary>
        /// <param name="words">Lista av objekt Word</param>
        /// <param name="textFromFile"></param>        
        private void InsertInList(List<Word> words, string textFromFile)
        {
            string[] WordsIntext = textFromFile.Split(splitItems,StringSplitOptions.RemoveEmptyEntries);
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

        //Skriv ut de antal ord i början av listan som användaren angett.
        private void GetWordsFromFile(List<Word> file, int num)
        {
            foreach(var item in file)
            {
                while (item.amount > 0 && num>0)
                {
                    Console.Write(item.name + " - ");
                    item.amount--;
                    num--;
                }
            }
        }
    }
}
