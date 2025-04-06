using System;
using System.Collections.Generic;
using System.IO;

namespace SingleResponsibilityPrinciple.Example2
{
    // Есть ряд распространенных сценариев, которые обычно выносятся в отдельные компоненты:
    // 1. Логика хранения данных
    // 2. Валидация
    // 3. Механизм уведомлений пользователя
    // 4. Обработка ошибок
    // 5. Логгирование
    // 6. Выбор класса или создание его объекта
    // 7. Форматирование
    // 8. Парсинг
    // 9. Маппинг данных
    class Phone1
    {
        public string Model { get; }
        public int Price { get; }

        public Phone1(string model, int price)
        {
            Model = model;
            Price = price;
        }
    }

    class MobileStore1
    {
        List<Phone1> Phones = new List<Phone1>();

        public void Process()
        {
            // Ввод данных.
            Console.WriteLine("Введите модель:");
            string model = Console.ReadLine();
            Console.WriteLine("Введите цену:");

            // Валидация.
            bool result = int.TryParse(Console.ReadLine(), out int price);
            if (string.IsNullOrEmpty(model) || result == false || price <= 0)
            {
                Console.WriteLine("Некорректно введены данные.");
                return;
            }

            // Создание объекта Phone.
            Phones.Add(new Phone1(model, price));

            // Сохранение данных в файл.
            using (var streamWriter = new StreamWriter("store.txt"))
                streamWriter.WriteLine($"{model} - {price}");
            Console.WriteLine("Данные успешно обработаны.");
        }
    }

    class Phone2
    {
        public string Model { get; }
        public int Price { get; }

        public Phone2(string model, int price)
        {
            Model = model;
            Price = price;
        }
    }

    class MobileStore
    {
        List<Phone2> Phones = new List<Phone2>();

        public IPhoneReader Reader { get; set; }
        public IPhoneBinder Binder { get; set; }
        public IPhoneValidator Validator { get; set; }
        public IPhoneSaver Saver { get; set; }

        public MobileStore(IPhoneReader reader, IPhoneBinder binder, IPhoneValidator validator, IPhoneSaver saver)
        {
            Reader = reader;
            Binder = binder;
            Validator = validator;
            Saver = saver;
        }

        public void Process()
        {
            // Ввод данных.
            string[] data = Reader.GetInputData();

            // Создание объекта Phone.
            Phone2 phone = Binder.CreatePhone(data);

            // Валидация.
            if (!Validator.IsValid(phone))
            {
                Console.WriteLine("Некорректно введены данные.");
                return;
            }

            // Сохранение данных в файл.
            Phones.Add(phone);
            Saver.Save(phone, "store.txt");
            Console.WriteLine("Данные успешно обработаны.");
        }
    }

    interface IPhoneReader
    {
        string[] GetInputData();
    }
    class ConsolePhoneReader : IPhoneReader
    {
        public string[] GetInputData()
        {
            Console.WriteLine("Введите модель:");
            string model = Console.ReadLine();
            Console.WriteLine("Введите цену:");
            string price = Console.ReadLine();
            return new string[] { model, price };
        }
    }

    interface IPhoneBinder
    {
        Phone2 CreatePhone(string[] data);
    }
    class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone2 CreatePhone(string[] data)
        {
            if (data.Length == 2 && data[0] is string model && model.Length > 0 && int.TryParse(data[1], out int price))
                return new Phone2(model, price);

            throw new Exception("Ошибка привязки модели Phone.");
        }
    }

    interface IPhoneValidator
    {
        bool IsValid(Phone2 phone);
    }
    class GeneralPhoneValidator : IPhoneValidator
    {
        public bool IsValid(Phone2 phone) => !string.IsNullOrEmpty(phone.Model) && phone.Price > 0;
    }

    interface IPhoneSaver
    {
        void Save(Phone2 phone, string fileName);
    }
    class TextPhoneSaver : IPhoneSaver
    {
        public void Save(Phone2 phone, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName))
                streamWriter.WriteLine($"{phone.Model} - {phone.Price}");
        }
    }
}
