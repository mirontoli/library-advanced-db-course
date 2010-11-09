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
using Biblan.Model;
using Biblan.Controller;
using System.ComponentModel;

namespace Biblan.Views
{
    /// <summary>
    /// Interaction logic for ChangeBook.xaml
    /// </summary>
    public partial class ChangeBook : Window
    {
        private Controller.Controller controller = Controller.Controller.GetInstance();
        private Model.Book book;
        public Model.Book BookToChange
        {
            get { return book; }
            set
            {
                book = value;
                txtBoxBookISBN.Text = book.ISBN.ToString();
                txtBoxTitle.Text = book.Title;
                txtBoxPublisher.Text = book.Publisher;
                txtBoxAuthor.Text = book.Author;
                txtBoxNrOfPages.Text = book.NumberOfPages.ToString();
                txtBoxYearPrinted.Text = book.PrintYear.ToString();
            }
        }
                public ChangeBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            string ISBN = txtBoxBookISBN.Text;
            string title = txtBoxTitle.Text;
            string publisher = txtBoxPublisher.Text;
            string author = txtBoxAuthor.Text;
            string numberofpages = txtBoxNrOfPages.Text;
            int nrpages = Convert.ToInt32(numberofpages);
            string printyear = txtBoxYearPrinted.Text;
            int pyear = Convert.ToInt32(printyear);
            controller.ChangeBook(ISBN, title, nrpages, pyear, publisher, author);
            this.Close();
        }
    }
}
