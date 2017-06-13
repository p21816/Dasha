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

namespace ExamWpf
{
    /// <summary>
    /// Interaction logic for UserAdder.xaml
    /// </summary>
    public partial class CarAdder : UserControl
    {
        public CarAdder()
        {
            InitializeComponent();
            priceTextBox.Clear();
        }

        public static DependencyProperty RecordProperty;
        public static DependencyProperty CarMarkProperty;
        public static DependencyProperty CarNameProperty;
        public static DependencyProperty CarPriceProperty;


        public Car Record
        {
            get { return (Car)GetValue(RecordProperty); }
            set { SetValue(RecordProperty, value); }
        }
        public string CarMark
        {
            get { return (string)GetValue(CarMarkProperty); }
            set { SetValue(CarMarkProperty, value); }
        }
        public string CarName
        {
            get { return (string)GetValue(CarNameProperty); }
            set { SetValue(CarNameProperty, value); }
        }

        public int CarPrice
        {
            get { return (int)GetValue(CarPriceProperty); }
            set { SetValue(CarPriceProperty, value); }
        }

        public static RoutedEvent RecordChangedEvent;
        public event RoutedPropertyChangedEventHandler<Car> RecordChanged
        {
            add { AddHandler(RecordChangedEvent, value); }
            remove { RemoveHandler(RecordChangedEvent, value); }
        }
        static CarAdder()
        {
            RecordProperty = DependencyProperty.Register(
                "Record",            // номер счёта 300000305085402
                typeof(Car),      // в рблях
                typeof(CarAdder), // для меня
                new FrameworkPropertyMetadata(new Car(),
                    new PropertyChangedCallback(OnRecordChanged))
                );

            CarMarkProperty = DependencyProperty.Register(
                "FirstName",
                typeof(string),
                typeof(CarAdder),
                new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnRecordComponentChanged))
            );

            CarNameProperty = DependencyProperty.Register(
                "LastName",
                typeof(string),
                typeof(CarAdder),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnRecordComponentChanged))
                );

            CarPriceProperty = DependencyProperty.Register(
                "CarPrice",
                typeof(int),
                typeof(CarAdder),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnRecordComponentChanged))
                );

            RecordChangedEvent = EventManager.RegisterRoutedEvent(
                "RecordChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Car>),
                typeof(CarAdder)
                );
        }

        private static void OnRecordComponentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CarAdder userAdder = (CarAdder)sender;
            Car record = userAdder.Record;
            if (e.Property == CarMarkProperty)
            {
                record.Mark = (string)e.NewValue;
            }
            if (e.Property == CarNameProperty)
            {
                record.CarName = (string)e.NewValue;
            }
            if (e.Property == CarPriceProperty)
            {
                record.Price = (int)e.NewValue;
            }
            userAdder.Record = record;
            
        }

        private static void OnRecordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CarAdder recordControl = (CarAdder)sender;
            Car newRecord = (Car)e.NewValue;
            recordControl.CarMark = newRecord.Mark;
            recordControl.CarName = newRecord.CarName;
            recordControl.CarPrice = newRecord.Price;

        }
        public void RecordClear()
        {
            carMarkTextBox.Clear();
            carNameTextBox.Clear();
            priceTextBox.Clear();
        }
    }
}
