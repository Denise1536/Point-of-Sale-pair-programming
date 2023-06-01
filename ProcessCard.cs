using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ProcessCard : PaymentMethods
    {

        
        public string CreditCard()
        {
            //Putting these all as strings: since we're not doing math with it, we don't need int.
            Console.WriteLine("What is your credit card number?");
            string ccNumber = Console.ReadLine();

            Console.WriteLine("What is the expiration date (mm/yy)?");
            string expDate = Console.ReadLine();

            Console.WriteLine("What is the CVV (on the back)?");
            string cvvNumber = Console.ReadLine();

            return $"You paid by credit card. Your credit card number is {ccNumber}, Expiration: {expDate}. CCV: {cvvNumber}.";
        }







    }
}
