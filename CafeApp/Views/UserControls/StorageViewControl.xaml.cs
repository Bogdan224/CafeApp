using CafeApp.Helpers;
using CafeApp.Helpers.Converters;
using CafeApp.Scripts;
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

namespace CafeApp.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для StorageViewControl.xaml
    /// </summary>
    public partial class StorageViewControl : UserControl
    {
        private Storage _storage;

        public StorageViewControl()
        {
            Loaded += StorageViewControl_Loaded;
            InitializeComponent();
        }

        private void StorageViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            _storage = Storage.GetInstance();
            dataGrid.ItemsSource = _storage.ProductSuplies;
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if(window is MainWindow mainWindow)
            {
                if (mainWindow.currentUC is OrderProductsUserControl) return;
                mainWindow.currentUC.Content = new OrderProductsUserControl();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_storage.Changes)
            {
                _storage.SaveChanges();
                MessageBox.Show("Сохранено!");
            }
        }
    }
}
