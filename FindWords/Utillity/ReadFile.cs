namespace FindWords.Utillity
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Defines the <see cref="ReadFile" />.
    /// </summary>
    public static class ReadFile
    {
        /// <summary>
        /// Defines the _filePath to store the directory of project root
        /// </summary>
        private static string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

        /// <summary>
        /// Reads a file from folder of project
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ReadingFromFile(string fileName)
        {
            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName).FullName).FullName;
            path += fileName;

            string text = " ";
            try
            {
                var streamReader = new StreamReader(path, Encoding.UTF8);
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
