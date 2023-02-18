using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestApp_Intermodular.Classes;

namespace TestApp_Intermodular
{
    /// <summary>
    /// Lógica de interacción para RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            string inputText = tb_usuario.Text;
            if (AlphanumericChecker.IsAlphanumeric(inputText))
            {
                string url = "https://intermodular.fadedbytes.com/account/register";


                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = delegate { return true; };
                var client = new HttpClient(handler);

                Post post = new Post()
                {
                    username = tb_usuario.Text,
                    displayName = tb_displayName.Text,
                    biography = "Empty",
                    email = RegisterEmailTextBox.Text,
                    password = tb_password.Password
                };

                var data = JsonSerializer.Serialize<Post>(post);
                HttpContent content =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync(url, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario no puede tener símbolos ni espacios. Por favor, introduce un nuevo nombre.");
            }
        }
        private void BackToLogin(object sender, RoutedEventArgs e)
        {
            LoginWindows lg = new LoginWindows();
            this.Close();
            lg.Show();
        }
        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            if (Regex.IsMatch(RegisterEmailTextBox.Text, emailPattern))
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
