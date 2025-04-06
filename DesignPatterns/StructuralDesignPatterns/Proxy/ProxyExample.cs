using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Proxy.Example
{
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
    class BookStoreContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
    }

    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        BookStoreContext DbContext = new BookStoreContext();

        public Page GetPage(int number) => DbContext.Pages.FirstOrDefault(p => p.Number == number);
        public void Dispose() => DbContext?.Dispose();
    }

    class BookStoreProxy : IBook
    {
        BookStore BookStore;
        List<Page> Pages = new List<Page>();

        public Page GetPage(int number)
        {
            Page page = Pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (BookStore == null)
                    BookStore = new BookStore();
                page = BookStore.GetPage(number);
                Pages.Add(page);
            }
            return page;
        }
        public void Dispose() => BookStore?.Dispose();
    }
}
