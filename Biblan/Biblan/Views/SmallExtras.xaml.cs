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
    /// Interaction logic for SmallExtras.xaml
    /// </summary>
    public partial class SmallExtras : Window
    {
        Controller.Controller controller = Controller.Controller.GetInstance();

        public SmallExtras()
        {
            InitializeComponent();
            TestSmallExtras();
        }

        private void TestSmallExtras()
        {
            lvSmallExtrasBooks.ItemsSource = controller.GetAllBooks();
        }

        private void btnMoreThanOneBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBooksWithMoreThan500Pages_Click(object sender, RoutedEventArgs e)
        {
            lvSmallExtrasBooks.ItemsSource = controller.GetAllBooksWithMoreThan500Pages();
        }

        private void btnBooksBeginningWithA_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBooksOlderThan15Years_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
