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

namespace AppForFun
{
    /// <summary>
    /// Interaction logic for UserAdder.xaml
    /// </summary>
    public partial class UserAdder : UserControl
    {
        public UserAdder()
        {
            InitializeComponent();
        }

        public static DependencyProperty RecordProperty;
        public static DependencyProperty FirstNameProperty;
        public static DependencyProperty LastNameProperty;

        public User Record
        {
            get { return (User)GetValue(RecordProperty); }
            set { SetValue(RecordProperty, value); }
        }
        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }
        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public static RoutedEvent RecordChangedEvent;
        public event RoutedPropertyChangedEventHandler<User> RecordChanged
        {
            add { AddHandler(RecordChangedEvent, value); }
            remove { RemoveHandler(RecordChangedEvent, value); }
        }
        static UserAdder()
        {
            RecordProperty = DependencyProperty.Register(
                "Record",            // номер счёта 300000305085402
                typeof(User),      // в рблях
                typeof(UserAdder), // для меня
                new FrameworkPropertyMetadata(new User(),
                    new PropertyChangedCallback(OnRecordChanged))
                );

            FirstNameProperty = DependencyProperty.Register(
                "FirstName",
                typeof(string),
                typeof(UserAdder),
                new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnRecordComponentChanged))
            );

            LastNameProperty = DependencyProperty.Register(
                "LastName",
                typeof(string),
                typeof(UserAdder),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnRecordComponentChanged))
                );

            RecordChangedEvent = EventManager.RegisterRoutedEvent(
                "RecordChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<User>),
                typeof(UserAdder)
                );
        }

        private static void OnRecordComponentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UserAdder userAdder = (UserAdder)sender;
            User record = userAdder.Record;
            if (e.Property == FirstNameProperty)
            {
                record.FirstName = (string)e.NewValue;
            }
            if (e.Property == LastNameProperty)
            {
                record.LastName = (string)e.NewValue;
            }
            userAdder.Record = record;
            
        }

        private static void OnRecordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UserAdder recordControl = (UserAdder)sender;
            User newRecord = (User)e.NewValue;
            recordControl.FirstName = newRecord.FirstName;
            recordControl.LastName = newRecord.LastName;
        }
        public void RecordClear()
        {
            nameTextBox.Clear();
            lastNameTextBox.Clear();
        }
    }
}
