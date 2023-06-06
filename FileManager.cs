using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Point_of_Sale_Terminal_project
{
    internal class FileManager
    {
        private string FilePath = "./Assets/DataFiles/WineList.txt";

        private Menu MenuInstance;
        public FileManager(Menu menuInstance)
        {
            MenuInstance = menuInstance;
        }

        public void LoadWineList(Menu menuInstance)
        {
            

            List<Wine> wineList = MenuInstance.GetMenuList();
            FileInfo fileInfo = new FileInfo(FilePath);

            if (fileInfo.Length == 0)
            {
               
                Wine boizel = new Wine(101, "Boizel", "Champagne", "Champagne, FR", "NV", 49.99, 24);
                Wine moet = new Wine(102, "Moet & Chandon", "Champagne", "Champagne, FR", "NV", 59.99, 24);
                Wine domP = new Wine(103, "Dom Perignon", "Champagne", "Champagne, FR", "2012", 289.99, 12);
                Wine krug = new Wine(104, "Krug", "Champagne", "Champagne, FR", "2008", 679.99, 4);
                Wine duckhorn = new Wine(111, "Duckhorn", "Chardonnay", "Napa Valley, CA", "2021", 29.99, 48);
                Wine lucia = new Wine(112, "Lucia Estate Cuvee", "Chardonnay", "Salinas Valley, CA", "2021", 49.99, 24);
                Wine jadotPuligny = new Wine(113, "Jadot Puligny Montrachet", "Chardonnay", "Burgundy, FR", "2020", 89.99, 12);
                Wine latourCorton = new Wine(114, "Latour Corton Charlemange", "Chardonnay", "Burgundy, FR", "2018", 269.99, 10);
                Wine tePa = new Wine(121, "Te Pa", "Sauvignon Blanc", "New Zealand", "2022", 15.99, 48);
                Wine merryEdwardsSB = new Wine(122, "Merry Edwards", "Sauvignon Blanc", "Russian River Valley, CA", "2020", 54.99, 32);
                Wine jolivetPiton = new Wine(123, "Jolivet Le Piton Sancerre", "Sauvignon Blanc", "Loire, FR", "2020", 49.99, 12);
                Wine trimbach = new Wine(130, "Trimbach", "Gewurztraminer", "Alsace, FR", "2021", 49.95, 12);

                MenuInstance.AddWine(boizel);
                MenuInstance.AddWine(moet);
                MenuInstance.AddWine(domP);
                MenuInstance.AddWine(krug);
                MenuInstance.AddWine(duckhorn);
                MenuInstance.AddWine(lucia);
                MenuInstance.AddWine(jadotPuligny);
                MenuInstance.AddWine(latourCorton);
                MenuInstance.AddWine(tePa);
                MenuInstance.AddWine(merryEdwardsSB);
                MenuInstance.AddWine(jolivetPiton);
                MenuInstance.AddWine(trimbach);

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach(Wine wine in wineList)
                    {                        
                        writer.WriteLine(JsonConvert.SerializeObject(wine));
                    }
                }

            }
            else
            {
                using(StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        Wine savedWine = JsonConvert.DeserializeObject<Wine>(line);
                        wineList.Add(savedWine);
                    }
                }

            }
        }

        public void SaveWineList(List<Wine> wineList)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, false))
            {
                foreach (Wine wine in wineList)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(wine));
                }
            }

        }


    }
}
