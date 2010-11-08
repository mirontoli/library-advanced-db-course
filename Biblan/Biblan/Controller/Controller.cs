using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblan.Model;
using Biblan.Views;

namespace Biblan.Controller
{
    public class Controller
    {
        private static Controller controllerSingleton;
        //bibliotekDataContext dataContext = new bibliotekDataContext();
        BibAnotherChanceDataContext dataContext = new BibAnotherChanceDataContext();
        // private in order to disable instantiating
        public CustomerView CustomerView
        {
            get;
            set;
        }
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
        public List<Borrowing> GetAllBorrowings()
        {
            var query = from c in dataContext.get_all_borrows()
                        select new 
                        {
                            ISBN = c.ISBN,
                            CopyID = c.CopyID,
                            CustomerID = c.CustomerID
                        };
            List<Borrowing> borrowings = new List<Borrowing>();
            foreach (var item in query)
            {
                Book book = new Book();
                book.ISBN = item.ISBN;

                BookCopy bc = new BookCopy();
                bc.Book = book;
                bc.CopyID = item.CopyID;

                Customer cust = new Customer();
                cust.CustomerID = item.CustomerID;

                Borrowing b = new Borrowing();
                b.BookCopy = bc;
                b.Customer = cust;

                borrowings.Add(b);           
            }
            return borrowings;

        }
        public List<Book> GetAllBooks()
        {
            var query = from c in dataContext.search_books_titles("")
                        select new Book
                        {
                            Title = c.Title,
                            NumberOfPages = (int)c.NumberOfPages,
                            Publisher = c.Publisher,
                            ISBN = c.ISBN,
                            Author = c.Author
                        };
            List<Book> books = null;
            try
            {
                books = query.ToList<Book>();
            }
            catch (Exception)
            {
            }
            return books;
        }
        public List<Book> GetAllBooksWithMoreThan500Pages()
        {
            var query = from c in dataContext.search_number_of_book_pages()
                        select new Book
                        {
                            Title = c.Title,
                            NumberOfPages = (int)c.NumberOfPages,
                            Publisher = c.Publisher,
                            ISBN = c.ISBN,
                            Author = c.Author
                        };

            List<Book> books = query.ToList();
            return books;
        }
        public List<Book> GetAllBooksThatBeginsWithA()
        {
            var query = from c in dataContext.search_books_with_a_title_that_begins_with_A()
                        select new Book
                        {
                            Title = c.Title,
                            NumberOfPages = (int)c.NumberOfPages,
                            Publisher = c.Publisher,
                            ISBN = c.ISBN,
                            Author = c.Author
                        };

            List<Book> books = query.ToList();
            return books;
        }
        public List<Book> GetAllBooksThatAreOlderThan15Years()
        {
            var query = from c in dataContext.search_book_print_year()
                        select new Book
                        {
                            Title = c.Title,
                            NumberOfPages = (int)c.NumberOfPages,
                            Publisher = c.Publisher,
                            ISBN = c.ISBN,
                            Author = c.Author
                        };

            List<Book> books = query.ToList();
            return books;
        }

        public List<Book> GetLatestBookBorrowed() // kan vara bra att använda lista om nu, mot förmodan, två böcker skulle lånas ut under exakt samma millisekund.
        {
            var query = from c in dataContext.get_last_book_borrowed()
                        select new Book
                        {
                            Title = c.Title,
                            NumberOfPages = (int)c.NumberOfPages,
                            Publisher = c.Publisher,
                            ISBN = c.ISBN,
                            Author = c.Author
                        };

            List<Book> books = query.ToList();
            return books;
        }

        public void AddCustomer(int customerID, string name, string address, string phone)
        {
            dataContext.usp_add_customer(customerID, name, address, phone);
        }

        public List<Customer> GetCustomersWithMoreThanOneBook()
        {
            var query = from c in dataContext.search_customers_with_more_than_one_book()
                        select new Customer
                        {
                            CustomerID = c.CustomerID,
                            Name = c.Name,
                            Address = c.Address,
                            Phone = c.Phone
                        };

            List<Customer> customers = query.ToList();
            return customers;
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
            //bibliotekDataContext dataContext = new bibliotekDataContext();
            //dataContext.usp_add_copy("0316769533", 1);
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
        //private void GetBooksThatHasATitleThatBeginsWithAnA()
        //{
        //    string output = "";
        //    bibliotekDataContext dataContext = new bibliotekDataContext();
        //    var query = from c in dataContext.search_books_with_a_title_that_begins_with_A()
        //                select new Book { Title = c.Title, NumberOfPages = (int) c.NumberOfPages, Author = c.Author };

        //    List<Book> books = query.ToList();

        //    foreach (Book book in books)
        //    {
        //        output += book.Title.Substring(0,7) + " - " + book.NumberOfPages + " - " + book.Author "\r\n";            
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

        public void ShowSmallExtrasWindow()
        {
            SmallExtras sx = new SmallExtras();
            sx.Show();
        }

        public void ShowCustomerViewWindow()
        {
            CustomerView cv = new CustomerView();
            cv.Show();
        }

        public void ShowAddCustomerWindow()
        {
            AddCustomer ac = new AddCustomer();
            ac.Show();
        }

        public void ShowAddBookWindow()
        {
            addBook ab = new addBook();
            ab.Show();
        }

        public List<BookCopy> getCopies(Book book)
        {
            List<BookCopy> copies = null;
            var query = from c in dataContext.get_copies_for_a_book(book.ISBN)
                        select new BookCopy {
                            CopyID = c.CopyID
                        };
            copies = query.ToList<BookCopy>();
            return copies;
        }
        public List<BookCopy> GetAvailableCopies(Book book)
        {
            List<BookCopy> copies = null;
            var query = from c in dataContext.get_available_copies_for_a_book(book.ISBN)
                        select new BookCopy
                        {
                            CopyID = c.CopyID
                        };
            copies = query.ToList<BookCopy>();
            return copies;
        }
        public void ShowChangeCustomerWindow()
        {
            ChangeCustomer cc = new ChangeCustomer();
            cc.Show();
        }

        public void ShowDeleteCustomerWindow()
        {
            DeleteCustomer dc = new DeleteCustomer();
            dc.Show();
        }

        public void ShowBorrowingsWindow()
        {
            BorrowingView bv = new BorrowingView();
            bv.Show();
        }

        public void AddBookCopy(Book book)
        {
            dataContext.usp_add_copy(book.ISBN);
        }

        public void ShowBorrowFromBookView(Book book)
        {
            BorrowFromBookView view = new BorrowFromBookView();
            view.BookToBorrow = book;
            view.Show();
        }

        internal void ChangeCustomer(int CID, string name, string address, string phone)
        {
            dataContext.usp_update_customer(CID, name, address, phone);
            this.CustomerView.TestBind();
        }

        internal void DeleteCustomer(int CID)
        {
            dataContext.usp_delete_customer(CID);
        }

        public List<Customer> GetAllCustomers()
        {
            var query = from c in dataContext.get_all_customers()
                        select new Customer
                        {
                            CustomerID = c.CustomerID,
                            Name = c.Name,
                            Address = c.Address,
                            Phone = c.Phone
                        };

            List<Customer> customers = query.ToList();
            return customers;
        }
    }
}