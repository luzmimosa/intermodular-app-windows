using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestApp_Intermodular
{
    /// <summary>
    /// Lógica de interacción para RecoverWindow.xaml
    /// </summary>
    public partial class RecoverWindow : Window
    {
        public RecoverWindow()
        {
            InitializeComponent();
        }

        private void Recover_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RecoveryBack(object sender, RoutedEventArgs e)
        {
            LoginWindows lg = new LoginWindows();
            this.Close();
            lg.Show();
        }
        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            if (Regex.IsMatch(RecoverEmailTextBox.Text, emailPattern))
            {
                errorTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                errorTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
