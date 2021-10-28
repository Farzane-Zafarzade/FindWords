using System;
using System.IO;
using System.Text;

namespace FindWords.Utillity
{
    public static class ReadFile
    {
        public static string pathFile;

        public static string ReadingFromFile()
        {
            string text = "";
            try
            {
                var streamReader = new StreamReader(pathFile, Encoding.UTF8);
                text = streamReader.ReadToEnd();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return text;
        }
    }
}
