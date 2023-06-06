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
            return $"Bin: {BinNumber, 4} {WineName, -27} {Varietal, -20} {Region, -25} {Vintage,-5} {Price, 10:c}  {InventoryCount, 4} in stock.";
        }

        public string ReceiptString()
        {
            return $"{WineName, 20}, {Price, 10:c}";
        }
    }
}
