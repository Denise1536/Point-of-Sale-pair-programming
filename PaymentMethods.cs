using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class PaymentMethods
    {
        //class and 3 subclasses, switch to call each


        double ProcessCash() 
        {
            double change = -1;
            
            Console.WriteLine("How much cash are you paying with?");
            double cash = double.Parse(Console.ReadLine()); 
            change = cash - grandTotal;
            return change;
        }


        int AskCheckNumber()
        {
            Console.WriteLine("What is the check number?");
            int checkNumber = int.Parse(Console.ReadLine());
            return checkNumber;
        }

        //if someone pays with credit card


        List<CardInfo> card = new List<CardInfo>();
        public List<CardInfo> CreditCard()
        {
            
            Console.WriteLine("What is your credit card number?");
            Console.WriteLine("What is the expiration date (mm/yy)?");
            Console.WriteLine("What is the CVV (on the back)?");
        }


    }
}
