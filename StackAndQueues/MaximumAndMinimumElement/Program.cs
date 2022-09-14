using System;
using System.Collections.Generic;

namespace MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StackWithMaxAndMin stack = new StackWithMaxAndMin();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                int operation = int.Parse(tokens[0]);

                if (operation == 1)
                {
                    int num = int.Parse(tokens[1]);
                    stack.push(num);
                }
                else if (operation == 2)
                    stack.pop();
                else if (operation == 3)
                    Console.WriteLine(stack.getMax());
                else if (operation == 4)
                    Console.WriteLine(stack.getMin());
            }

            stack.Print();
        }
    }

    public class StackWithMaxAndMin
    {
        static Stack<int> mainStack = new Stack<int>();

        static Stack<int> trackStackMax = new Stack<int>();
        static Stack<int> trackStackMin = new Stack<int>();

        public void Print()
        {
            Console.WriteLine(String.Join(", ", mainStack));
        }

        public void push(int x)
        {
            mainStack.Push(x);
            if (mainStack.Count == 1)
            {
                trackStackMax.Push(x);
                trackStackMin.Push(x);
                return;
            }
            if (x > trackStackMax.Peek())
                trackStackMax.Push(x);
            if (x < trackStackMin.Peek())
                trackStackMin.Push(x);
            else
                trackStackMax.Push(trackStackMax.Peek());
            trackStackMin.Push(trackStackMin.Peek());
        }

        public int getMax()
        {
            return trackStackMax.Peek();
        }

        public int getMin() 
        { 
            return trackStackMin.Peek(); 
        }
        

        public void pop()
        {
            if (mainStack.Count > 0)
            {
                mainStack.Pop();
                trackStackMax.Pop();
                trackStackMin.Pop();
            }
        }
    }

}