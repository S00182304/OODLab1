using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabSheet4
{
 
    public partial class MainWindow : Window
    {
        NORTHWNDEntities1 db = new NORTHWNDEntities1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populates Stock Level ListBox
            lbxStock.ItemsSource = Enum.GetNames(typeof(StockLevel));

            //Populate the suppliers listbox using anonymous type
            var query1 = from s in db.Suppliers
                         orderby s.CompanyName
                         select new
                         {
                             SupplierName = s.CompanyName,
                             SupplierID = s.SupplierID,
                             Country = s.Country
                         };

            //Updating the suppliers listbox
            lbxSuppliers.ItemsSource = query1.ToList();

            //Populate the Countries to the countr
            var query2 = from s in db.Suppliers
                         orderby s.Country
                         select s.Country;

            var countries = query2.ToList();

            //Updates the Countries listbox
            lbxCountries.ItemsSource = countries.Distinct();
        }

        private void LbxStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = from p in db.Products
                        where p.UnitsInStock < 50
                        orderby p.ProductName
                        select p.ProductName;

            //Determining what was selected from that listbox
            string selected = lbxStock.SelectedItem as string;

            switch(selected)
            {
                case "Low":
                    //Nothing as query is sorted from above
                    break;
                case "Normal":
                    query = from p in db.Products
                            where p.UnitsInStock >= 50 && p.UnitsInStock <= 100
                            orderby p.ProductName
                            select p.ProductName;
                    break;
                case "Overstocked":
                    query = from p in db.Products
                            where p.UnitsInStock > 100
                            orderby p.ProductName
                            select p.ProductName;
                    break;
            }

            //Update product list
            lbxProducts.ItemsSource = query.ToList();
        }

        private void LbxSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //using the selected value path
            int supplierID = Convert.ToInt32(lbxSuppliers.SelectedValue);

            var query = from p in db.Products
                        where p.SupplierID == supplierID
                        orderby p.ProductName
                        select p.ProductName;

            //Update Product List
            lbxProducts.ItemsSource = query.ToList();
        }

        private void LbxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string country = (string)(lbxCountries.SelectedValue);

            var query = from p in db.Products
                        where p.Supplier.Country == country
                        orderby p.ProductName
                        select p.ProductName;

            //Update Product List
            lbxProducts.ItemsSource = query.ToList();
        }
    }



    //Content for the Stock Level ListBox
    public enum StockLevel { low, Normal, Overstocked };
}
