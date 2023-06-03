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

        private List<Wine> WineInventory;

        public Menu()
        {
            WineInventory = new List<Wine>();
        }

        public void AddWine(Wine newWine)
        {
            WineInventory.Add(newWine);
        }

        public void RemoveWine(Wine newWine)
        {
            WineInventory.Remove(newWine);
        }

        public void DisplayMenu()
        {
            foreach(Wine wine in WineInventory)
            {
                Console.WriteLine(wine.ToString());

                Console.WriteLine("Please order by Bin Number.");
            }
        }

        //


    }
}
