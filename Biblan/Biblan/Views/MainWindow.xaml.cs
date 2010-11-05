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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    } 
}
