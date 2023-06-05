using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale_Terminal_project
{
    internal class Wine
    {
        public int BinNumber { get; set; }
        public string WineName { get; set; }
        public string Varietal { get; set; }
        public string Region { get; set; }
        public string Vintage { get; set; }
        public double Price { get; set; }
        public int InventoryCount { get; set; }

        public Wine(int binNumber, string wineName, string varietal, string region, string vintage, double price, int inventoryCount)
        {
            BinNumber = binNumber;
            WineName = wineName;
            Varietal = varietal;
            Region = region;
            Vintage = vintage;
            Price = price;
            InventoryCount = inventoryCount;
        }

        public override string ToString()
        {
            return string.Format("Bin: (0), (1), (2), (3), (4), $(5). (6) in stock.", BinNumber, WineName, Varietal, Region, Vintage, Price, InventoryCount);
        }

        public string ReceiptString()
        {
            return string.Format("(0), $(1)", WineName, Price);
        }
    }
}
