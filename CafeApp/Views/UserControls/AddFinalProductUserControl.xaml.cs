using CafeApp.Helpers.Converters;
using CafeApp.Scripts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddFinalProductUserControl.xaml
    /// </summary>
    public partial class AddFinalProductUserControl : UserControl
    {
        private Storage<FinalProduct> storage;
        private ObservableCollection<Ingredient> ingredients;
        public AddFinalProductUserControl()
        {
            Loaded += AddFinalProductUserControl_Loaded;
            InitializeComponent();
        }

        private void AddFinalProductUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            storage = Storage<FinalProduct>.GetInstance();
            ingredients = new ObservableCollection<Ingredient>();
            productComboBox.ItemsSource = Storage<Product>.GetInstance().StorageCollection;
            groupComboBox.ItemsSource = Enum.GetValues(typeof(ProductGroup));
            ingredientDataGrid.ItemsSource = ingredients; 
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupComboBox.SelectedItem is ProductGroup group && ingredients.Count > 0)
                {
                    if (storage.StorageCollection.FirstOrDefault((x)=> { return x.Name.ToLower().Equals(nameTextBox.Text.ToLower()); }) == null)
                    {
                        FinalProduct finalProduct = new FinalProduct(nameTextBox.Text, Convert.ToDouble(priceTextBox.Text), group,
                            descriptionTextBox.Text, ingredients.ToList());
                        storage.StorageCollection.Add(finalProduct);
                        storage.SaveChanges();
                        MessageBox.Show("Блюдо добавлено!");
                        MainWindow window = (MainWindow)Window.GetWindow(this);
                        window.currentUC.Content = new AddFinalProductUserControl();
                    }
                    else
                    {
                        nameTextBox.Text = "";
                        MessageBox.Show("Такое блюдо уже есть!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(productComboBox.SelectedItem != null)
                {
                    Ingredient ingredient = new Ingredient(Convert.ToDouble(countTextBox.Text), (Product)productComboBox.SelectedItem);
                    ingredients.Add(ingredient);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productComboBox.SelectedItem is Product suply)
                unitTextBox.Text = suply.ProductUnit.UnitInfo();
        }
    }
}
