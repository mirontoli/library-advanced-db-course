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
    /// Interaction logic for BorrowingView.xaml
    /// </summary>
    public partial class BorrowingView : Window
    {
        Controller.Controller controller = Controller.Controller.GetInstance();

        public BorrowingView()
        {
            InitializeComponent();
            TestBorrowings();
        }

        private void TestBorrowings()
        {
            lvBorrowing.ItemsSource = controller.GetAllBorrowings();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Model.Borrowing bor = lvBorrowing.SelectedItem as Model.Borrowing;
            controller.ReturnBook(bor);
            btnReturn.IsEnabled = false;
        }

        private void lvBorrowing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnReturn.IsEnabled = true;
        }
    }
}
