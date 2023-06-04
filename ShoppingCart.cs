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

        public void AddWine(Wine wine)
        {
            Cart.Add(wine);
            string addItem = wine.ReceiptString();
            Console.WriteLine($"{addItem} has been added to your cart.");
        }

        public void RemoveWine(Wine wine)
        {
            bool isRemoved = Cart.Remove(wine);
            string removeItem = wine.ReceiptString();  
            if (isRemoved)
            {
                Console.WriteLine($"{removeItem} has been removed from your cart.");
            }
            else
            {
                Console.WriteLine($"{removeItem} is not in your cart.");
            }
        }

        public void ClearCart()
        {
            Cart.Clear();
            Console.WriteLine("Your cart has been emptied");
        }

        public void DisplayCart()
        {
            Console.WriteLine("Items in your cart:");
            foreach (Wine wine in Cart)
            {
                Console.WriteLine(wine.ReceiptString());
            }
        }
    }
}
