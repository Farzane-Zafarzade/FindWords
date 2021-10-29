namespace FindWords.FindWordsInFiles
{
    using FindWords.Model;
    using FindWords.Trees;
    using FindWords.Utillity;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="FindWord" />.
    /// </summary>
    public class FindWord
    {
        /// <summary>
        /// Defines the myTree(abstract data structure) to save serach results.
        /// </summary>
        private BinaryTree myTree = new();

        /// <summary>
        /// Defines the root to store information of the word that will be searched 
        /// </summary>
        private Node root = new();

        /// <summary>
        /// Defines the file1 to store the words of the first file.
        /// </summary>
        private List<Word> file1 = new();

        /// <summary>
        /// Defines the file2.
        /// </summary>
        private List<Word> file2 = new();

        /// <summary>
        /// Defines the file3.
        /// </summary>
        private List<Word> file3 = new();

        /// <summary>
        /// A array of string to store word separators in a text.
        /// </summary>
        private string[] splitItems = { " ", ".", ",", "-", "–", ";", ":", "?", "!", "\n", "\t", "(", ")", "\r", "\'", " \"", "\\", "“", "”", "/", "{", "}", "[", "]", "_", "|", "#", "$", "%" };

        /// <summary>
        /// Reads files and store content in a list of Words.
        /// </summary>
        public void ReadFiles()
        {
            string textOfFile1 = ReadFile.ReadingFromFile(@"\1000.txt").ToLower();
            InsertInList(file1, textOfFile1);
            string textOfFile2 = ReadFile.ReadingFromFile(@"\1500.txt").ToLower();
            InsertInList(file2, textOfFile2);
            string textOfFile3 = ReadFile.ReadingFromFile(@"\3000.txt").ToLower();
            InsertInList(file3, textOfFile3);
            ShowMenu();
        }

        /// <summary>
        /// Shows main menu and user can choice an option.
        /// </summary>
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

        /// <summary>
        /// Display the commands for selected option in the main menu.
        /// </summary>
        /// <param name="choice"> The selected option by user <see cref="int"/>.</param>
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
                    while (fileName != "file1" && fileName != "file2" && fileName != "file3")
                    {
                        Console.Write("\n Invalid input, try again: ");
                        fileName= fileName = Console.ReadLine().Trim().ToLower();
                    }
                    Console.Write("\n Enter The number of words: ");
                    bool Checked = int.TryParse(Console.ReadLine(),out int numberOfWords);
                    while(numberOfWords<0 || !Checked)
                    {
                        Console.Write("\n Invalid input, try again: ");
                        Checked = int.TryParse(Console.ReadLine(), out numberOfWords);
                    }
                    switch (fileName)
                    {
                        case "file1":
                            GetFirstWordsFromFile(file1, numberOfWords);
                            break;
                        case "file2":
                            GetFirstWordsFromFile(file2, numberOfWords);
                            break;
                        case "file3":
                            GetFirstWordsFromFile(file3, numberOfWords);
                            break;
                    }
                    BackToMenu();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("\n Search results: \n");
                    myTree.Traverse(root);
                    BackToMenu();
                    break;

                case 4:
                    System.Environment.Exit(1);
                    break;
            }
        }

        /// <summary>
        /// Returns to main menu or exits the program 
        /// </summary>
        private void BackToMenu()
        {
            Console.Write("\n Do you want to back to menu: (y/n)  ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y")
            {
                ShowMenu();
            }
            else if (input == "n")
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.Write("\n Invalid input, enter 'y' or 'n': ");
                input = Console.ReadLine().ToLower().Trim();
            }

        }

        /// <summary>
        /// Finds the maximum number of occurrences of a word in three files.
        /// </summary>
        /// <param name="word">The search item <see cref="string"/>.</param>
        /// <returns>The <see cref="Word"/>.</returns>
        /// Time complexity: O(logn)
        private Word FindMaxOccurrences(string word)
        {
            Word result = new();

            int amountInFile1 = CountOccurrences(file1, word); //O(log n)

            int amountInFile2 = CountOccurrences(file2, word); //O(log n)

            int amountInFile3 = CountOccurrences(file3, word); //O(log n)

            int max = GetMaximum(amountInFile1, amountInFile2, amountInFile3); //o(3)

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
        /// Find and returns the largest number.
        /// </summary>
        /// <param name="num1">The first number <see cref="int"/>.</param>
        /// <param name="num2">The second number <see cref="int"/>.</param>
        /// <param name="num3">The third number <see cref="int"/>.</param>
        /// <returns> The largets number  <see cref="int"/>.</returns>
        /// Time complexity O(3)
        private int GetMaximum(int num1, int num2, int num3)
        {
            if (num1 == num2 && num2 == num3)
            {
                if (num1 == -1)
                {
                    return -1;
                }
                return 0;
            }
            if (num1 > num2)
            {
                if (num1 > num3)
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
        /// Returns the number of occurrences of a word in a file.
        /// </summary>
        /// <param name="wordsInList"> The List of words <see cref="List{Word}"/>.</param>
        /// <param name="word"> The new word <see cref="string"/>.</param>
        /// <returns> the number of occurrences <see cref="int"/>.</returns>
        /// Time complexity //O(log n)
        private int CountOccurrences(List<Word> wordsInList, string word)
        {
            int index = BinarySearch.Search(wordsInList, word);
            if (index >= 0)
            {
                return wordsInList[index].amount;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Separates words in a text then inserts words in a list of Word(Word Class).
        /// Before inserting a new word, it checks if the word is in file
        /// If the word does not exist, it will be added to the list in right place(the list is sorted)
        /// if the word exist, its amount increase
        /// </summary>
        /// <param name="words"> The list of words <see cref="List{Word}"/>.</param>
        /// <param name="textFromFile"> The text of file <see cref="string"/>.</param>
        /// Time complexity worst case: o(n^2) - best case: O(nlogn)
        public void InsertInList(List<Word> words, string textFromFile)
        {
            string[] WordsIntext = textFromFile.Split(splitItems, StringSplitOptions.RemoveEmptyEntries);
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

        /// <summary>
        /// Shows the X first words in a file
        /// </summary>
        /// <param name="file"> The file that will gott the words from <see cref="List{Word}"/>.</param>
        /// <param name="num"> number of words<see cref="int"/>.</param>
        /// Time complexity: O(n) 
        private void GetFirstWordsFromFile(List<Word> file, int num)
        {
            foreach (var item in file)
            {
                while (item.amount > 0 && num > 0)
                {
                    Console.Write(item.name + " - ");
                    item.amount--;
                    num--;
                }

            }
        }
    }
}
