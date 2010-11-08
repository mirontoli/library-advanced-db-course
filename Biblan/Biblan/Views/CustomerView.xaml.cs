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

        private void TestBind()
        {
            lvCustomer.ItemsSource = controller.GetAllCustomers();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowChangeCustomerWindow();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowDeleteCustomerWindow();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            controller.ShowAddCustomerWindow();
        }
    }
}
