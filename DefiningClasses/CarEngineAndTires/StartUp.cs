﻿namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new Tire[4]
            {
                new Tire(1, 1.25),
                new Tire(1, 2.1),
                new Tire(2, 2.5),
                new Tire(2, 2.3)
            };

            var engine = new Engine(560, 6200);
            var car = new Car("Lambo", "urus", 2010, 250, 9, engine, tires);
        }
    }
}
