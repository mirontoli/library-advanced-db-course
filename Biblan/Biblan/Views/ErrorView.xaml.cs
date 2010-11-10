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
    /// Interaction logic for ErrorView.xaml
    /// </summary>
    public partial class ErrorView : Window
    {
        public ErrorView()
        {
            InitializeComponent();
        }
        public string ErrorMessage
        {
            get
            {
                return tbError.Text;
            }
            set
            {
                tbError.Text = value;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
