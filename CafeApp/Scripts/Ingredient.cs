using CafeApp.Helpers.Converters;
using System;

namespace CafeApp.Scripts
{
    public class Ingredient : IComparable<Ingredient>
    {
        private double _count;

        public double Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ingredient.Count wrong value");
                }
                _count = value;
            }
        }

        public Product IngredientProduct { get; set; }
        public Ingredient(
            double count, 
            Product product)
        {
            Count = count;
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
                $"Кол-во: {Count} {IngredientProduct.ProductUnit.UnitInfo()}\n";
        }
    }
}
