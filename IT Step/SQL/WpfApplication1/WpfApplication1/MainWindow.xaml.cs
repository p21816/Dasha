using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input; // www.zzz.xxx nx-nanana.xaxa 007.by x_factor.com  зайчик.бел xx.xxx.xxx.xxx.xxx
            string pattern = @"\w+(?!\.)";
            results.Items.Add(String.Format("PATTERN {0}", pattern));
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            input = inp.Text;
            MatchCollection matches = rgx.Matches(input);
            if (matches.Count > 0)
            {
                results.Items.Add(String.Format("{0} ({1} matches):", input, matches.Count));
                foreach (Match match in matches)
                {
                    results.Items.Add(String.Format("   " + match.Value + "|"));

                    for (int i = 0; i < match.Groups.Count; i++)
                    {
                        results.Items.Add(String.Format("{0} {1}", i, match.Groups[i].Value));
                    }
                }

            }

        }
    }
}
