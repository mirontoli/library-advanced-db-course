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
        public CustomerView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Controller.Controller.GetInstance().ShowChangeCustomerWindow();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Controller.Controller.GetInstance().ShowDeleteCustomerWindow();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Controller.Controller.GetInstance().ShowAddCustomerWindow();
        }
/*
        public void addDetails(CustomerView details)
        {
            CustomerView.put(details.getCustomerID(), details);
            CustomerView.put(details.getName(), details);
            CustomerView.put(details.getAdress(), details);
            CustomerView.put(details.getPhone(), details);
            //numberOfEntries++;
        }
        */
    }
}
