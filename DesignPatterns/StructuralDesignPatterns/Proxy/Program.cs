using Proxy.Example;
using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IBook book = new BookStoreProxy())
            {
                // Читаем первую страницу.
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);

                // Читаем вторую страницу.
                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);

                // Возвращаемся на первую страницу.
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }

            Console.ReadLine();
        }
    }
}
