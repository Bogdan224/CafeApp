using System;

namespace CafeApp.Scripts
{
    public class Ingredient : IComparable<Ingredient>
    {
        private double _netWeight;
        private double _grossWeight;

        public double NetWeight
        {
            get
            {
                return _netWeight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ingredient.NetWeight wrong value");
                }
                _netWeight = value;
            }
        }
        public double GrossWeight
        {
            get
            {
                return _grossWeight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ingredient.GrossWeight wrong value");
                }
                _grossWeight = value;
            }
        }
        public ProductSuply IngredientProduct { get; set; }
        public Ingredient(
            double netWeight, 
            double grossWeight, 
            ProductSuply product)
        {
            NetWeight = netWeight;
            GrossWeight = grossWeight;
            IngredientProduct = product;
        }

        public int CompareTo(Ingredient other)
        {
            if (other == null) throw new ArgumentNullException();
            return IngredientProduct.Name.CompareTo(other.IngredientProduct.Name);
        }
        public string Info()
        {
            return $"Название: {IngredientProduct.Name}\n" +
                $"Вес нетто: {NetWeight} г.\n" +
                $"Вес брутто: {GrossWeight} г.\n";
        }
    }
}
