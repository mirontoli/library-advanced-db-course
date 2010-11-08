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
        private Controller.Controller controller = Controller.Controller.GetInstance();
        public Model.BookCopy BookCopyToBorrow
        {
            get;
            set;
        }
        public BorrowFromBookView()
        {
            InitializeComponent();
            lvCustomer.ItemsSource = controller.GetAllCustomers();
        }

        public void SetTitle()
        {
            lblBook.Content = BookCopyToBorrow.Book.Title;
        }

        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBorrow.IsEnabled = true;
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            Model.Customer customer = GetSelectedCustomer();
            controller.Borrow(BookCopyToBorrow, customer);
            btnBorrow.IsEnabled = false;
            this.Close();
        }

        private Model.Customer GetSelectedCustomer()
        {
            Model.Customer customer = lvCustomer.SelectedItem as Model.Customer;
            return customer;
        }
    }
}
