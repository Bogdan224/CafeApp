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

namespace CafeApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SaveChanges.xaml
    /// </summary>
    public partial class SaveChanges : Window
    {
        public bool Save;
        public SaveChanges()
        {
            Save = false;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Save = true;
            Close();
        }

        private void dontSaveButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
