using Class_03.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class_03.Models
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public Student(List<int> grades, int id, string name, string username, string password) : base (id,name,username,password)
        {
            Grades = grades;
        }

        public override void PrintUser()
        {
            Console.WriteLine($"{Name } - Grades: \n");
            for (int i = 0; i < Grades.Count; i++)
            {
                Console.WriteLine($"{i}. - {Grades[i]}");
            }
            Console.WriteLine("===================================");
        }
    }
}
