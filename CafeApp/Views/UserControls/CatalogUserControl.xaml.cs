using CafeApp.Scripts;
using CafeApp.Views.Windows;
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
    /// Логика взаимодействия для CatalogUserControl.xaml
    /// </summary>
    public partial class CatalogUserControl : UserControl
    {
        private Storage<Product> storage;

        public CatalogUserControl()
        {
            storage = Storage<Product>.GetInstance();
            Loaded += CatalogUserControl_Loaded;
            InitializeComponent();
        }

        private void CatalogUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catalogDataGrid.ItemsSource = storage.StorageCollection;
            unitComboBox.ItemsSource = Enum.GetValues(typeof(Unit));
            unitComboBox.SelectedItem = unitComboBox.Items[0];
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = (Unit)unitComboBox.SelectedIndex;
            try
            {
                Product product = new Product(nameTextBox.Text, Convert.ToDouble(priceTextBox.Text), unit);
                if (storage.StorageCollection.FirstOrDefault((x) => { return x.Name.ToLower().Equals(product.Name.ToLower()); }) == null)
                {
                    storage.StorageCollection.Add(product);
                    storage.SaveChanges();
                }
                else
                    MessageBox.Show("Данный продукт присутствует в каталоге!");
                nameTextBox.Text = "";
                priceTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
