using CafeApp.Helpers;
using CafeApp.Helpers.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace CafeApp.Scripts
{
    public class Storage<T>: ISavable
    {
        private static Storage<T> instance;
        private string path = "Saves\\" + ".txt";
        private List<T> addedItems;

        public bool AddChanges { get; set; }
        public bool Changes { get; set; }
        public ObservableCollection<T> StorageCollection { get; set; }

        private Storage()
        {
            path = "Saves\\" + typeof(T).Name.ToString() + ".txt";
            Changes = false;
            AddChanges = false;
            addedItems = new List<T>();
            StorageCollection = new ObservableCollection<T>();

            IEnumerable<string> strings = FileWorker.ReadFromFile(path);
            foreach (var item in strings)
            {
                StorageCollection.Add(ConverterToJson.ConvertFromJson<T>(item));
            }
            StorageCollection.CollectionChanged += ProductSuply_CollectionChanged;
        }

        private void ProductSuply_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is T item)
                    {
                        AddChanges = true;
                        addedItems.Add(item);
                    }
                    break;
                default:
                    Changes = true;
                    break;
            }
            
        }

        public static Storage<T> GetInstance()
        {
            if (instance == null)
                instance = new Storage<T>();
            return instance;
        }

        public void SaveChanges()
        {
            if (Changes)
            {
                Changes = false;
                StringBuilder changes = new StringBuilder();
                foreach (var item in StorageCollection)
                {
                    changes.Append(ConverterToJson.ConvertToJson(item) + "\n");
                }
                FileWorker.WriteToFile(path, changes.ToString());
            }
            else if (AddChanges)
            {
                AddChanges = false;
                StringBuilder changes = new StringBuilder();
                foreach (var item in addedItems)
                {
                    changes.Append(ConverterToJson.ConvertToJson(item) + "\n");
                }
                FileWorker.AppendToFile(path, changes.ToString());
            }
        }
    }
}
