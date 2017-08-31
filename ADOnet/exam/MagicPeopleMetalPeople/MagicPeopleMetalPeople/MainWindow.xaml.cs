using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MagicPeopleMetalPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = @"Data Source=a3-prepod\A203;Initial Catalog=Phonebook;Integrated Security=True";
        static public Phonebook conn = new Phonebook(connectionString);
        static public ObservableCollection<Human> PeopleData = new ObservableCollection<Human>();

        public MainWindow()
        {
            InitializeComponent();
            var people = from p in conn.People where (p.Lastname.StartsWith("A") && p.Phones.Count == 0) select p;
            dg.ItemsSource = people;       
        }
    }
}
