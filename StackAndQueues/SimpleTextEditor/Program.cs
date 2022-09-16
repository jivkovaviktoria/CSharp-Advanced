using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            StringBuilder prevVersion = new StringBuilder();

            Stack<List<string>> operationsTrack = new Stack<List<string>>();

            int operationsCount = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();

            for (int i = 0; i < operationsCount; i++)
            {
                List<string> tokens = input.Split().ToList();
                var cmd = tokens[0];

                if (cmd == "1")
                {
                    text = text.Append(tokens[1]);
                    operationsTrack.Push(tokens);
                }
                else if (cmd == "2")
                {
                    var textToRemove = text.ToString(text.Length - int.Parse(tokens[1]), int.Parse(tokens[1]));
                    text = text.Remove(text.Length - int.Parse(tokens[1]), int.Parse(tokens[1]));

                    tokens.Add(textToRemove);
                    operationsTrack.Push(tokens);
                }
                else if (cmd == "3")
                {
                    var index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index-1]);
                }
                else if (cmd == "4")
                {
                    prevVersion = text;
                    var prevOperation = operationsTrack.Pop();
                    var operation = prevOperation[0];
                    var symbols = prevOperation[1];

                    if(operation == "1")
                    {
                        prevVersion = prevVersion.Remove(prevVersion.Length-symbols.Length, symbols.Length);
                        text = prevVersion;
                    }
                    else if(operation == "2")
                    {
                        var removedText = prevOperation[2];
                        prevVersion = prevVersion.Append(removedText);
                        text = prevVersion;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}