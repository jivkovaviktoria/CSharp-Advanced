using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    internal class Bakery
    {
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Employees = new List<Employee>();
        }

        public List<Employee> Employees { get; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Employee> data => this.Employees;
        public int Count => this.Employees.Count;

        public void Add(Employee employee)
        {
            if (this.Employees.Count != this.Capacity)
                this.Employees.Add(employee);
        }

        public bool Remove(string name)
        {
            var employeeToRemove = this.Employees.Find(x => x.Name == name);
            if (employeeToRemove != null)
            {
                this.Employees.Remove(employeeToRemove);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return this.Employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return this.Employees.Find(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employee in this.Employees)
                sb.AppendLine(employee.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}

