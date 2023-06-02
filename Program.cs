//pair programming


using Point_of_Sale_Terminal_project;
using System.Collections.Concurrent;

double subTotal = -1;
double salesTax = -1;
double grandTotal = -1;


//Present the menu to the user, and let them choose an item (by number or letter)
//Allow the user to choose quantity ordered
//Give the user a line total (item price * quantity)


//Allow them to re-display the menu and complete the order



//Give the subtotal, sales tax, and grand total (rounding issues/math library)

salesTax = subTotal * 0.06;
grandTotal = subTotal + salesTax;


//Ask for payment type
Console.WriteLine("Enter the number that matches your payment method: 1: Credit Card; 2: Cash; 3: Check");
string paymentChoice = Console.ReadLine().ToLower();
switch (paymentChoice)
{
    case "1":
        //trigger make receipt with credit card
        break;

    case "2":
        //trigger make receipt with cash
        break;

    case "3":
    //trigger make receipt with check
    break;

    default:
        Console.WriteLine("");
}


//Display a receipt with items ordered, subtotal, grand total, payment info
//Use class: ReceiptMaker


//Return to the original menu for a new order