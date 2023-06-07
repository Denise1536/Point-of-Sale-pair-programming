using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class ShoppingCart
    {
        private List<Wine> Cart;
        public ShoppingCart() 
        {
            Cart = new List<Wine>();
        }

        public List<Wine> returnCartList()
        {
            return Cart;
        }

        public double GetSubTotal()
        {
            double subTotal = Cart.Select(x => x.Price * x.InventoryCount).Sum();
            return subTotal;
        }
        public double GetTax()
        {
            double subTotal = GetSubTotal();
            double tax = subTotal * .06;
            return tax;
        }
        public double GetGrandTotal()
        {
            double subTotal = GetSubTotal();
            double tax = GetTax();
            double grandTotal = subTotal + tax;
            return grandTotal;
        }

        public void AddWineToCart(List<Wine> wineInventory, Wine wineOrdered, int quantityOrdered)
        {
            Wine wineInInventory = wineInventory.FirstOrDefault(x => x.BinNumber == wineOrdered.BinNumber);
            Wine wineInCart = Cart.FirstOrDefault(x => x.BinNumber == wineOrdered.BinNumber);

            if (wineInInventory != null && wineInInventory.InventoryCount >= quantityOrdered)
            {
                wineInInventory.InventoryCount-=quantityOrdered;
                
                if(wineInCart != null)
                {
                    wineInCart.InventoryCount += quantityOrdered;
                }
                else
                {
                    wineInCart = new Wine(wineOrdered.BinNumber, wineOrdered.WineName, wineOrdered.Varietal, wineOrdered.Region, wineOrdered.Vintage, wineOrdered.Price, quantityOrdered);
                    Cart.Add(wineInCart);
                }
            }                     


            string formatString = "";
            double priceOfQtyAdded = wineInCart.Price * quantityOrdered;
            if (quantityOrdered == 1)
            {
                formatString = $"{quantityOrdered} bottle of {wineOrdered.WineName} has been added to your cart, for {priceOfQtyAdded:c}.";
            }
            else
            {
                formatString = $"{quantityOrdered} bottles of {wineOrdered.WineName} have been added to your cart, for {priceOfQtyAdded:c}.";
            }
            Console.WriteLine(formatString);
        }

        public void RemoveWine(List<Wine> wineInventory, Wine wineToRemove, int quantityToRemove)
        {
            Wine wineInCart = Cart.FirstOrDefault(x => x.BinNumber == wineToRemove.BinNumber);
            if (wineInCart != null && wineInCart.InventoryCount >= quantityToRemove)
            {
                wineInCart.InventoryCount -= quantityToRemove;
                if(wineInCart.InventoryCount == 0)
                {
                    Cart.Remove(wineInCart);
                }
                Wine wineInInventory = wineInventory.FirstOrDefault(x => x.BinNumber == wineToRemove.BinNumber );
                if (wineInInventory != null)
                {
                    wineInInventory.InventoryCount += quantityToRemove;
                }
            }
            string formatString = "";
            if (quantityToRemove == 1)
            {
                formatString = $"{quantityToRemove} bottle of {wineToRemove.WineName} has been removed from your cart.";
            }
            else
            {
                formatString = $"{quantityToRemove} bottles of {wineToRemove.WineName} have been removed from your cart.";
            }

            Console.WriteLine(formatString);
        }

        public void ClearCart()
        {
            Cart.Clear();
            Console.WriteLine("Your cart has been emptied");
        }

        public void DisplayCartHeader()
        {
            string columnOne = "Quantity".PadRight(10);
            string columnTwo = "Bin #".PadRight(10);
            string columnThree = "Wine".PadRight(30);
            string columnFour = "Price".PadRight(10);
            string header = columnOne + columnTwo + columnThree + columnFour;
            string separator = new string('-', header.Length);

            Console.WriteLine(header);
            Console.WriteLine(separator);
        }

        public void DisplayCart()
        {
            Console.WriteLine("Items in your cart:");
            DisplayCartHeader();
            foreach (Wine wine in Cart)
            {
                Console.WriteLine(wine.ReceiptString());
            }
            double subTotal = GetSubTotal();
            Console.WriteLine($"Current total: {subTotal}");
        }

        public void DisplayFinalOrder()
        {
            DisplayCartHeader();
            
            foreach (Wine wine in Cart)
            {
                Console.WriteLine(wine.ReceiptString());
            }
            double subTotal = GetSubTotal();
            double tax = GetTax();
            double grandTotal = GetGrandTotal();

            Console.WriteLine($"Subtotal: {subTotal:c}");
            Console.WriteLine($"Tax: {tax:c}");
            Console.WriteLine($"Total: {grandTotal:c}");
        }

    }
}
