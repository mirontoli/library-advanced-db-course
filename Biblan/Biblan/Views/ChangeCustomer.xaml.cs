﻿using System;
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
    /// Interaction logic for ChangeCustomer.xaml
    /// </summary>
    public partial class ChangeCustomer : Window
    {
        private Controller.Controller controller = Controller.Controller.GetInstance();
        private Model.Customer customer;
        public Model.Customer CustomerToChange
        {
            get { return customer; }
            set 
            { 
                customer = value;
                txtBoxCustomerID.Text = customer.CustomerID.ToString();
                txtBoxName.Text = customer.Name;
                txtBoxAddress.Text = customer.Address;
                txtBoxPhone.Text = customer.Phone;
            }
        }

        public ChangeCustomer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string CustID = txtBoxCustomerID.Text;
            int CID = Convert.ToInt32(CustID);
            string name = txtBoxName.Text;
            string address = txtBoxAddress.Text;
            string phone = txtBoxPhone.Text;
            controller.ChangeCustomer(CID, name, address, phone);
            this.Close();
            
        }

        private void txtBoxCustomerID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
