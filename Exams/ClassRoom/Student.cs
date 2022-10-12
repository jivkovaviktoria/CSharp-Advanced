using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    internal class Student
    {
        public Student(string fn, string ls, string subject)
        {
            FirstName = fn;
            LastName = ls;
            Subject = subject;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}
