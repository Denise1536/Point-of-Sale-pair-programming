using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class Menu
    {
        //12 items minimum, stored in a list: name, category, price, description

        public List<Wine> WineInventory {  get; set; }

        public Menu()
        {
            WineInventory = new List<Wine>();
        }

        public Wine FindWine(int binNumber)
        {
            Wine foundWine = WineInventory.FirstOrDefault(wine => wine.BinNumber == binNumber);
            return foundWine;            
        }

        public void AddWine(Wine newWine)
        {
            WineInventory.Add(newWine);
        }

        public void RemoveWine(Wine newWine)
        {
            WineInventory.Remove(newWine);
        }

        public void UpdateInventoryRemove(Wine wineOrdered, int quantityOrdered)
        {
            wineOrdered.InventoryCount -= quantityOrdered;
        }

        public void UpdateInventoryAdd(Wine wineOrdered, int quantityOrdered)
        {
            wineOrdered.InventoryCount += quantityOrdered;
        }

        public List<Wine> GetMenuList()
        {
            return WineInventory;
        }

        public void DisplayMenu()
        {
            foreach(Wine wine in WineInventory)
            {
                Console.WriteLine(wine.ToString());

            }
            Console.WriteLine(new string('-', 117));
            Console.WriteLine("Please order by Bin Number.");
        }



    }
}
