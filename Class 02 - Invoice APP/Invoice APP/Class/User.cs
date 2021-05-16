using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_APP.Class
{
    public class User : Human
    {
        public int Balance { get; set; }
        public List<Invoice> Invoices { get; set; }

        public User(string fName, string lName, string userName, string pass, int balance, List<Invoice> invoices) : base(fName, lName, userName, pass)
        {
            Balance = balance;
            Invoices = invoices;
        }

        public void IncreaseBalance()
        {
            Console.WriteLine("Please enter sum to increase your balance: ");
            string sum = Console.ReadLine();
            bool sumParse = int.TryParse(sum, out int sumIntParsed);
            if (sumParse && sumIntParsed >0)
            {
                Balance += sumIntParsed;
                Console.WriteLine($"New Balance status: {Balance}");
            }
            else
            {
                Console.WriteLine("Wrong input !!!");
            }
        }

        public void PayInvoice()
        {
            if (Invoices.Count != 0)
            {
                Console.WriteLine("Choose invoice to pay :");
                for (int i = 0; i < Invoices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Invoices[i].Company}");
                }
                string choice = Console.ReadLine();
                bool successfulParse = int.TryParse(choice, out int parsedChoice);

                if (successfulParse)
                {

                    Invoice inv = Invoices[parsedChoice-1];
                    if (inv != null)
                    {
                        if ((int)inv.Payed == 1)
                        {
                            Console.WriteLine($"This {inv.Company} invoice is already payed");
                            return;
                        }
                        if (Balance >=inv.CalculateFullPayment())
                        {
                            Console.WriteLine($"The invoice {inv.Company} has been successfully payed. Price: {inv.CalculateFullPayment()}");
                            Balance -= inv.CalculateFullPayment();
                            Console.WriteLine($"{FirstName} - You have: {Balance} denars left on your account.");
                            inv.Payed = EnumInvoice.Payed;
                        }else
                        {
                            Console.WriteLine("Not enough money on your account !!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Wrong input !!!");
                    }
                }
            }
            else
            {
                Console.WriteLine("You don't have any invoice !");
            }

        }
        public void OverviewAllInvoices()
        {
            for (int i = 0; i < Invoices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Invoices[i].Company}- Amount: {Invoices[i].CalculateFullPayment()} - Status: {Invoices[i].Payed}");
            }
            Console.WriteLine($"Current balance = {Balance}");
        }
    }
}
