using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ReceiptMaker
    {
        //To create the receipt with items ordered, subtotal, grand total, payment info
        //TO DO: pass in list with order & add it to each case
        public string MakeReceipt(string paymentChoice, double grandTotal, double salesTax, double subTotal)
        {

        switch (paymentChoice)
            {
            case "1":
                ProcessCash Cash = new ProcessCash();
                string cashOutput = Cash.GetPayment(grandTotal);
                    Console.WriteLine($"Your subtotal is ${subTotal}; your grand total is ${grandTotal}.");
                    Console.WriteLine($"Payment Info: {cashOutput}");
                break;

            case "2":
                ProcessCard Card = new ProcessCard();
                string cardOutput = Card.GetPayment(grandTotal);
                    Console.WriteLine($"Your subtotal is ${subTotal}; your grand total is ${grandTotal}.");
                    Console.WriteLine($"Payment Info: {cardOutput}");
                break;

            case "3":
                ProcessCheck Check = new ProcessCheck();
                string checkOutput = Check.GetPayment(grandTotal);
                    Console.WriteLine($"Your subtotal is ${subTotal}; your grand total is ${grandTotal}.");
                    Console.WriteLine($"Payment Info: {checkOutput}");
                break;

            default:
                    //user shouldn't see this...just making visual studio happy
                    Console.WriteLine($"Your subtotal is ${subTotal}; your grand total is ${grandTotal}.");
                    break;
            }
        }
    }
}


