using NovaPoshta.Infrastructure;
using NovaPoshta.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NovaPoshta.Views.Messages
{
    /// <summary>
    /// Interaction logic for FailedAuthorization.xaml
    /// </summary>
    public partial class FailedAuthorization : UserControl
    {
        public FailedAuthorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new LoginView());
        }
    }
}
