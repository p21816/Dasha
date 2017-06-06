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
    /// Interaction logic for RecordControl.xaml
    /// </summary>
    public partial class RecordControl : UserControl
    {
        public RecordControl()
        {
            InitializeComponent();
        }
        public Database.Record Record
        {
            get { return (Database.Record)GetValue(RecordProperty); }
            set { SetValue(RecordProperty, value); }
        }
        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }


        public static RoutedEvent RecordChangedEvent;
        public event RoutedPropertyChangedEventHandler<Database.Record> RecordChanged
        {
            add { AddHandler(RecordChangedEvent, value); }
            remove { RemoveHandler(RecordChangedEvent, value); }
        }

        public static DependencyProperty RecordProperty;
        public static DependencyProperty FirstNameProperty;
        public static DependencyProperty SurnameProperty;
        public static DependencyProperty IDProperty;
        public static DependencyProperty IsReadOnlyProperty;

        static RecordControl()
        {
            IsReadOnlyProperty = DependencyProperty.Register(
                 "IsReadOnly",
                 typeof(bool),
                 typeof(RecordControl),
                 new FrameworkPropertyMetadata(
                 new PropertyChangedCallback(OnRecordComponentChanged))
             );

            RecordProperty = DependencyProperty.Register(
                "Record",            // номер счёта 300000305085402
                typeof(Database.Record),      // в рблях
                typeof(RecordControl), // для меня
                new FrameworkPropertyMetadata(new Database.Record(),
                    new PropertyChangedCallback(OnRecordChanged))
                );
            FirstNameProperty = DependencyProperty.Register(
                "FirstName",
                typeof(string),
                typeof(RecordControl),
                new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnRecordComponentChanged))
            );

            SurnameProperty = DependencyProperty.Register(
                "Surname",
                typeof(string),
                typeof(RecordControl),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnRecordComponentChanged))
                );

            IDProperty = DependencyProperty.Register(
                "ID",
                typeof(int),
                typeof(RecordControl),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnRecordComponentChanged))
                );

            RecordChangedEvent = EventManager.RegisterRoutedEvent(
                "RecordChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Database.Record>),
                typeof(RecordControl)
                );
        }

        private static void OnRecordComponentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RecordControl recordPicker = (RecordControl)sender;
            Database.Record record = recordPicker.Record;
            if (e.Property == FirstNameProperty)
            {
                record.FirstName = (string)e.NewValue;
            }
            if (e.Property == SurnameProperty)
            {
                record.LastName = (string)e.NewValue;
            }
            if (e.Property == IDProperty)
            {
                record.ID = (int)e.NewValue;
            }
            if (e.Property == IsReadOnlyProperty)
            {
                recordPicker.makeReadonly();
            }
            recordPicker.Record = record;
        }

        public void RecordClear()
        {
            IDTextbox.Clear();
            nameTextbox.Clear();
            surTextbox.Clear();
        }

        public void makeReadonly()
        {
            IDTextbox.IsReadOnly = true;
            nameTextbox.IsReadOnly = true;
            surTextbox.IsReadOnly = true;
        }

        private static void OnRecordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RecordControl recordControl = (RecordControl)sender;
            Database.Record newRecord = (Database.Record)e.NewValue;

            var Eventargs =
               new RoutedPropertyChangedEventArgs<Database.Record>(
                   (Database.Record)e.OldValue,
                   (Database.Record)e.NewValue,
                   RecordChangedEvent
               );


            recordControl.FirstName = newRecord.FirstName;
            recordControl.Surname = newRecord.LastName;
            recordControl.ID = newRecord.ID;


            var element = ((UIElement)sender);

            element.RaiseEvent(Eventargs);

        }
    }
}
