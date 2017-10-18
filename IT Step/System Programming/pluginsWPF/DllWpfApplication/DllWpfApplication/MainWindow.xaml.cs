using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace DllWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] pluginFiles =
                Directory.GetFiles(@"D:\Plugins", "*.dll");

            List<IPlugin> plugins = new List<IPlugin>();
            foreach (var file in pluginFiles)
            {
                var asm = Assembly.LoadFile(file);
                foreach (var type in asm.GetExportedTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        plugins.Add(
                            (IPlugin)Activator.CreateInstance(type)
                        );
                    }
                }
            }


            foreach (var plugin in plugins)
            {
                var btn = new Button()
                    {
                        Content = plugin.GetButtonName()
                    };
                btn.Click += (object sender, RoutedEventArgs e) =>
                {
                    lb.Items.Add(plugin.Calculate());
                };
                sp.Children.Add(btn);
            }

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
