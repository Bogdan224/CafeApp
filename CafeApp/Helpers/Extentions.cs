using CafeApp.Scripts;
using System;

namespace CafeApp.Helpers.Converters
{
    public static class Extentions
    {
        private readonly static string None = "Неизвестно";
        public static string UnitInfo(this Unit unit)
        {
            switch (unit)
            {
                case Unit.kg: return "кг";
                case Unit.pc: return "шт";
                case Unit.None: return None;
                default: throw new NullReferenceException("Unit default value");
            }
        }
        public static string BankInfo(this Bank bank)
        {
            switch (bank) 
            {
                case Bank.AlphaBank: return "Альфа банк";
                case Bank.Sberbank: return "Сбербанк";
                case Bank.TBank: return "Т-Банк";
                case Bank.VTB: return "ВТБ";
                case Bank.None: return None;
                default: throw new NullReferenceException("Bank default value");
            }   
        }
        
        public static string ProductGroupInfo(this ProductGroup productGroup)
        {
            switch (productGroup)
            {
                case ProductGroup.FirstCourse: return "Первое блюдо";
                case ProductGroup.SecondCourse: return "Второе блюдо";
                case ProductGroup.Dessert: return "Десерт";
                case ProductGroup.Drink: return "Напиток";
                case ProductGroup.Snack: return "Закуска";
                case ProductGroup.None: return None;
                default: throw new NullReferenceException("ProductGroup default value");
            }
        }
    }
}
