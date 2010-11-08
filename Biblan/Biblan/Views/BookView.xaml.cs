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
    public partial class BookView : Window
    {
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        private Controller.Controller controller = Controller.Controller.GetInstance();
        public BookView()
        {
            InitializeComponent();
            TestBind();
        }

        private void TestBind()
        {
            lvBooks.ItemsSource = controller.GetAllBooks(); 
        }
        // inspired by:
        // http://msdn.microsoft.com/en-us/library/ms745786.aspx
        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;
            if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
            {
                if (headerClicked != _lastHeaderClicked)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    if (_lastDirection == ListSortDirection.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                }

                string header = headerClicked.Column.Header as string;
                Sort(header, direction);


                _lastHeaderClicked = headerClicked;
                _lastDirection = direction;
            }

        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(lvBooks.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void tbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            // http://svetoslavsavov.blogspot.com/2009/09/sorting-and-filtering-databound.html
            if (e.Key == Key.Enter)
            {
                // Get the default view from the listview
                ICollectionView view = CollectionViewSource.GetDefaultView(lvBooks.ItemsSource);

                view.Filter = null;
                view.Filter = new Predicate<object>(FilterBooks);
            }
        }
        private bool FilterBooks(object obj)
        {
            Book book = obj as Book;
            if (book == null) return false;

            string textFilter = tbFilter.Text;

            if (textFilter.Trim().Length == 0) return true; // the filter is empty - pass all items

            string text = textFilter.ToLower();
            // apply the filter
            if (book.Title.ToLower().Contains(text)
                || book.ISBN.ToLower().Contains(text)
                || book.Publisher.ToLower().Contains(text)
                || book.Author.ToLower().Contains(text)) return true;
            return false;
        }

        private void lvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = GetSelectedBook();
            if (book != null)
            {
                string isbn = book.ISBN;
                cbCopies.IsEnabled = true;
                btnAddCopy.IsEnabled = true;
                cbCopies.ItemsSource = null;
                cbCopies.ItemsSource = controller.GetAvailableCopies(book);
            }
        }

        private void btnAddCopy_Click(object sender, RoutedEventArgs e)
        {
            Book book = GetSelectedBook();
            if (book != null) 
            {
                controller.AddBookCopy(book);
                btnAddCopy.IsEnabled = false;
            }
        }
        private Book GetSelectedBook()
        {
            if (lvBooks.SelectedItem == null)
            {
                cbCopies.IsEnabled = false;
                btnAddCopy.IsEnabled = false;
                return null;
            }
            Book book = lvBooks.SelectedItem as Book;
            return book;
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
              controller.ShowAddBookWindow();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbCopies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBorrow.IsEnabled = true;
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            Book book = GetSelectedBook();
            BookCopy bc = cbCopies.SelectedItem as BookCopy;
            bc.Book = book;
            lvBooks.SelectedItem = null;
            cbCopies.ItemsSource = null;
            btnAddCopy.IsEnabled = false;
            btnBorrow.IsEnabled = false;
            controller.ShowBorrowFromBookView(bc);
        }

    }
}
