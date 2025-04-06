using System;

namespace TellDontAsk.Example2
{
    interface IMessage1
    {
        string Sender { get; }
        string Receiver { get; }
    }
    class TextMessage1 : IMessage1
    {
        public string Sender { get; }
        public string Receiver { get; }
        public string Text { get; }

        public TextMessage1(string sender, string receiver, string text)
        {
            Sender = sender;
            Receiver = receiver;
            Text = text;
        }

        public void Print() => Console.WriteLine($"Текстовое сообщение: {Text}.");
    }
    class VoiceMessage1 : IMessage1
    {
        public string Sender { get; }
        public string Receiver { get; }
        public byte[] Voice { get; }
        
        public VoiceMessage1(string sender, string receiver, byte[] voice)
        {
            Sender = sender;
            Receiver = receiver;
            Voice = voice;
        }

        public void Play() => Console.WriteLine("Воспроизведение голосового сообщения.");
    }

    interface IMessage2
    {
        string Sender { get; }
        string Receiver { get; }

        void Launch();
    }
    class TextMessage2 : IMessage2
    {
        public string Sender { get; }
        public string Receiver { get; }
        public string Text { get; }

        public TextMessage2(string sender, string receiver, string text)
        {
            Sender = sender;
            Receiver = receiver;
            Text = text;
        }

        public void Print() => Console.WriteLine($"Текстовое сообщение: {Text}.");
        public void Launch() => Print();
    }
    class VoiceMessage2 : IMessage2
    {
        public string Sender { get; }
        public string Receiver { get; }
        public byte[] Voice { get; }

        public VoiceMessage2(string sender, string receiver, byte[] voice)
        {
            Sender = sender;
            Receiver = receiver;
            Voice = voice;
        }

        public void Play() => Console.WriteLine("Воспроизведение голосового сообщения.");
        public void Launch() => Play();
    }
}
