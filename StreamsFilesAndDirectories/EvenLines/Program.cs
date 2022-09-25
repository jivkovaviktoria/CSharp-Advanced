namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            HashSet<char> hs = new HashSet<char>() { '-', ',', '.', '!', '?' };
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    int count = 0;
                    if (count % 2 == 0)
                    {
                        string[] tokens = line.Split();
                        tokens = tokens.Reverse().ToArray();

                        for (int i = 0; i < tokens.Length; i++)
                        {
                            for (int j = 0; j < tokens[i].Length; j++)
                            {
                                if (hs.Contains(tokens[i][j]))
                                    tokens[i] = tokens[i].Replace(tokens[i][j], '@');

                            }
                        }

                        sb.AppendLine(tokens.ToString());
                    }
                    count++;
                }
            }

            return sb.ToString();
        }
    }
}