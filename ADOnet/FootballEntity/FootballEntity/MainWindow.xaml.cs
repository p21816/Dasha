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
using System.Data.Entity;

namespace FootballEntity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FootballEntities FE = new FootballEntities();

        public MainWindow()
        {
            InitializeComponent();
            FE.CompetitionWinners.Load();
            FE.Competitions.Load();
            dg.ItemsSource = FE.CompetitionWinners.Local;
            dgComp.ItemsSource = FE.Competitions.Local;
            TeamsComboBox.Items.Add("hello");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FootballEntity.Competition fec = new FootballEntity.Competition() { name = addCompetitionTextBox.Text , id = Convert.ToInt32(addCompetitionIdTextBox.Text)};
            FE.Competitions.Add(fec);
            FE.SaveChanges();
            FE.Competitions.Load();
        }
    }
}
