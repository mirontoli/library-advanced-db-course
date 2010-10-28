using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblan.Model;

namespace Biblan.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TestConnection();
            GetBooksWithMoreThan500Pages();
            //AddBook();
        }

        private void TestConnection()
        {
            string output = "";
            bibliotekDataContext dataContext = new bibliotekDataContext();
            var query = from c in dataContext.search_books_titles("ma")
                        select new { c.ISBN, c.Title };

            foreach (var book in query)
            {
                output += book.ISBN + " - " + book.Title + "\r\n";
            }
            txtBlockTest.Text = output;
        }

        private void GetBooksWithMoreThan500Pages()
        {
            string output = "";
            bibliotekDataContext dataContext = new bibliotekDataContext();
            var query = from c in dataContext.search_number_of_book_pages()
                        select new Book { Title = c.Title, NumberOfPages = (int) c.NumberOfPages };

            List<Book> books = query.ToList();

            foreach (Book book in books)
            {
                output += book.Title.Substring(0,7) + " - " + book.NumberOfPages + "\r\n";            
            }
            txtBlockTest.Text = output;        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBook()
        {
            bibliotekDataContext dataContext = new bibliotekDataContext();
            dataContext.usp_add_book("0316769533", "The Catcher in the Rye", 276, 1951, "Little, Brown and Company");
        }
    }
}
