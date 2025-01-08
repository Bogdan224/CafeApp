using CafeApp.Helpers;
using CafeApp.Helpers.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Scripts
{
    public class Catalog : ISavable
    {
        private static Catalog instance;
        private string path = "Saves\\Catalog.txt";

        
        public ObservableCollection<Product> Products { get; set; }
        public bool Changes { get; set; }

        private Catalog()
        {
            Products = new ObservableCollection<Product>();
            List<string> strings = FileWorker.ReadFromFile(path).ToList();
            foreach (var item in strings)
            {
                Products.Add(ConverterToJson.ConvertFromJson<Product>(item));
            }
            Changes = false;
            Products.CollectionChanged += Products_CollectionChanged;
        }

        private void Products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changes = true;
        }

        public static Catalog GetInstance()
        {
            if (instance == null) instance = new Catalog();
            return instance;
        }

        public void SaveChanges()
        {
            if (Changes)
            {
                Changes = false;
                StringBuilder changes = new StringBuilder();
                foreach (var item in Products)
                {
                    changes.Append(ConverterToJson.ConvertToJson(item) + "\n");
                }
                FileWorker.WriteToFile(path, changes.ToString());
            }
        }

    }
}
