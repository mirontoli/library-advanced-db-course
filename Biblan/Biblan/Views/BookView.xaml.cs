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
    /// Interaction logic for BindingSpike.xaml
    /// </summary>
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
            lvBinding.ItemsSource = controller.GetAllBooks(); 
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
              CollectionViewSource.GetDefaultView(lvBinding.ItemsSource);

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
                //MessageBox.Show("you pressed Enter");
                // Get the default view from the listview
                ICollectionView view = CollectionViewSource.GetDefaultView(lvBinding.ItemsSource);

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

            // apply the filter
            if (book.Title.ToLower().Contains(textFilter.ToLower())) return true;
            return false;
        }

    }
}
