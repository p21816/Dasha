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
        public static DependencyProperty RecordProperty;
        public static DependencyProperty NameProperty;
        public static DependencyProperty SurnameProperty;
        public static DependencyProperty IDProperty;

        public Database.Record Record
        {
            get { return (Database.Record)GetValue(RecordProperty); }
            set { SetValue(RecordProperty, value); }
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
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

        static RecordControl()
        {
            RecordProperty = DependencyProperty.Register(
                "Record",            // номер счёта 300000305085402
                typeof(Database.Record),      // в рблях
                typeof(RecordControl), // для меня
                new FrameworkPropertyMetadata( "1 ObiWan Kenobi",
                    new PropertyChangedCallback(OnRecordChanged))
                );

        }

        private static void OnRecordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RecordControl colorPicker = (RecordControl)sender;
            Database.Record newRecord = (Database.Record)e.NewValue;
            RecordControl.Name = newRecord.Name;

        }

        private static void OnColorChanged(
    DependencyObject sender,
    DependencyPropertyChangedEventArgs e
)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color newColor = (Color)e.NewValue;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;
        }
    }
}
