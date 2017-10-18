using PixelsRotateDll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RotatePixels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ImageSize = 600 ;
        int scale = ImageSize/300;
        double alpha = Math.PI / 4; //6.283185


        const uint White = 0xFFFFFFFF;
        const uint Black = 0xFF000000;

        uint[,] before = new uint[ImageSize, ImageSize];
        uint[,] after = new uint[ImageSize, ImageSize];

        void FillArrays()
        {
            for (int i = 0; i < ImageSize; i++)
            {
                for (int j = 0; j < ImageSize; j++)
                {
                    after[i, j] = Black;
                    before[i, j] = Black;
                    if (Math.Abs(i-j) < 10)
                    {
                        before[i, j] = White;
                    }
                }
            }
        }

        void Rotate()
        {
           // double alpha = Math.PI / 4; //6.283185
            double cos = Math.Cos(alpha);
            double sin = Math.Sin(alpha);
            for (int i = 0; i < ImageSize; i++)
            {
                for (int j = 0; j < ImageSize; j++)
                {
                    if ((i > ImageSize/4) && (i < ImageSize*3/4) &&
                        (j > ImageSize/4) && (j < ImageSize*3/4))
                         {
                             var ii = i - ImageSize / 2;
                             var jj = j - ImageSize / 2;
                             var oldi = ImageSize / 2 + (int)(cos * ii + sin * jj); // x
                             var oldj = ImageSize / 2 + (int)(-sin * ii + cos * jj); // y
                            after[i, j] = before[oldi,oldj];
                        }
                    else {
                        after[i, j] = before[i, j];
                    }
                }
            }
            alpha += 0.01;
        }


        private void DrawPicture()
        {
            int width = 300;
            int height = 300;

            // Create a writeable bitmap (which is a valid WPF Image Source
            WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);

            // Create an array of pixels to contain pixel color values
            uint[] pixels = new uint[width * height];

            for (int x = 0; x < 300; ++x)
            {
                for (int y = 0; y < 300; ++y)
                {
                    int i = width * (y) + x;
                    pixels[i] = before[x * scale, y * scale];
                }
            }
            // apply pixels to bitmap
            bitmap.WritePixels(new Int32Rect(0, 0, 300, 300), pixels, width * 4, 0);

            // set image source to the new bitmap
            this.BeforeImage.Source = bitmap;
        }
        public MainWindow()
        {
            InitializeComponent();
            FillArrays();
            DispatcherTimer t = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 100),
                IsEnabled = true,
            };
          //  t.Tick += t_Tick;
            DrawPicture();

            string[] pluginFiles =
                Directory.GetFiles(@"D:\Plugins", @"*.dll");

            List<DashkasPlugin> plugins = new List<DashkasPlugin>();
            foreach (var file in pluginFiles)
            {
                var asm = Assembly.LoadFile(file);
                foreach (var type in asm.GetExportedTypes())
                {
                    if (typeof(DashkasPlugin).IsAssignableFrom(type))
                    {
                        plugins.Add(
                            (DashkasPlugin)Activator.CreateInstance(type)
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
                    plugin.Transform(before, after);
                    // Create an array of pixels to contain pixel color values
                    int width = 300;
                    int height = 300;

                    // Create a writeable bitmap (which is a valid WPF Image Source
                    WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);

                    // Create an array of pixels to contain pixel color values
                    uint[] pixels = new uint[width * height];


                    for (int x = 0; x < 300; ++x)
                    {
                        for (int y = 0; y < 300; ++y)
                        {
                            int i = width * (y) + x;
                            pixels[i] = after[x * scale, y * scale];
                        }
                    }
                    // apply pixels to bitmap
                    bitmap.WritePixels(new Int32Rect(0, 0, 300, 300), pixels, width * 4, 0);

                    // set image source to the new bitmap
                    this.AfterImage.Source = bitmap;

                };
                sp.Children.Add(btn);
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            // Create an array of pixels to contain pixel color values
            int width = 300;
            int height = 300;

            // Create a writeable bitmap (which is a valid WPF Image Source
            WriteableBitmap bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);

            // Create an array of pixels to contain pixel color values
            uint[] pixels = new uint[width * height];

            for (int x = 0; x < 300; ++x)
            {
                for (int y = 0; y < 300; ++y)
                {
                    int i = width * (y) + x;
                    pixels[i] = after[x * scale, y * scale];
                }
            }
            // apply pixels to bitmap
            bitmap.WritePixels(new Int32Rect(0, 0, 300, 300), pixels, width * 4, 0);

            // set image source to the new bitmap
            this.AfterImage.Source = bitmap;
            
        }
    }
}
