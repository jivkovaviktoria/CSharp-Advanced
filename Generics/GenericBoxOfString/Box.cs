using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    internal class Box<T>
    {
        public T value { get; set; }
        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
}
