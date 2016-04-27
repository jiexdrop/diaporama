using ExifLibrary;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace disp
{
    /// <summary>
    /// Logique d'interaction pour Diaporama.xaml
    /// </summary>
    public partial class Diaporama : Window
    {
        List<JPGFileInfo> _listJpg;
        JPGFileInfo activeImage;
        DispatcherTimer timer;
        int index;
        public Diaporama(List<JPGFileInfo> listJpg)
        {
            InitializeComponent();
            this._listJpg = listJpg;
            index = 0;
            activeImage = _listJpg[index];
            DataContext = activeImage;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            nextImage();
        }

        public void nextImage()
        {
            if (index < _listJpg.Count() - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            activeImage = _listJpg[index];
            DataContext = activeImage;
        }

        public void previousImage()
        {
            if (index > 0)
            {
                index--;
            }
            else
            {
                index = _listJpg.Count() - 1;
            }
            activeImage = _listJpg[index];
            DataContext = activeImage;
        }



        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    timer.Interval = new TimeSpan(0, 0, 5);
                    previousImage();
                    break;
                case Key.Right:
                    timer.Interval = new TimeSpan(0, 0, 5);
                    nextImage();
                    break;
                default:
                    timer.Stop();
                    this.Close();
                    break;
            }

        }

    }
}
