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
    /// Lógica de interacción para LoginWindows.xaml
    /// </summary>
    public partial class LoginWindows : Window
    {
        public LoginWindows()
        {
            InitializeComponent();
        }

        private void LogginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        private void Register(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            this.Close();
            rw.Show();
        }

        private void PasswordRecovery(object sender, MouseButtonEventArgs e)
        {
            RecoverWindow rw = new RecoverWindow();
            this.Close();
            rw.Show();
        }
        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            if (Regex.IsMatch(LoginEmailTextBox.Text, emailPattern))
            {
                LoginErrorTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                LoginErrorTextBlock.Visibility = Visibility.Visible;
            }
        }

    }

}
