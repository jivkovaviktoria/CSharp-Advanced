using System;
using System.Linq;

namespace Threeuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var person = Console.ReadLine().Split();
            string firstName = person[0], lastName = person[1], address = person[2], town = string.Join(" ", person.Skip(3));

            var personBeer = Console.ReadLine().Split();
            string name = personBeer[0];
            double lt = double.Parse(personBeer[1]);

            bool isDrunk;
            if (personBeer[2] == "drunk") isDrunk = true;
            else isDrunk = false;

            var personBank = Console.ReadLine().Split();
            string personName = personBank[0], bank = personBank[2];
            double balance = double.Parse(personBank[1]);

            Threeuple<string, string, string, string> personInfo = new Threeuple<string, string, string, string>(firstName, lastName, address, town);
            Threeuple<string, double, bool> personBeerInfo = new Threeuple<string, double, bool>(name, lt, isDrunk);
            Threeuple<string, double, string> personBankInfo = new Threeuple<string, double, string>(personName, balance, bank);

            Console.WriteLine(personInfo.ToString());
            Console.WriteLine(personBeerInfo.ToString());
            Console.WriteLine(personBankInfo.ToString());
        }
    }

    public class Threeuple<V1, V2, V3>
    {
        private readonly V1 val1;
        private readonly V2 val2;
        private readonly V3 val3;

        public Threeuple(V1 v1, V2 v2, V3 v3)
        {
            this.val1 = v1;
            this.val2 = v2;
            this.val3 = v3;
        }

        public override string ToString()
        {
                return $"{val1} -> {val2} -> {val3}";
        }
    }
    public class Threeuple<V1, V2, V3, V4>
    {
        private readonly V1 val1;
        private readonly V2 val2;
        private readonly V3 val3;
        private readonly V4 val4;

        public Threeuple(V1 v1, V2 v2, V3 v3, V4 v4)
        {
            this.val1 = v1;
            this.val2 = v2;
            this.val3 = v3;
            this.val4 = v4;
        }

        public override string ToString()
        {
            return $"{val1} {val2} -> {val3} -> {val4}";
        }
    }
}
