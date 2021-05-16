using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_APP.Class
{
    public class AdminUser : Human
    {
        public EnumCompany EmployedInCompany { get; set; }

        public AdminUser(string fName, string lName, string userName, string pass, EnumCompany employedInCompany) : base(fName, lName, userName, pass)
        {
            EmployedInCompany = employedInCompany;
        }
    }
}
