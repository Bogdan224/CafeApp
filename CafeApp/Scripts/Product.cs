using System;
using System.ComponentModel;
using System.Text;

namespace CafeApp.Scripts
{
    public enum Unit
    {
        [Description("кг")]
        kg,
        [Description("шт")]
        pc,
        [Description("Неизвестно")]
        None
    }

    [Serializable]
    public class Product
    {
        private double _price;

        public string Name { get; set; }
        public Unit ProductUnit { get; set; }
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0) throw new ArgumentException("Product.Price argument exception");
                _price = value;
            }
        }

        public Product(
            string name,
            double price,
            Unit unit)
        {
            Name = name;            
            Price = price;
            ProductUnit = unit;
        }

        public virtual string Info()
        {
            return $"Название продукта: {Name}\n" +
                $"Цена: {Price}\n";
        }
    }
}
