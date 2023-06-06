//pair programming


using Point_of_Sale_Terminal_project;
using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;

double subTotal = -1;
double salesTax = -1;
double grandTotal = -1;
bool keepOrdering = true;
int numberOrdered = -1;
double lineTotal = -1;

Menu menuInstance = new Menu();
FileManager fileManager = new FileManager(menuInstance);
List<Wine> wineList = menuInstance.GetMenuList();
fileManager.LoadWineList(wineList);
ShoppingCart cart = new ShoppingCart();
List<Wine> wineCart = cart.returnCartList();


bool isValidBin(List<Wine> wineList, string orderedWine) 
{
    int binNumber = 0;
    if (int.TryParse(orderedWine, out binNumber))
    {
        if(wineList.Any(wine => wine.BinNumber == binNumber))
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
    else 
    {
        return false; 
    }
}

bool isValidQuantity(Wine wineOrdered, string quantityOrdered)
{
    int quantityNumber = 0;
    if(int.TryParse(quantityOrdered, out quantityNumber))
    {
        if(wineOrdered.InventoryCount >= quantityNumber && quantityNumber > 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else { return false; }

}







//Present the menu to the user, and let them choose an item (by number or letter)

Console.WriteLine("Welcome to Platinum Pour! We have a variety of white wines for sale. Here is our menu:");

do
{
    Console.WriteLine(new string('-', 117));
    menuInstance.DisplayMenu();

    Console.WriteLine();
    Console.WriteLine("Please enter just the number of the wine you'd like to order:");
    string input = Console.ReadLine();

    while (!isValidBin(wineList, input))
    {
        Console.WriteLine("That is not a valid selection, please review the Bin Numbers and try again:");
        input = Console.ReadLine();
    }
    int binNumber = int.Parse(input);
    Wine orderedWine = menuInstance.FindWine(binNumber);

    //Allow the user to choose quantity ordered
    Console.WriteLine($"How many bottles of {orderedWine.WineName}, would you like?");
    int quantityOrdered = int.Parse(input);
    cart.AddWineToCart(wineList, orderedWine, quantityOrdered);

    //lineTotal = price * quantityOrdered;
    //  priceOfQtyAdded

    //Give the user a line total (item price * quantity)
    Console.WriteLine($"That will add ${lineTotal} to your order.");
    

    Console.WriteLine("Do you want to: 1: order more; 2: edit current order; 3: finish order");
    string orderMore = Console.ReadLine();
    if (orderMore == "1" )
    { keepOrdering = true; }

    else if (orderMore == "2" ) 
    {

     //TO DO: call method DisplayCart() & then the editing ones. (Jen)

    }

    else { keepOrdering = false; }

 

    while (!isValidQuantity(orderedWine, input))
    {
        Console.WriteLine("That is not a valid entry, please check that you are not trying to order more bottles than we have in stock.");
        input = Console.ReadLine();
    }
  
} while (keepOrdering == true);



//Allow them to re-display the menu and complete the order
//using the do while loop above for that




//Give the subtotal, sales tax, and grand total (rounding issues/math library)
//TO DO: pull in methods from ShoppingCart to add to/replace variables/CW below. 
salesTax = subTotal * 0.06;
grandTotal = subTotal + salesTax;
Console.WriteLine($"Your total order comes to ${subTotal}, plus ${salesTax} in tax, for a grand total of ${grandTotal}.");


//Ask for payment type
int paymentChoice = -1;
ReceiptMaker Receipt = new ReceiptMaker();
void CallReciptMaker(int paymentChoice)
{
    Receipt.MakeReceipt();
};


do
{
    Console.WriteLine("Enter the number that matches your payment method: 1: Credit Card; 2: Cash; 3: Check");
    paymentChoice = int.Parse(Console.ReadLine());

    if (paymentChoice! > 0 || paymentChoice! < 4)
    {
        Console.WriteLine("That is not a valid option.");
    }

    else
    { CallReciptMaker(paymentChoice);}

} while (paymentChoice != 1 && paymentChoice != 2 && paymentChoice != 3);

fileManager.SaveWineList(wineList);


//Display a receipt with items ordered, subtotal, grand total, payment info
//This will happen based on the do while loop above. 


//Return to the original menu for a new order








/*
 * holding for later, may not need.
 * 
 * switch (paymentChoice)
    {
        
 * case 1:
            CallReciptMaker(paymentChoice); 
            break;

        case 2:
            //Call ReceiptMaker/ProcessCash
            break;

        case 3:
            //Call ReceiptMaker/ProcessCheck
            break;
}
*/