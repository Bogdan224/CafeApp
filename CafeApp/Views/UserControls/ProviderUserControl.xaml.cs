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
    /// Логика взаимодействия для ProviderUserControl.xaml
    /// </summary>
    public partial class ProviderUserControl : UserControl
    {
        public ProviderUserControl()
        {
            Loaded += ProviderUserControl_Loaded;
            InitializeComponent();
        }

        private void ProviderUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            bankComboBox.ItemsSource = Enum.GetValues(typeof(Bank));
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bankComboBox.SelectedItem != null)
                {
                    Director director = new Director(directorNameTextBox.Text, phoneNumberTextBox.Text);
                    Company company = new Company(companyNameTextBox.Text, addressTextBox.Text, director);
                    Bank bank = (Bank)bankComboBox.SelectedItem;
                    Provider provider = new Provider(company, bank, accountTextBox.Text, innTextBox.Text);
                    if(provider != null)
                    {
                        FileWorker.AppendToFile("Saves\\Providers.txt", ConverterToJson.ConvertToJson(provider) + "\n");
                        MessageBox.Show("Поставщик успешно добавлен!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните требуемые поля!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
