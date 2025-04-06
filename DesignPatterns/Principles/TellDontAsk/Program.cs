using System;
using TellDontAsk.Example1;
using TellDontAsk.Example2;

namespace TellDontAsk
{
    class Program
    {
        static void Main()
        {
            Example1();
            Example2();
        }

        static void Example1()
        {
            var alarmClock1 = new AlarmClock1(6);
            alarmClock1.CurrentHour = 6;

            // Ask.
            if (alarmClock1.CurrentHour == alarmClock1.GetUpHour)
                alarmClock1.Alarm();
            Console.ReadLine();

            var alarmClock2 = new AlarmClock2(6);
            // TellDontAsk.
            alarmClock2.CurrentHour = 6;
            Console.ReadLine();
        }
        static void Example2()
        {
            var messages1 = new IMessage1[]
            {
                // Текстовое сообщение.
                new TextMessage1("Sam", "Tom", "Hello"),
                // Голосовое сообщение.
                new VoiceMessage1("Tom", "Sam", Array.Empty<byte>()),
            };
            foreach (IMessage1 message in messages1)
            {
                // Ask.
                if (message is TextMessage1 textMessage)
                    textMessage.Print();
                // Ask.
                else if (message is VoiceMessage1 voiceMessage)
                    voiceMessage.Play();
            }
            Console.ReadLine();

            var messages2 = new IMessage2[]
            {
                // Текстовое сообщение.
                new TextMessage2("Sam", "Tom", "Hello"),
                // Голосовое сообщение.
                new VoiceMessage2("Tom", "Sam", Array.Empty<byte>()),
            };
            foreach (IMessage2 message in messages2)
            {
                // TellDontAsk.
                message.Launch();
            }
            Console.ReadLine();
        }
    }
}
