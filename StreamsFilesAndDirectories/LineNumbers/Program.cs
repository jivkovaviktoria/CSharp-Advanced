namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            HashSet<char> hs = new HashSet<char>() { '-', ',', '.', '!', '?', '\'', '@' };
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int lineCount = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var marksCount = 0;
                        var lettersCount = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (hs.Contains(line[i])) marksCount++;
                            if (char.IsLetter(line[i])) lettersCount++;
                        }
                        writer.WriteLine($"Line {lineCount}: {line} ({lettersCount})({marksCount})");
                        lineCount++;
                    }
                }
            }
        }
    }
}
