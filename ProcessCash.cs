using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ProcessCash : PaymentMethods
    {
        public bool IsEnoughCash(string cashTendered, double grandTotal)
        {
            if (!string.IsNullOrEmpty(cashTendered) && cashTendered.All(char.IsDigit) && double.Parse(cashTendered) >= grandTotal)
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
            double change = -1;

            Console.WriteLine("How much cash are you paying with?");
            string input = Console.ReadLine();
            while (!IsEnoughCash(input, grandTotal))
            {
                Console.WriteLine("That is not a valid entry. Please try again, make sure you enter only numbers and have enough to cover the bill:");
                input = Console.ReadLine();
            }
            double cash = double.Parse(input);
            change = cash - grandTotal;
            return $"You paid ${cash} in cash. Your change is ${change}.";
        }









    }
}
