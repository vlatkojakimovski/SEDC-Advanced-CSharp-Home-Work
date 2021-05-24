using Class_03.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Class_03.Models
{
    public abstract class User : IUser
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
        }


        public virtual void PrintUser()
        {
            Console.WriteLine($"{Id}: Name: {Name}  Username: {Username}");
        }
    }
}
