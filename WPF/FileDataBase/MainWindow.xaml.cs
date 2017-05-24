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

namespace FileDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.Instance.Add(new Database.Record
            {
                ID = 1,
                FirstName = "Vaysa",
                LastName = "Homyachkov"
            });
            Database.Instance.Add(new Database.Record
            {
                ID = 2,
                FirstName = "Petia",
                LastName = "Bunin"
            });
           MessageBox.Show(Database.Instance[0].ToString());
        }
    }
}
