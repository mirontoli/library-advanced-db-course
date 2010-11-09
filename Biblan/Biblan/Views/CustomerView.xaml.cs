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
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        private Controller.Controller controller = Controller.Controller.GetInstance();

        public CustomerView()
        {
            InitializeComponent();
            TestBind();
        }

        public void TestBind()
        {
            lvCustomer.ItemsSource = controller.GetAllCustomers();
            lvCustomer.Items.Refresh();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            controller.CustomerView = this;
            Model.Customer customer = GetSelectedCustomer();
            controller.ShowChangeCustomerWindow(customer);
            btnChange.IsEnabled = false;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            controller.CustomerView = this;
            Model.Customer customer = GetSelectedCustomer();
            controller.DeleteCustomer(customer.CustomerID);
            btnDelete.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            controller.CustomerView = this;
            controller.ShowAddCustomerWindow();
        }
        private Customer GetSelectedCustomer()
        {
            Customer customer = lvCustomer.SelectedItem as Customer;
            return customer;
        }

        private void lvCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnChange.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
    }
}
