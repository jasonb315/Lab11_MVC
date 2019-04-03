using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        /// <summary>
        ///     Recieves user filter and generated list of qualified wines
        /// </summary>
        /// <param name="price">int max price</param>
        /// <param name="points">int min points</param>
        /// <returns>List of wines</returns>
        public static List<Wine> GetWineList(int price, int points)
        {
            List<Wine> wineSelection = new List<Wine>();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/wine.csv");

            var CSVreader = new StreamReader(File.OpenRead(path));
            // skip csv header
            CSVreader.ReadLine();

            while (!CSVreader.EndOfStream)
            {
                string line = CSVreader.ReadLine();

                // Regex: https://stackoverflow.com/questions/6542996/how-to-split-csv-whose-columns-may-contain
                string[] data = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                // new wine instance, populate
                Wine wineToAdd = new Wine()
                {
                    ID = Convert.ToInt32(data[0]),
                    Country = data[1],
                    Description = data[2],
                    Designation = data[3],
                    Points = int.TryParse(data[4], out int point) ? point : -1,
                    Price = Decimal.TryParse(data[5], out Decimal cost) ? cost : Decimal.MaxValue,
                    Region_1 = data[6],
                    Region_2 = data[7],
                    Variety = data[8],
                    Winery = data[9]
                };

                // add to wineSelection to pass for page render
                wineSelection.Add(wineToAdd);
            }

            var wineChoice = from w in wineSelection.Distinct()
                             where w.Points > points && w.Price < price
                             orderby w.Price
                             select w;

            return wineChoice.ToList();
        }
    }
}
