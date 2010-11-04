using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblan.Model;

namespace Biblan.Controller
{
    public class Controller
    {
        private static Controller controllerSingleton;
        bibliotekDataContext dataContext = new bibliotekDataContext();
        // private in order to disable instantiating
        private Controller()
        {
        }
        public static Controller GetInstance()
        {
            if (controllerSingleton == null)
            {
                controllerSingleton = new Controller();
            }
            return controllerSingleton;
        }
        public List<Book> GetAllBooks()
        {
            var query = from c in dataContext.search_books_titles("")
                        select new Book { Title = c.Title, NumberOfPages = (int)c.NumberOfPages, Publisher = c.Publisher, ISBN = c.ISBN };

            List<Book> books = query.ToList();
            return books;
        }
        #region gamla tester
        //private void AddBook()
        //{
        //    bibliotekDataContext dataContext = new bibliotekDataContext();
        //    dataContext.usp_add_book("0316769533", "The Catcher in the Rye", 276, 1951, "Little, Brown and Company");
        //}
        //private void AddCustomer()
        //{
        //    bibliotekDataContext dataContext = new bibliotekDataContext();
        //    dataContext.usp_add_customer(0001, "Nils Nilsson", "Sveagatan 31 A", "040-123456");
        //}
        //private void AddCopy()
        //{
        //    bibliotekDataContext dataContext = new bibliotekDataContext();
        //    dataContext.usp_add_copy("0316769533", 0001);
        //}
        //private void GetBooksWithMoreThan500Pages()
        //{
        //    string output = "";
        //    bibliotekDataContext dataContext = new bibliotekDataContext();
        //    var query = from c in dataContext.search_number_of_book_pages()
        //                select new Book { Title = c.Title, NumberOfPages = (int) c.NumberOfPages };

        //    List<Book> books = query.ToList();

        //    foreach (Book book in books)
        //    {
        //        output += book.Title.Substring(0,7) + " - " + book.NumberOfPages + "\r\n";            
        //    }
        //    txtBlockTest.Text = output;        
        //}

        //private void GetBooksOlderThan15Years()
        //{
        //    string output = "";
        //    bibliotekDataContext dataContext = new bibliotekDataContext();
        //    var query = from c in dataContext.search_book_print_year()
        //                select new { c.Title, c.PrintYear };

        //    foreach (var book in query)
        //    {
        //        output += book.Title + " - " + book.PrintYear + "\r\n";
        //    }
        //    txtBlockTest.Text = output;
        //}
        #endregion
    }
}
