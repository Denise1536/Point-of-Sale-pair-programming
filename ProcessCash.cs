using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ProcessCash : PaymentMethods
    {
        string CashPayment()
        {
            double change = -1;

            Console.WriteLine("How much cash are you paying with?");
            double cash = double.Parse(Console.ReadLine());
            change = cash - grandTotal;
            return $"You paid ${cash} in cash. Your change is ${change}.";
        }









    }
}
