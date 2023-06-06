//pair programming


using Point_of_Sale_Terminal_project;
using System;
using System.Security;

double subTotal = -1;
double salesTax = -1;
double grandTotal = -1;
bool keepOrdering = true;
int numberOrdered = -1;

Menu menuInstance = new Menu();
FileManager fileManager = new FileManager(menuInstance);

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
        if(wineOrdered.InventoryCount >= quantityNumber) 
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

List<Wine> wineList = menuInstance.GetMenuList();
fileManager.LoadWineList(wineList);



//Present the menu to the user, and let them choose an item (by number or letter)

Console.WriteLine("Welcome to Platinum Pour! We have a variety of white wines for sale. Here is our menu:");

do
{
    Console.WriteLine(new string('-', 100));
    menuInstance.DisplayMenu();

    Console.WriteLine();
    Console.WriteLine("Please enter the wine you'd like to order:");
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
    numberOrdered = int.Parse(Console.ReadLine());
    //add them to the order

    Console.WriteLine("Do you want to order more? (y/n)");
    string orderMore = Console.ReadLine();
    if (orderMore == "y" || orderMore == "Y")
    { keepOrdering = true; }

    else { keepOrdering = false; }

    while (!isValidQuantity(orderedWine, input))
    {
        Console.WriteLine("That is not a valid entry, please check that you are not trying to order more bottles than we have in stock.");
        input = Console.ReadLine();
    }
} while (keepOrdering == true);




//Give the user a line total (item price * quantity)


//Allow them to re-display the menu and complete the order
//using the do while loop above for that


//Give the subtotal, sales tax, and grand total (rounding issues/math library)
salesTax = subTotal * 0.06;
grandTotal = subTotal + salesTax;
Console.WriteLine($"Your total order comes to ${subTotal}, plus ${salesTax} in tax, for a grand total of ${grandTotal}.");





//Ask for payment type
int paymentChoice = -1;

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

} while (paymentChoice != 1 && paymentChoice != 2 && paymentChoice != 3);

fileManager.SaveWineList(wineList);


//Display a receipt with items ordered, subtotal, grand total, payment info
//This will happen based on the do while loop above. 


//Return to the original menu for a new order