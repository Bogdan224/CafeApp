using System;
using System.Collections.Generic;

namespace CafeApp.Scripts
{
    [Serializable]
    /// <summary>Полученный продукт с поставки</summary>
    public class ObtainedProduct
    {
        private double _totalPrice;
        private double _count;

        public Product ProductInOrder { get; set; } 
        /// <summary>Общая цена</summary>
        public double TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                _totalPrice = value;
            }
        }
        /// <summary>Кол-во поставленных продуктов</summary>
        public double Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                _count = value;
            }
        }
        public ObtainedProduct(Product product, double totalPrice, double count)
        {
            ProductInOrder = product;
            TotalPrice = totalPrice;
            Count = count;
        }
    }
    [Serializable]
    /// <summary>Класс для регистрации поступления продуктов питания на склад</summary>
    public class Order
    {
        private DateTime _date;
        /// <summary>Поставщик</summary>
        public Provider Provider { get; set; }
        /// <summary>Дата и время поставки</summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value > DateTime.Now) throw new ArgumentException("SupplyLog.Date argument exception");
                _date = value;
            }
        }
        /// <summary>Поставленные продукты</summary>
        public List<ObtainedProduct> ObtainedProducts { get; set; }
        public Order(
            Provider provider,
            List<ObtainedProduct> obtainedProducts,
            DateTime date)
        {
            Provider = provider;
            Date = date;
            ObtainedProducts = obtainedProducts;
        }

    }
}
