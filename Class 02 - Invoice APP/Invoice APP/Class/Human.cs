using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_APP.Class
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        private string Password { get; set; }

        public Human(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }

        public bool CheckPassword(string pass)
        {
            if (pass == Password)
            {
                return true;
            }
            return false;
        }
    }
}
