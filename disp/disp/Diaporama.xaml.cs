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
        JPGFileInfo mImage;
        DispatcherTimer timer;
        int id;
        public Diaporama(List<JPGFileInfo> listJpg)
        {
            InitializeComponent();
            this._listJpg = listJpg;
            id = 0;
            mImage = _listJpg[id];
            DataContext = mImage;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            nextImage();
        }

        public void nextImage()
        {
            if (id < _listJpg.Count() - 1)
            {
                id++;
            }
            else
            {
                id = 0;
            }
            mImage = _listJpg[id];
            DataContext = mImage;
        }

        public void previousImage()
        {
            if (id > 0)
            {
                id--;
            }
            else
            {
                id = _listJpg.Count() - 1;
            }
            mImage = _listJpg[id];
            DataContext = mImage;
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
                    timer.Interval = new TimeSpan(0, 0, 3); //reset timer
                    previousImage();
                    break;
                case Key.Right:
                    timer.Interval = new TimeSpan(0, 0, 3);
                    nextImage();
                    break;
                case Key.Space:
                    timer.IsEnabled = !timer.IsEnabled; //pause
                    break;
                default:
                    timer.Stop();
                    this.Close();
                    break;
            }

        }

    }
}
