//pair programming


using Point_of_Sale_Terminal_project;
using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;

double subTotal = -1;
double salesTax = -1;
double grandTotal = -1;
bool keepOrdering = true;
bool exitSystem = false;
string orderAgain;

Menu menuInstance = new Menu();
FileManager fileManager = new FileManager(menuInstance);
List<Wine> wineList = menuInstance.GetMenuList();
fileManager.LoadWineList(wineList);
ShoppingCart cart = new ShoppingCart();
List<Wine> wineCart = cart.returnCartList();
ProcessCard card = new ProcessCard();
ProcessCash cash = new ProcessCash();
ProcessCheck check = new ProcessCheck();


bool isValidBin(List<Wine> wineList, string orderedWine)
{
    int binNumber = 0;
    if (int.TryParse(orderedWine, out binNumber))
    {
        if (wineList.Any(wine => wine.BinNumber == binNumber))
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
    if (int.TryParse(quantityOrdered, out quantityNumber))
    {
        if (wineOrdered.InventoryCount >= quantityNumber && quantityNumber > 0)
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

bool isValid123(string input)
{
    if (int.TryParse(input, out int result))
    {
        if (result == 1 || result == 2 || result == 3)
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





while (exitSystem == false)
{

    //Present the menu to the user, and let them choose an item (by number or letter)

    Console.WriteLine("Welcome to Platinum Pour! We have a variety of white wines for sale. Here is our menu:");


    do
    {
        Console.WriteLine(new string('-', 117));
        menuInstance.DisplayMenu();

        Console.WriteLine();
        Console.WriteLine("Please enter just the number of the wine you'd like to order:");
        string userInput = Console.ReadLine();

        while (!isValidBin(wineList, userInput))
        {
            Console.WriteLine("That is not a valid selection, please review the Bin Numbers and try again:");
            userInput = Console.ReadLine();
        }
        int binNumber = int.Parse(userInput);
        Wine orderedWine = menuInstance.FindWine(binNumber);

        //Allow the user to choose quantity ordered
        Console.WriteLine($"How many bottles of {orderedWine.WineName}, would you like?");
        userInput = Console.ReadLine();
        while (!isValidQuantity(orderedWine, userInput))
        {
            Console.WriteLine("That is not a valid entry, please check that you are not trying to order more bottles than we have in stock.");
            userInput = Console.ReadLine();
        }
        int quantityOrdered = int.Parse(userInput);
        cart.AddWineToCart(wineList, orderedWine, quantityOrdered);

        //lineTotal = price * quantityOrdered;
        //  priceOfQtyAdded

        //Give the user a line total (item price * quantity)
        //Console.WriteLine($"That will add ${lineTotal} to your order.");
        //!!^^This code is handled by the add wine to cart method.

        fileManager.SaveWineList(wineList);
    CartReview:
        cart.DisplayCart();
        Console.WriteLine("Do you want to: 1: order more; 2: edit current order; 3: finish order");
        string orderMore = Console.ReadLine();
        while (!isValid123(orderMore))
        {
            Console.WriteLine("That is not a valid entry.  Please enter (1) to add more items to you order, (2) to edit current order or (3) to finish and continue to payment.");
            orderMore = Console.ReadLine();
        }
        if (orderMore == "1")
        { keepOrdering = true; }

        else if (orderMore == "2")
        {

            Console.WriteLine("please enter the bin number of the wine you would like to edit:");
            userInput = Console.ReadLine();
            while (!isValidBin(wineCart, userInput))
            {
                Console.WriteLine("That is not a valid selection. Please check the bin number and try again:");
                userInput = Console.ReadLine();
            }
            int binToRemove = int.Parse(userInput);
            Wine wineToRemove = menuInstance.FindWine(binToRemove);
            Console.WriteLine("How many bottles would you like to remove?");
            userInput = Console.ReadLine();
            while (!isValidQuantity(wineToRemove, userInput))
            {
                Console.WriteLine("That is not a valid entry. Please check the amount of bottles you would like to remove and try again:");
                userInput = Console.ReadLine();
            }
            int quantityToRemove = int.Parse(userInput);
            cart.RemoveWine(wineList, wineToRemove, quantityToRemove);
            goto CartReview;

            //TO DO: call method DisplayCart() & then the editing ones. (Jen)

        }

        else { keepOrdering = false; }


    } while (keepOrdering == true);



    //Allow them to re-display the menu and complete the order
    //using the do while loop above for that

    Console.WriteLine("Here is your final order:");

    cart.DisplayFinalOrder();

    ReceiptMaker Receipt = new ReceiptMaker();
    Receipt.Order = cart;

    void CallReceiptMaker(int paymentChoice, double grandTotal, double salesTax, double subTotal)
    {
        Receipt.MakeReceipt(paymentChoice, grandTotal, salesTax, subTotal);
    };


    Console.WriteLine();

    Console.WriteLine("How would you like to pay?");
    Console.WriteLine("Enter (1) for Cash");
    Console.WriteLine("Enter (2) for Credit");
    Console.WriteLine("Enter (3) for Check");
    grandTotal = cart.GetGrandTotal();
    subTotal = cart.GetSubTotal();
    salesTax = cart.GetTax();

    string input = Console.ReadLine();
    while (!isValid123(input))
    {
        Console.WriteLine("That is not a valid entry. Please review your payment options and try again:");
        input = Console.ReadLine();
    }
    int paymentChoice = int.Parse(input);
    switch (paymentChoice)
    {
        case 1:
            CallReceiptMaker(paymentChoice, grandTotal, salesTax, subTotal);
            break;
        case 2:
            CallReceiptMaker(paymentChoice, grandTotal, salesTax, subTotal);
            break;
        case 3:
            CallReceiptMaker(paymentChoice, grandTotal, salesTax, subTotal);
            break;
    }



    Console.WriteLine("Press X to exit, or any other key to order again.");
    orderAgain = Console.ReadLine();
    if (orderAgain != "x")
    {
        Console.Clear();
        continue;
    }
    else break;
}




//Display a receipt with items ordered, subtotal, grand total, payment info
//This will happen based on the do while loop above. 


//Return to the original menu for a new order




