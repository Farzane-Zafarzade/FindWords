using FindWords.FindWordsInFiles;


namespace FindWords
{
    class Program
    {
        static void Main(string[] args)
        {
           
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
