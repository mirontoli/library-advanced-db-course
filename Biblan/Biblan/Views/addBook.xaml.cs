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
using System.Windows.Shapes;

namespace Biblan.Views
{
    /// <summary>
    /// Interaction logic for addBook.xaml
    /// </summary>
    public partial class addBook : Window
    {
        Controller.Controller controller = Controller.Controller.GetInstance();

        public addBook()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string ISBN = txtISBN.Text;
            string title = tbTitel.Text;
            string publisher = tbPublisher.Text;
            string author = tbAuthor.Text;
            string stringpages = tbPages.Text;
            int pages = Convert.ToInt32(stringpages);
            string stringyear = tbYear.Text;
            int year = Convert.ToInt32(stringyear);
            controller.AddBook(ISBN, title, pages, year, publisher, author);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void tbAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
