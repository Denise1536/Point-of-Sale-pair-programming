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
        
        ShoppingCart Order = new ShoppingCart();
        public void CallFinalOrder()
        {
         Order.DisplayFinalOrder();
        }

        public string MakeReceipt(int paymentChoice, double grandTotal, double salesTax, double subTotal)
        {

        switch (paymentChoice)
            {
            case 1:
                    CallFinalOrder();
                    ProcessCash Cash = new ProcessCash();
                string cashOutput = Cash.GetPayment(grandTotal);
                    return $"Your subtotal is ${subTotal}; your grand total is ${grandTotal}. Payment Info: {cashOutput}"; 
                

            case 2:
                    CallFinalOrder();
                    ProcessCard Card = new ProcessCard();
                string cardOutput = Card.GetPayment(grandTotal);
                    return $"Your subtotal is ${subTotal}; your grand total is ${grandTotal}. Payment Info: {cardOutput}"; 
                

            case 3:
                    CallFinalOrder();
                    ProcessCheck Check = new ProcessCheck();
                string checkOutput = Check.GetPayment(grandTotal);
                    return $"Your subtotal is ${subTotal}; your grand total is ${grandTotal}. Payment Info: {checkOutput}";
                

            default:
                    //user shouldn't see this...just making visual studio happy
                    return $"Your subtotal is ${subTotal}; your grand total is ${grandTotal}.";
                    
            }
            
        }
    }
}


