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
        private Catalog catalog;

        public CatalogUserControl()
        {
            catalog = Catalog.GetInstance();
            Loaded += CatalogUserControl_Loaded;
            InitializeComponent();
        }

        private void CatalogUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            catalogDataGrid.ItemsSource = catalog.Products;
            unitComboBox.ItemsSource = Enum.GetValues(typeof(Unit));
            unitComboBox.SelectedItem = unitComboBox.Items[0];
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = (Unit)unitComboBox.SelectedIndex;
            try
            {
                Product product = new Product(nameTextBox.Text, Convert.ToDouble(priceTextBox.Text), unit);
                if (catalog.Products.FirstOrDefault((x) => { return x.Name.ToLower().Equals(product.Name.ToLower()); }) == null)
                    catalog.Products.Add(product);
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

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (catalog.Changes)
            {
                catalog.SaveChanges();
                MessageBox.Show("Сохранено!");
            }
        }
    }
}
