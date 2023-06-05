//pair programming


using Point_of_Sale_Terminal_project;
using System;

double subTotal = -1;
double salesTax = -1;
double grandTotal = -1;



//Present the menu to the user, and let them choose an item (by number or letter)
Console.WriteLine("Welcome to Platinum Pour! We have a variety of white wines for sale. Here is our menu:");
Menu FullMenu = new Menu();
FullMenu.ToString();

//Allow the user to choose quantity ordered

//Give the user a line total (item price * quantity)


//Allow them to re-display the menu and complete the order



//Give the subtotal, sales tax, and grand total (rounding issues/math library)
salesTax = subTotal * 0.06;
grandTotal = subTotal + salesTax;
Console.WriteLine($"Your total order comes to ${subTotal}, plus ${salesTax} in tax, for a grand total of ${grandTotal}.");



//Ask for payment type
int paymentChoice = -1;

//TO DO: add a try catch for Format Exception?

do
{
    Console.WriteLine("Enter the number that matches your payment method: 1: Credit Card; 2: Cash; 3: Check");
    paymentChoice = int.Parse(Console.ReadLine());

    switch (paymentChoice)
    {
        case 1:
            //Call ReceiptMaker/ProcessCard
            break;

        case 2:
            //Call ReceiptMaker/ProcessCash
            break;

        case 3:
            //Call ReceiptMaker/ProcessCheck
            break;
    }

    if (paymentChoice! > 0 || paymentChoice! < 4)
    {
        Console.WriteLine("That is not a valid option.");
    }

} while (paymentChoice > 0 || paymentChoice < 4);


//Display a receipt with items ordered, subtotal, grand total, payment info
//This will happen based on the do while loop above. 


//Return to the original menu for a new order