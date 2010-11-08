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
    /// Interaction logic for BorrowFromBookView.xaml
    /// </summary>
    public partial class BorrowFromBookView : Window
    {
        public Model.Book BookToBorrow
        {
            get;
            set;
        }
        public BorrowFromBookView()
        {
            InitializeComponent();
            lblBook.Content = BookToBorrow.Title;
        }
    }
}
