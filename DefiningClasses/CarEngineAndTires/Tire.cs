using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }

        private int year;
        private double pressure;

        public int Year { get { return this.year; } private set { this.year = value; } }
        public double Pressure { get { return this.pressure; } private set { this.pressure = value; } }
    }
}
