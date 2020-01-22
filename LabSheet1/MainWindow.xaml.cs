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

namespace LabSheet1
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Loading the band details
            Band Band1 = new Band("Rolling Stones", 1962, "Brian Jones, Mick Jagger, Keith Richards, Bill Wyman, Charlie Watts and Ian Stewart");
            Band Band2 = new Band("Led Zeppelin", 1968, "Robert Plant, Jimmy Page, John Paul Jones and John Bonham");
            Band Band3 = new Band("The Beatles", 1957, "John Lennon, Paul McCartney, George Harrison and Ringo Starr");
            Band Band4 = new Band("Pink Floyd", 1965, " Syd Barrett, David Gilmour, Roger Waters, Richard Wright, Nick Mason and Bob Klose");
            Band Band5 = new Band("Metallica", 1981, "James Hetfield, Cliff Burton, Lars Ulrich, Dave Mustaine etc");
            Band Band6 = new Band("Guns N' Roses", 1985, "Slash, Axl Rose, Duff McKagan, Izzy Stradlin etc");


            //Add them to a list
            List<Band> bandList = new List<Band>();
            bandList.Add(Band1);
            bandList.Add(Band2);
            bandList.Add(Band3);
            bandList.Add(Band4);
            bandList.Add(Band5);
            bandList.Add(Band6);

            //Populate them into a listBox
            LBBandDetails.ItemsSource = bandList;

        }
    }
}
