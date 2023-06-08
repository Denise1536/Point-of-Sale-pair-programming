using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ReceiptMaker
    {
        //To create the receipt with items ordered, subtotal, grand total, payment info
        
        public ShoppingCart Order {get; set;}


        public void CallFinalOrder()
        {
         Order.DisplayFinalOrder();
        }

        public void MakeReceipt(int paymentChoice, double grandTotal, double salesTax, double subTotal)
        {

            switch (paymentChoice)
            {
                case 1:
                    ProcessCash Cash = new ProcessCash();
                    string cashOutput = Cash.GetPayment(grandTotal);
                    Order.DisplayFinalOrder();
                    Console.WriteLine(cashOutput);
                    break;

                case 2:
                   
                    ProcessCard Card = new ProcessCard();
                    Order.DisplayFinalOrder();
                    string cardOutput = Card.GetPayment(grandTotal);
                    Console.WriteLine(cardOutput);
                        break;

                case 3:
                  
                    ProcessCheck Check = new ProcessCheck();
                   string checkOutput = Check.GetPayment(grandTotal);
                    Order.DisplayFinalOrder();
                    Console.WriteLine(checkOutput);
                    break;
                   

                default:
                    //user shouldn't see this...just making visual studio happy
                    Console.WriteLine($"Your subtotal is ${subTotal}; your grand total is ${grandTotal}.");
                    break;
            }






        }
    }
}

