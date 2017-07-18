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
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace datdagridWPF_connected_to_database_through_ADOnet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Model m = new Model();
        connectionToDatabase c = new connectionToDatabase();
        public MainWindow()
        {
            InitializeComponent();
            m.HotelsData = c.getInfoFromDataBase();
            HotelsDatagrid.ItemsSource = m.HotelsData;
            HotelsDatagrid.CellEditEnding += HotelsDatagrid_CellEditEnding;
            m.HotelsData.CollectionChanged += HotelsData_CollectionChanged;
        }

        void HotelsData_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        void HotelsDatagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            List<int> ids = new List<int>();
            MessageBox.Show(e.EditingElement.ToString());
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            c.setInfoToDataBase(m.HotelsData);
        }

    }
}
