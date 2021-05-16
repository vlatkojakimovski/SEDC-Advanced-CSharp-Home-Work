using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_APP.Class
{
        public class Invoice
    {
        public EnumCompany Company { get; set; }
        public int AmountToBePayed { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime IssuedYearMonth { get; set; }
        public EnumInvoice Payed { get; set; }

        public Invoice(EnumCompany company, int amountToBePayed, DateTime dueDate, DateTime issuedYearMonth)
        {
            Company = company;
            AmountToBePayed = amountToBePayed;
            DueDate = dueDate;
            IssuedYearMonth = issuedYearMonth;
            Payed = EnumInvoice.Unpayed;
        }

        public int CalculateFullPayment()
        {
            DateTime now = DateTime.Now;
            //Console.WriteLine($"You late {(now - DueDate).Days} days !");
            if (((DueDate - now).Days) >= 0)
            {
                return 0;
            }
            return ((now - DueDate).Days) * 10 + AmountToBePayed;
        }

    }
}
