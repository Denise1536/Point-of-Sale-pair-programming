using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ProcessCheck : PaymentMethods
    {
        public bool IsValidCheckNumber(string checkNumber)
        {
            if (checkNumber.All(char.IsDigit) && !string.IsNullOrWhiteSpace(checkNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public override string GetPayment(double grandTotal)
        {
            Console.WriteLine("What is the check number?");
            string checkNumber = Console.ReadLine();
            while(!IsValidCheckNumber(checkNumber))
            {
                Console.WriteLine("That is not a valid check number. Please try again, entering only numbers:");
                checkNumber = Console.ReadLine();
            }
            return $"You paid ${grandTotal} with check number {checkNumber}.";
        }







    }
}
