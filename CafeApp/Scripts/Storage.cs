using CafeApp.Helpers;
using CafeApp.Helpers.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CafeApp.Scripts
{
    public class Storage: ISavable
    {
        private static Storage instance;
        private string path = "Saves\\Storage.txt";

        public bool Changes { get; set; }
        public ObservableCollection<ProductSuply> ProductSuplies { get; set; }

        private Storage()
        {
            Changes = false;
            ProductSuplies = new ObservableCollection<ProductSuply>();
            IEnumerable<string> strings = FileWorker.ReadFromFile(path);
            foreach (var item in strings)
            {
                ProductSuplies.Add(ConverterToJson.ConvertFromJson<ProductSuply>(item));
            }
            ProductSuplies.CollectionChanged += ProductSuply_CollectionChanged;
        }

        private void ProductSuply_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Changes = true;
        }

        public static Storage GetInstance()
        {
            if (instance == null)
                instance = new Storage();
            return instance;
        }

        public void SaveChanges()
        {
            if (Changes)
            {
                Changes = false;
                StringBuilder changes = new StringBuilder();
                foreach (var item in ProductSuplies)
                {
                    changes.Append(ConverterToJson.ConvertToJson(item) + "\n");
                }
                FileWorker.WriteToFile(path, changes.ToString());
            }
        }
    }
}
