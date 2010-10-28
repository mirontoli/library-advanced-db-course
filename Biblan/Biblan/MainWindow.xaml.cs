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

namespace Biblan
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
            TestMyFunction();
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

        private void TestMyFunction()
        {
            string output = "";
            bibliotekDataContext dataContext = new bibliotekDataContext();
            var query = from c in dataContext.search_number_of_book_pages()
                        select new { c.Title, c.NumberOfPages };

            foreach (var book in query)
            {
                output += book.Title + " - " + book.NumberOfPages + "\r\n";            
            }
            txtBlockTest.Text = output;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
