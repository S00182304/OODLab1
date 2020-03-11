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

namespace LabSheet5
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

        //Lab 5 - Exercise 1
        private void Ex1Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Categories
                        join p in db.Products on c.CategoryName equals p.Category.CategoryName
                        orderby c.CategoryName
                        select new
                        {
                            Category = c.CategoryName,
                            Product = p.ProductName
                        };
            var results = query.ToList();

            Ex1lbDisplay.ItemsSource = results;
            Ex1TblkCount.Text = results.Count.ToString();
            
        }

        //Exercise 2
        private void Ex2Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        orderby p.Category.CategoryName, p.ProductName
                        select new { Category = p.Category.CategoryName, Product = p.ProductName };
            var results = query.ToList();
            Ex2lbDisplay.ItemsSource = results;
            Ex2TblkCount.Text = results.Count.ToString();
        }

        //Exercise 3
        private void Ex3Button_Click(object sender, RoutedEventArgs e)
        {
            //Return the total number of orders for product 7
            var query1 = (from detail in db.Order_Details
                          where detail.ProductID == 7
                          select detail);

            //Return the total value of orders for product 7
            var query2 = (from detail in db.Order_Details
                          where detail.ProductID == 7
                          select detail.UnitPrice * detail.Quantity);

            int numberOfOrders = query1.Count();
            decimal totalValue = query2.Sum();
            decimal averageValue = query2.Average();

            Ex3TblkCount.Text = string.Format(
                "Total number of orders {0}\nValue of Orders {1:C}\nAverage Order Value {2:C}",
                numberOfOrders, totalValue, averageValue);
        }

        //Exercise 4
        private void Ex4Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        where customer.Orders.Count >= 20
                        select new
                        {
                            Name = customer.CompanyName,
                            OrderCount = customer.Orders.Count
                        };

            Ex4lbDisplay.ItemsSource = query.ToList();
        }

        //Exercise 5
        private void Ex5Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        where customer.Orders.Count < 3
                        select new
                        {
                            Company = customer.CompanyName,
                            City = customer.City,
                            Region = customer.Region,
                            OrderCount = customer.Orders.Count
                        };
            Ex5lbDisplay.ItemsSource = query.ToList();
        }

        //Exercise 6 - part 1
        private void Ex6Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        orderby customer.CompanyName
                        select customer.CompanyName;
            Ex5lbDisplay.ItemsSource = query.ToList();
        }

        //Exercise 6 - Part 2
        

    }
}
