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
using Biblan.Model;

namespace Biblan.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller.Controller controller = Controller.Controller.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowBookView();
        }

        private void btnSmallExtras_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowSmallExtrasWindow();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowCustomerViewWindow();
        }

        private void btnBorrowings_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowBorrowingsWindow();
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("In order to borrow, open Books View.\r\nWant to open it now?", "Borrow? Go to Books View", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                controller.ShowBookView();
            }
        }
    } 
}
