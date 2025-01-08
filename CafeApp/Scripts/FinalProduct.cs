using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CafeApp.Scripts
{
    /*
     * Сырный крем-суп
     * Стейк из свинной шеи
     * Тирамису
     * Вино
     * Картофель фри
    */
    public enum ProductGroup
    {
        [Description("Первое блюдо")]
        FirstCourse,
        [Description("Второе блюдо")]
        SecondCourse,
        [Description("Десерт")]
        Dessert,
        [Description("Напиток")]
        Drink,
        [Description("Закуска")]
        Snack,
        [Description("Неизвестно")]
        None
    }

    /// <summary>
    /// Класс описывающий свойства готовой продукции
    /// </summary>
    public class FinalProduct
    {
        private double _price;

        public string Name { get; set; }
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0) throw new ArgumentException("FinalProduct.Price argument exception");
                _price = value;
            }
        }
        public ProductGroup Group { get; set; }
        public string Description { get; set; }
        //public Uri Photo { get; set; }
        public List<Ingredient> Receipt { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="group">Группа</param>
        /// <param name="price">Цена</param>
        /// <param name="description">Описание</param>
        // <param name="photo">Uri фотографии</param>
        /// <param name="receipt">Список ингредиентов, использующихся в продукте</param>
        public FinalProduct(
            string name, 
            double price,
            ProductGroup group,
            string description,
            //Uri photo,
            List<Ingredient> receipt)
        {
            Name = name;
            Price = price;
            Group = group;            
            Description = description;
            //Photo = photo;
            Receipt = receipt;
        }

        public string Info()
        {
            StringBuilder res = new StringBuilder();
            res.Append($"Название блюда: {Name}\n" +
                $"Цена: {Price}\n" +
                $"Группа: {Group}\n" +
                $"Описание: {Description}\n" +
                //$"Uri фото: {Photo}\n" +
                $"Рецепт:\n");
            int x = 1;
            foreach (var item in Receipt)
            {
                res.Append($"Ингредиент {x}\n");
                res.Append(item.Info());
                x++;
            }
            return res.ToString();
        }
    }
}
