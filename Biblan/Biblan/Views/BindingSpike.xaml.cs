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
    public partial class BindingSpike : Window
    {
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        private Controller.Controller controller = Controller.Controller.GetInstance();
        public BindingSpike()
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
    }
}
