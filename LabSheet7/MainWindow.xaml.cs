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

namespace LabSheet7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        //Exercise 1
        private void Ex1Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        group c by c.Country into g
                        orderby g.Count() descending
                        select new
                        {
                            Country =g.Key,
                            Count = g.Count()
                        };

            Ex1dgDisplay.ItemsSource = query.ToList();
        }

        //Exercise 2
        private void Ex2Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Country == "Italy"
                        orderby c.CompanyName
                        //select c;
                        select new
                        {
                            c.CompanyName,
                            c.Phone
                        };

            Ex2dgDisplay.ItemsSource = query.ToList();
        }

        //Exercise 3
        private void Ex3Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where (p.UnitsInStock - p.UnitsOnOrder > 0)
                        select new
                        {
                            Product = p.ProductName,
                            Available = p.UnitsInStock
                        };

            Ex3dgDisplay.ItemsSource = query.ToList();
        }

        //Exercise 4
        private void Ex4Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from od in db.Order_Details
                        orderby od.Product.ProductName
                        where od.Discount > 0
                        select new
                        {
                            ProductName = od.Product.ProductName,
                            DiscountGiven = od.Discount,
                            OrderID = od.OrderID
                        };
            Ex4dgDisplay.ItemsSource = query.ToList();
        }

        //Exercise 5
        private void Ex5Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        select o.Freight;

            Ex5dgDisplay.Text = string.Format("The Value of the freight for all order is {0:C}", query.Sum());
        }

        //Exercise 6
        private void Ex6Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        orderby p.Category.CategoryName, p.UnitPrice descending
                        select new
                        {
                            p.CategoryID,
                            p.Category.CategoryName,
                            p.ProductName,
                            p.UnitPrice
                        };

            Ex6dgDisplay.ItemsSource = query.ToList();
        }

        //Exercise 7
        private void Ex7Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        group o by o.CustomerID into g
                        orderby g.Count() descending
                        select new
                        {
                            CustomerID = g.Key,
                            NumberOfOrders = g.Count()
                        };
            Ex7dgDisplay.ItemsSource = query.ToList();
        }

        //Exercise 8
        private void Ex8Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        group o by o.CustomerID into g
                        join c in db.Customers on g.Key equals c.CustomerID
                        orderby g.Count() descending
                        select new
                        {
                            CustomerID = c.CustomerID,
                            CompanyName = c.CompanyName,
                            NumberOfOrders = c.Orders.Count
                        };
            Ex8dgDisplay.ItemsSource = query.ToList().Take(10);
        }

        //Exercise 9
        private void Ex9Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Orders.Count == 0
                        orderby c.Orders.Count
                        select new
                        {
                            CompanyID = c.CustomerID,
                            CompanyName = c.CompanyName,
                            NumberOfOrders = c.Orders.Count
                        };
            Ex9dgDisplay.ItemsSource = query.ToList();
        }
    }
}
