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

        public void AddCustomer(string name, string address, string phone)
        {
            dataContext.usp_add_customer(name, address, phone);
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
        public void ShowChangeCustomerWindow(Customer customer)
        {
            ChangeCustomer cc = new ChangeCustomer();
            cc.CustomerToChange = customer;
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

        public void ShowBorrowFromBookView(BookCopy bookCopy)
        {
            BorrowFromBookView view = new BorrowFromBookView();
            view.BookCopyToBorrow = bookCopy;
            view.Show();
            view.SetTitle();
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

        internal void AddBook(string ISBN, string title, int pages, int year, string author, string publisher)
        {
            dataContext.usp_add_book(ISBN, title, pages, year, author, publisher);
        }

        public void ReturnBook(Borrowing bor)
        {
            dataContext.usp_return_book(bor.BookCopy.Book.ISBN, bor.Customer.CustomerID, bor.BookCopy.CopyID);
        }

        public void ShowBookView()
        {
            BookView bs = new BookView();
            bs.Show();
        }

        public void Borrow(BookCopy BookCopyToBorrow, Customer customer)
        {
            string isbn = BookCopyToBorrow.Book.ISBN;
            int customerID = customer.CustomerID;
            int copyID = BookCopyToBorrow.CopyID;
            dataContext.usp_borrow_book(isbn, customerID, copyID);
        }
    }
}