using Invoice_APP.Class;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoice_APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Invoice invEvn = new Invoice(EnumCompany.EVN, 3200, new DateTime(2021,04,04), new DateTime(2021, 03,03));
            Invoice invBeg = new Invoice(EnumCompany.BEG, 1200, new DateTime(2021, 04, 10), new DateTime(2021, 03, 05));
            Invoice invTelekom = new Invoice(EnumCompany.Telekom, 2700, new DateTime(2021, 03, 15), new DateTime(2021, 03, 09));
            Invoice invTelekom2 = new Invoice(EnumCompany.Telekom, 4700, new DateTime(2021, 03, 15), new DateTime(2021, 03, 09));

            Invoice invVodovod = new Invoice(EnumCompany.Vodovod, 900, new DateTime(2021, 04, 28), new DateTime(2021, 03, 17));

            List<Invoice> invoicesList = new List<Invoice>()
            {
                //invEvn,
                invBeg,
                invTelekom,
                invVodovod
            };
            
            List<User> usersList = new List<User>()
            {
                new User("Vlatko", "Jakimovski", "Vlatko","Vlatko123", 3600, invoicesList),
                new User("Bob", "Bobsky", "Bob.Bobsky","Bob123", 12000, new List<Invoice>{ })
            };



            usersList[1].Invoices.Add(new Invoice(EnumCompany.EVN, 4200, new DateTime(2021, 03, 20), new DateTime(2021, 03, 01)));
            usersList[1].Invoices.Add(invTelekom2);


            User userOne = new User("Vlatko", "Jakimovski", "Vlatko.Jakimovski","Vlatko123", 8000, invoicesList);


            List<AdminUser> adminUserList = new List<AdminUser>()
            {
                new AdminUser("admin", "admin", "admin", "admin", EnumCompany.Telekom),
                new AdminUser("admin1", "admin1", "admin1", "admin1", EnumCompany.EVN)
            };

            while (true)
            {
                Human loggedUser1 = LogIn(usersList, adminUserList);
                if (loggedUser1 == null)
                {
                    Console.WriteLine("Unsuccessfull Logging in !  Press Enter and try again.");
                    Console.ReadLine();
                    continue;
                }

                if (loggedUser1.GetType().Name == "User")
                {
                    User loggedUser = (User)loggedUser1;
                    if (loggedUser != null)
                    {
                        loggedUserActions();
                        void loggedUserActions()
                        {
                            switch (UserMenu())
                            {
                                case "1":
                                    Console.Clear();
                                    loggedUser.IncreaseBalance();
                                    loggedUserActions();
                                    break;
                                case "2":
                                    Console.Clear();
                                    loggedUser.PayInvoice();
                                    loggedUserActions();
                                    break;
                                case "3":
                                    Console.Clear();
                                    loggedUser.OverviewAllInvoices();
                                    loggedUserActions();
                                    break;
                                case "4":
                                    Console.Clear();
                                    Console.WriteLine("Logging out . . .");
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Wrong input ! \n Press ENTER and try again.");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        continue;
                    }

                }
                else
                {
                    AdminUser loggedUser = (AdminUser)loggedUser1;
                    Console.WriteLine("Need to convert to AdminUser");
                    AdminUserInvoices(loggedUser, usersList);
                    continue;
                }

            }
        }
        public static Human LogIn(List <User> users, List <AdminUser> adminUsers)
        {
            Console.WriteLine("Login to invoice application: \n\n");

            Console.WriteLine("Please enter username");
            string uName = Console.ReadLine();
            Console.WriteLine("Please enter password");
            string pass = Console.ReadLine();

            User usr = users.FirstOrDefault(x => x.UserName == uName && x.CheckPassword(pass));
            AdminUser admUsr = null;

            if (usr != null)
            {
                Console.WriteLine($"Successfully logged user: {usr.FirstName} {usr.LastName}");
                return usr;
            }

            admUsr = adminUsers.FirstOrDefault(x => x.UserName == uName && x.CheckPassword(pass));

            if (admUsr != null)
            {
                Console.WriteLine($"Successfully logged user: {admUsr.FirstName} {admUsr.LastName}");
                return admUsr;
            }

            return null;
        }

        public static void AdminUserInvoices (AdminUser admin, List<User> users)
        {
            List<User> usr = users.Where(x => x.Invoices != null).ToList();
            List<Invoice> inv = usr.SelectMany(x => x.Invoices).Where(x => x.Company == admin.EmployedInCompany).ToList();
            Console.WriteLine(string.Join("\n", inv.Select(x => $"{x.Company} - Amount: {x.AmountToBePayed} den. - Status: {x.Payed}")));
        }

        public static string UserMenu ()
        {
            Console.WriteLine("1. Increase your balance !");
            Console.WriteLine("2. Pay invoice.");
            Console.WriteLine("3. Overviewe all invoices: ");
            Console.WriteLine("4. Log Out ! ");

            string choice = Console.ReadLine();
            return choice;
        }


    }
}
