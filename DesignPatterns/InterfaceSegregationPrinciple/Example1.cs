using System;

namespace InterfaceSegregationPrinciple.Example1
{
    // SOLID. I - Принцип Разделения Интерфейсов (Interface Segregation Principle) можно сформулировать так:
    // Клиенты не должны вынужденно зависеть от методов, которыми не пользуются.
    // Техники для выявления нарушения этого принципа:
    // 1. Слишком большие интерфейсы.
    // 2. Компоненты в интерфейсах слабо согласованы (перекликается с Принципом Единой Ответственности).
    // 3. Методы без реализации (перекликается с Принципом Подстановки Лисков).
    interface IMessage1
    {
        string FromAddress { get; set; }
        string ToAddress { get; set; }
        string Subject { get; set; }
        string Text { get; set; }
        byte[] Voice { get; set; }

        void Send();
    }
    class EmailMessage1 : IMessage1
    {
        public string FromAddress { get; set; } = string.Empty;
        public string ToAddress { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public byte[] Voice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Send() => Console.WriteLine($"Отправляем Email-сообщение: {Text}.");
    }
    class SmsMessage1 : IMessage1
    {
        public string FromAddress { get; set; } = string.Empty;
        public string ToAddress { get; set; } = string.Empty;
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Text { get; set; } = string.Empty;
        public byte[] Voice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Send() => Console.WriteLine($"Отправляем Sms-сообщение: {Text}.");
    }
    class VoiceMessage1 : IMessage1
    {
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] Voice { get; set; } = new byte[] { };

        public void Send() => Console.WriteLine($"Отправляем голосовое сообщение.");
    }

    // Здесь мы сталкиваемся с проблемой: свойство Subject, которое определяет тему сообщения, в классе SmsMessage не нужно. Т.е., в классе
    // SmsMessage появляется избыточная функциональность, от которой класс SmsMessage начинает зависеть.
    // При нарушении этого принципа клиент, использующий некоторый интерфейс со всеми его методами, зависит от методов, которыми не пользуется, и
    // поэтому оказывается восприимчив к изменениям в этих методах. В итоге мы приходим к жесткой зависимости между различными частями интерфейса,
    // которые могут быть не связаны при его реализации.
    // Для решения возникшей проблемы надо выделить из классов группы связанных членов и определить для каждой группы свой интерфейс.
    // В итоге применение Принципа Разделения Интерфейсов делает систему слабосвязанной, и тем самым ее легче модифицировать и обновлять.
    interface IMessage2
    {
        string FromAddress { get; set; }
        string ToAddress { get; set; }

        void Send();
    }
    interface ITextMessage2 : IMessage2
    {
        string Text { get; set; }
    }
    interface IVoiceMessage2 : IMessage2
    {
        byte[] Voice { get; set; }
    }
    interface IEmailMessage2 : ITextMessage2
    {
        string Subject { get; set; }
    }

    class EmailMessage : IEmailMessage2
    {
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Text { get; set; } = "";

        public void Send() => Console.WriteLine($"Отправляем Email-сообщение: {Text}");
    }
    class SmsMessage : ITextMessage2
    {
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string Text { get; set; } = "";

        public void Send() => Console.WriteLine($"Отправляем Sms-сообщение: {Text}");
    }
    class VoiceMessage : IVoiceMessage2
    {
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public byte[] Voice { get; set; } = Array.Empty<byte>();

        public void Send() => Console.WriteLine("Отправляем голосовое сообщение.");
    }
}
