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
    /// Логика взаимодействия для MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        private Storage<FinalProduct> storage;
        public MenuUserControl()
        {
            Loaded += MenuUserControl_Loaded;
            InitializeComponent();
        }

        private void MenuUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            storage = Storage<FinalProduct>.GetInstance();
            finalProductDataGrid.ItemsSource = storage.StorageCollection;
        }

        private void addFinalProductButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window is MainWindow mainWindow)
            {
                if (mainWindow.currentUC is AddFinalProductUserControl) return;
                mainWindow.currentUC.Content = new AddFinalProductUserControl();
            }
        }

        private void descriptionButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((FinalProduct)finalProductDataGrid.SelectedItem).Info());
        }
    }
}
