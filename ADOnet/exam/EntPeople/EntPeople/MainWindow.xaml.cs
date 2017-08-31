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
using System.Collections.ObjectModel;

namespace EntPeople
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public PhonebookEntities conn = new PhonebookEntities();
        static public ObservableCollection<Human> PeopleData = new ObservableCollection<Human>();


        public MainWindow()
        {
            InitializeComponent();
            conn.People.Load();
            var people = from p in conn.People.Local where (p.Lastname.StartsWith("A") && p.Phones.Count == 0) select p;
            dg.ItemsSource = people;

        }
    }
}
