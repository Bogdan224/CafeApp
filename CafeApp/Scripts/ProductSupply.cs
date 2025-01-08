using CafeApp.Helpers.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Scripts
{
    ///<summary>
    ///Запасы продуктов питания, которые хранятся на складе и используются в качестве 
    ///ингредиентов при приготовлении пищи
    ///</summary>
    [Serializable]
    public class ProductSuply : Product
    {
        private double _pricePremium;
        private double _stockBalance;

        ///<summary>Ценовая надбавка (в процентах)</summary>
        public double PricePremium
        {
            get
            {
                return _pricePremium;
            }
            set
            {
                if (value < 0) throw new ArgumentException("PricePremium argument exception!");
                _pricePremium = value;
            }
        }
        /// <summary>Остаток на складе</summary>
        public double StockBalance
        {
            get
            {
                return _stockBalance;
            }
            set
            {
                if (value < 0) throw new ArgumentException("StockBalance argument exception!");
                _stockBalance = value;
            }
        }

        /// <summary>Поставщик</summary>
        public Provider Provider { get; set; }

        /// <param name="pricePremium">Ценовая надбавка (в процентах)</param>
        /// <param name="stockBalance">Остаток на складе</param>
        /// <param name="provider">Поставщик</param>
        [JsonConstructor]
        public ProductSuply(
            string name,
            double price,
            Unit unit,
            double pricePremium,
            double stockBalance,
            Provider provider)
            : base(name,
                  price, 
                  unit)
        {
            PricePremium = pricePremium;
            StockBalance = stockBalance;
            Provider = provider;
        }

        public ProductSuply(
            Product product,
            Provider provider,
            double stockBalance,
            double pricePremium = 10)
            : base(product.Name,
                  product.Price,
                  product.ProductUnit)
        {
            PricePremium = pricePremium;
            StockBalance = stockBalance;
            Provider = provider;
        }

        public override string Info()
        {
            return base.Info() +
                $"Ценовая надбавка (в процентах): {PricePremium}\n" +
                $"Остаток на складе: {StockBalance} {ProductUnit.UnitInfo()}\n" +
                $"Поставщик: {Provider}\n";
        }
    }
}
