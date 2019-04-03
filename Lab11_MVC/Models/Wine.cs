using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_MVC.Models
{
    public class Wine
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }

        public static List<Wine> GetWineList(int price, int points)
        {
            List<Wine> wineSelection = new List<Wine>();

            //var CSVreader = new StreamReader(File.OpenRead("../../wine.csv"));

            //string path = "../../wine.csv";
            //var data = "";

            //using (StreamReader sr = File.OpenText(path))
            //{
            //    data = sr.ReadToEnd();
            //}

            // bring in data
            // read line by line, exclude header
            // split lines into data sections array
            // use data sections of arr by index to populate wine class constructor fields
            // populate winSelection with each instantiated line
            // return populated list to View calling wine.GerWineList

        }

    }
}
