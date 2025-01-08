using CafeApp.Helpers.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Scripts
{
    public enum Bank
    {
        [Description("Сбербанк")]
        Sberbank,
        [Description("Альфа Банк")]
        AlphaBank,
        [Description("Т-Банк")]
        TBank,
        [Description("ВТБ")]
        VTB,
        [Description("Неизвестно")]
        None
    }

    [Serializable]
    public class Director
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Director(
            string fullname,
            string phoneNumber)
        {
            FullName = fullname;
            PhoneNumber = phoneNumber;
        }

        public string Info()
        {
            return $"ФИО руководителя: {FullName}\n" +
                $"Номер телефона: {PhoneNumber}\n";
        }
    }

    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Director CompanyDirector { get; set; }

        public Company(
            string name,
            string address,
            Director companyDirector)
        {
            Name = name;
            Address = address;
            CompanyDirector = companyDirector;
        }
        public string Info()
        {
            return $"Название компании: {Name}\n" +
                $"Адресс: {Address}\n" +
                CompanyDirector.Info();
        }
    }

    [Serializable]
    public class Provider
    {
        public Company ProviderCompany { get; set; }
        public Bank ProviderBank { get; set; }
        public string Account { get; set; }
        public string INN { get; set; }

        public Provider(
            Company company,
            Bank bank,
            string account,
            string iNN)
        {
            ProviderCompany = company;
            ProviderBank = bank;
            Account = account;
            INN = iNN;
        }

        public string Info()
        {
            return ProviderCompany.Info() +
                $"Банк: {ProviderBank.BankInfo()}\n" +
                $"Счет в банке: {Account}\n" +
                $"ИНН поставщика: {INN}\n";
        }

        public void Supply(List<ObtainedProduct> products, DateTime dateTime)
        {
            Order supplyLog = new Order(this, products, dateTime);
        }
    }
}
