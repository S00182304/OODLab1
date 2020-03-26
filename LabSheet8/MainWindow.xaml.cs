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

namespace LabSheet8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeamData db = new TeamData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Code for windom load
            var query = from t in db.Teams
                        select t.TeamName;

            var teams = query.ToList();

            LbxTeams.ItemsSource = teams;

            LbxTeams.SelectedItem = 0;

            string playerName = teams.ElementAt(0);

            var players = from p in db.Players
                          where p.Team.TeamName == playerName
                          select p.Name;
            LbxPlayers.ItemsSource = players.ToList();
        }
    }
}
