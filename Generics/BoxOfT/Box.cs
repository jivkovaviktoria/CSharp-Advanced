using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            BoxStack = new Stack<T>();
        }

        public Stack<T> BoxStack { get; set; }
        public void Add(T element) => this.BoxStack.Push(element);
        public T Remove() => this.BoxStack.Pop();

        public int Count { get { return this.BoxStack.Count; } }

    }
}
