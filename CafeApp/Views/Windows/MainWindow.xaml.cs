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
using CafeApp.Views.UserControls;

namespace CafeApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StorageViewControl storageUC;
        private CatalogUserControl catalogUC;

        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            catalogUC = new CatalogUserControl();
            storageUC = new StorageViewControl();
            Closed += MainWindow_Closed;
            currentUC.Content = new HomeUserControl();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void storageButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUC is StorageViewControl) return;
            currentUC.Content = storageUC;
        }

        private void catalogButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUC is CatalogUserControl) return;
            currentUC.Content = catalogUC;
        }

        private void addProviderButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUC is ProviderUserControl) return;
            currentUC.Content = new ProviderUserControl();
        }
    }
}
