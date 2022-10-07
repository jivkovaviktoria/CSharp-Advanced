using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    internal class EqualityScale<T>
        where T : struct
    {
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T Left { get; set; }
        public T Right { get; set; }

        public bool AreEqual()
        {
            if (this.Left.Equals(this.Right)) return true;
            else return false;
        }
    }
}
