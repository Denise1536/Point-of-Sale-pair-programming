using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ReceiptMaker
    {

        public string MakeReceipt(string paymentChoice, double grandTotal)
        {

        switch (paymentChoice)
            {
            case "1":
                ProcessCash Cash = new ProcessCash();
                string cashOutput = Cash.GetPayment(grandTotal);
                Console.WriteLine($"{cashOutput}");
                break;

            case "2":
                ProcessCard Card = new ProcessCard();
                string cardOutput = Card.GetPayment(grandTotal);
                Console.WriteLine($"{cardOutput}");
                break;

            case "3":
                ProcessCheck Check = new ProcessCheck();
                string checkOutput = Check.GetPayment(grandTotal);
                break;
            }
        }
    }
}


