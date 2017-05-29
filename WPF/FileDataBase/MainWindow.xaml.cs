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
            LinearGradientBrush b = new LinearGradientBrush();
            b.StartPoint = new Point(0, 0);
            b.EndPoint = new Point(1, 0);
            b.GradientStops.Add(new GradientStop(Colors.DarkMagenta, 0.16));
            b.GradientStops.Add(new GradientStop(Colors.Crimson, 0.83));
            this.Background = b;
            Database.Instance.Add(new Database.Record
            {
                ID = 1,
                FirstName = "Vaysa",
                LastName = "Homyachkov"
            });
            Database.Instance.Add(new Database.Record
            {
                ID = 2,
                FirstName = "Ann",
                LastName = "Bunin"
            });
            Database.Instance.Add(new Database.Record
            {
                ID = 2,
                FirstName = "Masha",
                LastName = "Bunin"
            });


            //Database.Instance.Add(new Database.Record
            //{
            //    ID = 3,
            //    FirstName = "Oleg",
            //    LastName = "Beliaeva"
            //});
            //Database.Instance.Add(new Database.Record
            //{
            //    ID = 4,
            //    FirstName = "Alex",
            //    LastName = "Coder"
            //});
            string str = null;
            foreach (var i in Database.Instance.indexes)
            {
                str += i.ToString() + " ";
            }
            MessageBox.Show(str);
         //  MessageBox.Show(Database.Instance[0].ToString());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
