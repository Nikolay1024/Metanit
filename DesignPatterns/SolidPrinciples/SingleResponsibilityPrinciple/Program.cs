using SingleResponsibilityPrinciple.Example2;
using System;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main()
        {
            var mobileStore = new MobileStore(new ConsolePhoneReader(), new GeneralPhoneBinder(),
                new GeneralPhoneValidator(), new TextPhoneSaver());
            mobileStore.Process();

            Console.ReadLine();
        }
    }
}
