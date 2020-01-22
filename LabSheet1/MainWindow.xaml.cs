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

        private void LBBandDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Loading the band details
            Band Band1 = new Band("Rolling Stones", 1962, "Brian Jones, Mick Jagger, Keith Richards, Bill Wyman, Charlie Watts, and Ian Stewart");

        }
    }
}
