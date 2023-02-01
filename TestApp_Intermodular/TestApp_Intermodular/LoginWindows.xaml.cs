using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
using TestApp_Intermodular.Classes;

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

        private async void LogginButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://intermodular.fadedbytes.com/account/login";


            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = delegate { return true; };
            var client = new HttpClient(handler);

            LoginPost post = new LoginPost()
            {
                username = LoginUserTextBox.Text,
                password = tb_password.Password
            };

            var data = JsonSerializer.Serialize<LoginPost>(post);
            HttpContent content =
                new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                string responseString = await httpResponse.Content.ReadAsStringAsync();

                HttpRequestMessage request = new HttpRequestMessage();
                var headers = request.Headers;
                MessageBox.Show(responseString);

                MessageBox.Show("Contains: "+headers.Contains("Authorization"));

                /*if (headers.TryGetValues("Authorization", out var values))
                {
                    var token = values.FirstOrDefault();
                    MessageBox.Show(token);
                }
                else {
                    MessageBox.Show("Not found");
                }*/

                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();
            }
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

    }

}
