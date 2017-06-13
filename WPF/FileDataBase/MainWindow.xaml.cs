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

namespace FileDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        class Model
        {
            public ObservableCollection<Database.Record> records = new ObservableCollection<Database.Record>();
        }
        Model m = new Model();
        public MainWindow()
        {
            InitializeComponent();


            rec.RecordChanged+=rec_RecordChanged;

            Database.Instance.Add(new Database.Record
            {
                ID = 1,
                FirstName = "Vasya",
                LastName = "Petrov"
            });
            Database.Instance.Add(new Database.Record
            {
                ID = 44,
                FirstName = "Ann",
                LastName = "Petrov"
            });
            Database.Instance.Add(new Database.Record
            {
                ID = 56,
                FirstName = "Darya",
                LastName = "Petrov"
            });

            m.records.Add(Database.Instance[0]);
            m.records.Add(Database.Instance[1]);
            m.records.Add(Database.Instance[2]);
            list.ItemsSource = m.records;

            //LinearGradientBrush b = new LinearGradientBrush();
            //b.StartPoint = new Point(0, 0);
            //b.EndPoint = new Point(1, 0);
            //b.GradientStops.Add(new GradientStop(Colors.DarkMagenta, 0.16));
            //b.GradientStops.Add(new GradientStop(Colors.Crimson, 0.83));
            //this.Background = b;

            //string str = null;
            //foreach (var i in Database.Instance.indexes)
            //{
            //    str += i.ToString() + " ";
            //}
            //MessageBox.Show(str);
         //  MessageBox.Show(Database.Instance[0].ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database.Instance.Add(new Database.Record
            {
                ID = rec.ID,
                FirstName = rec.FirstName,
                LastName = rec.Surname
            });
            rec.RecordClear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rec.RecordClear();
            searchedRecord.RecordClear();
        }

        private void Find_by_linenumber(object sender, RoutedEventArgs e)
        {
            int line = Convert.ToInt32(lineNumberTextbox.Text);

        //    searchedRecord.makeReadonly();
            searchedRecord.ID = Database.Instance[line].ID;
            searchedRecord.FirstName = Database.Instance[line].FirstName;
            searchedRecord.Surname = Database.Instance[line].LastName;

            lineNumberTextbox.Clear();
        }

        private void rec_RecordChanged(object sender, RoutedPropertyChangedEventArgs<Database.Record> e)
        {
            if (e.NewValue.ID < 10)
            {
                Title = "Плохой";
            }
            else
            {
                Title = "Хороший";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(m.records[0].ToString() + " " + m.records[1].ToString() + " "  + m.records[2].ToString() );
        }
    }
}
