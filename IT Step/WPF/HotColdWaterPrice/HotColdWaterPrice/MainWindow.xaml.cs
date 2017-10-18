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

namespace HotColdWaterPrice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model = new Model();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model;
            TotPrice.Content = model.TotalPrice1;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //   int nOfPeop = Convert.ToInt32(numOfPeople.Text);
        //   double vPerPer = Convert.ToDouble(VolPerPerson.Text);
        //   double pLow = Convert.ToDouble(PriceLow.Text);
        //   double pHigh = Convert.ToDouble(PriceHigh.Text);
        //   double cVol = Convert.ToDouble(ColdVol.Text);
        //   double hVol = Convert.ToDouble(HotVol.Text);
        //}


    }
}
