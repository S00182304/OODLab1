using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public class Album
    {
        public string AlbumName { get; set; }
        private int releaseYear;
        private int sales;

        public int Sales
        {
            get
            {
                Random randSales = new Random();
                sales = randSales.Next(50000, 200000);
                return sales;
            }
        }

        public int ReleaseYear
        {
            get
            {
                Random randReleaseYear = new Random();
                releaseYear = randReleaseYear.Next(1900, 2020);
                return releaseYear;
            }
        }

        public Album(string albumName)
        {
            AlbumName = albumName;
        
        }

        public override string ToString()
        {
            return $"{AlbumName}, {ReleaseYear}, {Sales}";
        }


    }
}
