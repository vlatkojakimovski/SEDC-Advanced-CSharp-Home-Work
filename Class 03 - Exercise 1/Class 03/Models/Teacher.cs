using Class_03.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class_03.Models
{
    public class Teacher : User, ITeacher
    {
        public List<string> Subjects { get; set; }

        public Teacher(List<string> subjects, int id, string name, string username, string password) : base(id, name, username, password)
        {
            Subjects = subjects;
        }

        public override void  PrintUser()
        {

            Console.WriteLine($"{Name } - Subjects: \n");
            foreach (string item in Subjects)
            {
                Console.WriteLine($"{item } ");
            }
            Console.WriteLine("===================================");

        }
    }
}
