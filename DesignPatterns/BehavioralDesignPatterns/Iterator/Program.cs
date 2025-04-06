using Iterator.Example;
using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            var reader = new Reader();
            reader.SeeBooks(library);

            Console.ReadLine();
        }
    }
}
