using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ProcessCheck : PaymentMethods
    {

       public override string GetPayment(double grandTotal)
        {
            Console.WriteLine("What is the check number?");
            string checkNumber = Console.ReadLine();
            return $"You paid with check number {checkNumber}.";
        }







    }
}
