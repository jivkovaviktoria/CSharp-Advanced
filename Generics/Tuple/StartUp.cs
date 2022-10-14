using System;

namespace Tuple
{

    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] person = Console.ReadLine().Split(' ');
            var firstName = person[0];
            var lastName = person[1];
            var address = person[2];

            string[] personBeer = Console.ReadLine().Split();
            var name = personBeer[0];
            var beer = double.Parse(personBeer[1]);

            string[] integerAndDouble = Console.ReadLine().Split();
            var intNum = int.Parse(integerAndDouble[0]);
            var doubleNum = double.Parse(integerAndDouble[1]);

            Tuple<string, string, string> personInfo = new Tuple<string, string, string>(firstName, lastName, address);
            Tuple<string, double> personBeerInfo = new Tuple<string, double>(name, beer);
            Tuple<int, double> integerAndDoubleInfo = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(personInfo.ToString());
            Console.WriteLine(personBeerInfo.ToString());
            Console.WriteLine(integerAndDoubleInfo.ToString());
        }
    }

    public class Tuple<K, V>
    {
        private readonly K key;
        private readonly V value;

        public Tuple(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{this.key} -> {this.value}";
        }
    }

    public class Tuple<V1, V2, V3>
    {
        private readonly V1 value1;
        private readonly V2 value2;
        private readonly V3 value3;

        public Tuple(V1 val1, V2 val2, V3 val3)
        {
            this.value1 = val1;
            this.value2 = val2;
            this.value3 = val3;
        }

        public override string ToString()
        {
            return $"{this.value1} {this.value2} -> {this.value3}";
        }
    }
}
