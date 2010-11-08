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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        private Controller.Controller controller = Controller.Controller.GetInstance();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            string address = txtBoxAddress.Text;
            string phone = txtBoxPhone.Text;
            controller.AddCustomer(name, address, phone);
            this.Close();
        }
    }
}
