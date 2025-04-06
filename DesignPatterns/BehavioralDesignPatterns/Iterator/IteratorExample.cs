using System;

namespace Iterator.Example
{
    class Book
    {
        public string Name { get; set; }
    }

    interface IBookEnumerator
    {
        Book Next();
        bool HasNext();
    }

    class BookEnumerator : IBookEnumerator
    {
        IBookEnumerable BookEnumerable;
        int CurrentIndex = 0;

        public BookEnumerator(IBookEnumerable bookEnumerable) => BookEnumerable = bookEnumerable;

        public Book Next() => BookEnumerable[CurrentIndex++];
        public bool HasNext() => CurrentIndex < BookEnumerable.Count;
    }

    interface IBookEnumerable
    {
        int Count { get; }

        Book this[int index] { get; }

        IBookEnumerator GetEnumerator();
    }

    class Library : IBookEnumerable
    {
        Book[] Books;
        public int Count => Books.Length;

        public Book this[int index] => Books[index];

        public Library()
        {
            Books = new Book[]
            {
                new Book{Name="Война и мир"},
                new Book {Name="Отцы и дети"},
                new Book {Name="Вишневый сад"},
            };
        }

        public IBookEnumerator GetEnumerator() => new BookEnumerator(this);
    }

    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookEnumerator enumerator = library.GetEnumerator();
            while (enumerator.HasNext())
            {
                Book book = enumerator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
}
