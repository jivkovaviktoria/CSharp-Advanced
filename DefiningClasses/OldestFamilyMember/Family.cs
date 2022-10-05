using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    internal class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMember(Person member) => this.People.Add(member);
        public Person GetOldestMember() => this.People.OrderByDescending(x => x.Age).FirstOrDefault();
        
    }
}
