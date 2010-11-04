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

namespace Biblan.Views
{
    /// <summary>
    /// Interaction logic for BindingSpike.xaml
    /// </summary>
    public partial class BindingSpike : Window
    {
        private Controller.Controller controller = Controller.Controller.GetInstance();
        public BindingSpike()
        {
            InitializeComponent();
            TestBind();
        }

        private void TestBind()
        {
            lvBinding.ItemsSource = controller.GetAllBooks(); 
        }
    }
}
