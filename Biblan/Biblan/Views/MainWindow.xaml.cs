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
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnSpike_Click(object sender, RoutedEventArgs e)
        {
            BookView bs = new BookView();
            bs.Show();
        }

        private void btnSmallExtras_Click(object sender, RoutedEventArgs e)
        {
            Controller.Controller.GetInstance().ShowSmallExtrasWindow();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Controller.Controller.GetInstance().ShowCustomerViewWindow();
        }

        private void btnBorrowings_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            MessageBox.Show("Functionality will be added shortly");
        }
    } 
}
