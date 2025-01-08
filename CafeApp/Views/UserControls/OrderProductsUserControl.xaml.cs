using CafeApp.Helpers;
using CafeApp.Helpers.Converters;
using CafeApp.Scripts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Логика взаимодействия для OrderProductsUserControl.xaml
    /// </summary>
    public partial class OrderProductsUserControl : UserControl
    {
        private ObservableCollection<ObtainedProduct> obtainedProducts;
        private List<Provider> providers;
        private Catalog catalog;

        public OrderProductsUserControl()
        {
            catalog = Catalog.GetInstance();
            Loaded += OrderProductsUserControl_Loaded;
            InitializeComponent();
        }

        private void OrderProductsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> strings = FileWorker.ReadFromFile("Saves\\Providers.txt").ToList();
            providers = new List<Provider>();
            foreach(var item in strings)
            {
                providers.Add(ConverterToJson.ConvertFromJson<Provider>(item));
            }
            providerComboBox.ItemsSource = providers;
            productComboBox.ItemsSource = catalog.Products;
            obtainedProducts = new ObservableCollection<ObtainedProduct>();
            obtainedProductDataGrid.ItemsSource = obtainedProducts;
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (productComboBox.SelectedItem != null)
                {
                    ObtainedProduct obtainedProduct = new ObtainedProduct((Product)productComboBox.SelectedItem, Convert.ToDouble(totalPriceTextBox.Text), Convert.ToDouble(countTextBox.Text));
                    if (obtainedProduct != null)
                    {
                        if (obtainedProducts.FirstOrDefault((x) => { return x.ProductInOrder.Name.Equals(
                            obtainedProduct.ProductInOrder.Name); }) is ObtainedProduct obtainedProduct1) 
                        {
                            int index = obtainedProducts.IndexOf(obtainedProduct1);
                            obtainedProducts[index].Count += obtainedProduct.Count;
                            obtainedProducts[index].TotalPrice += obtainedProduct.TotalPrice;
                        }
                        else 
                            obtainedProducts.Add(obtainedProduct);
                    }
                    else
                        MessageBox.Show("Заполните требуемые поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitTextBox.Text = ((Product)productComboBox.SelectedItem).ProductUnit.UnitInfo();
        }

        private void countTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(productComboBox.SelectedItem != null)
                    totalPriceTextBox.Text = (((Product)productComboBox.SelectedItem).Price * Convert.ToDouble(countTextBox.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (providerComboBox.SelectedItem != null && obtainedProducts.Count > 0)
                {
                    Provider provider = (Provider)providerComboBox.SelectedItem;
                    Order order = new Order(provider, obtainedProducts.ToList(), DateTime.Now);
                    if(order != null)
                    {
                        FileWorker.AppendToFile("Log\\Orders.txt", ConverterToJson.ConvertToJson(order) + "\n");
                        Storage storage = Storage.GetInstance();
                        foreach(var item in obtainedProducts)
                        {
                            if (storage.ProductSuplies.FirstOrDefault((x) => { return x.Name.Equals(item.ProductInOrder.Name); }) is ProductSuply productSuply)
                                storage.ProductSuplies[storage.ProductSuplies.IndexOf(productSuply)].StockBalance += item.Count;
                            else
                                storage.ProductSuplies.Add(new ProductSuply(item.ProductInOrder, provider, item.Count));
                        }
                        
                        MessageBox.Show("Заказ успешно составлен!");
                        ((MainWindow)Window.GetWindow(this)).currentUC.Content = new OrderProductsUserControl();
                    }
                    else
                    {
                        MessageBox.Show("Заполните требуемые поля!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните требуемые поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
