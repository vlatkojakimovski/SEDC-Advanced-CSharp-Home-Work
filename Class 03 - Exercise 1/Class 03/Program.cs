using Class_03.Models;
using System;
using System.Collections.Generic;

namespace Class_03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Teacher teacher1 = new Teacher(new List<string> { "Makedonski", "Matematika" }, 2, "Vlatko", "Profe Vlatko", "Vlatko");
            Teacher teacher2 = new Teacher(new List<string> { "C Sharp", "Java", "HTML" }, 3, "Bob", "Profe Bob", "Bob");

            Student student1 = new Student(new List<int> { 5, 4, 5 }, 5, "John", "Johney", "Password");
            Student student2 = new Student(new List<int> { 3, 4, 3 }, 6, "Steve", "Stivsky", "Password2");


            teacher1.PrintUser();
            teacher2.PrintUser();

            student1.PrintUser();
            student2.PrintUser();


        }
    }
}
