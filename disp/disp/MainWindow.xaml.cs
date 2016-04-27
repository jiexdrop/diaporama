using ExifLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace disp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        private DataModel mdataModel;
        public MainWindow()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            mdataModel = new DataModel(path);
            DataContext = mdataModel;
        }

        private void Diaporama_Click(object sender, RoutedEventArgs e)
        {
            Diaporama n = new Diaporama(mdataModel.Fichiers);
            n.Show();
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }







}
