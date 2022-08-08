namespace ReversedStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedInput = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
                reversedInput.Push(input[i]);

            int count = reversedInput.Count;

            for (int i = 0; i < count; i++)
                Console.Write(reversedInput.Pop());
        }
    }
}