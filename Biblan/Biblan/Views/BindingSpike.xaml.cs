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
using System.Collections.ObjectModel;

namespace Biblan.Views
{
    /// <summary>
    /// Interaction logic for BindingSpike.xaml
    /// </summary>
    public partial class BindingSpike : Window
    {
        public BindingSpike()
        {
            InitializeComponent();
            TestBind();
        }

        private void TestBind()
        {
            bibliotekDataContext dataContext = new bibliotekDataContext();
            var query = from c in dataContext.search_books_titles("")
                        select new Book { Title = c.Title, NumberOfPages = (int)c.NumberOfPages, Publisher = c.Publisher, ISBN = c.ISBN };

            List<Book> books = query.ToList();

            lwBinding.ItemsSource = books; 
        }
    }
}
