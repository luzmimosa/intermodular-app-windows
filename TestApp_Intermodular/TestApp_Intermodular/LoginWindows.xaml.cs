using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
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
using Newtonsoft.Json;

namespace TestApp_Intermodular
{
    //Metodo para alojar el token y comprobar y actualizar que el token es el válido.
    public static class GlobalToken
    {
        public static string Token;

        public static void CheckToken(String CurrentToken) 
        {
            if (!CurrentToken.Equals(Token)) 
            { 
                Token = CurrentToken;
            }
        }
    }
    public static class AlphanumericChecker 
    {
        public static bool IsAlphanumeric(string text)
        {
            Regex alphanumericRegex = new Regex("^[a-zA-Z0-9]+$");
            return alphanumericRegex.IsMatch(text);
        }
    }

    public class FileCreator
    {
        public void CreateTextFile(string fileName, string content)
        {
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName + ".txt");
            File.WriteAllText(path, content);
        }
    }
    public class FileReader
    {
        public static string fileContent;

        public static void ReadTextFile(string fileName)
        {
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName + ".txt");
            fileContent = File.ReadAllText(path);
        }
    }       //Para leer el token usar --> FileReader.ReadTextFile("TOKEN");
                                    //y luego asignar a variable --> string contents = FileReader.fileContent;

    public partial class LoginWindows : Window
    {
        public static string userName { get; set; }
        public static string userPassword { get; set; }
        public LoginWindows()
        {
            InitializeComponent();
            
        }
        private double ConvertToKm(int meters)
        {
            double kilometers = meters / 1000.0;
            return Math.Round(kilometers, 1);
        }
        private async void test() 
        {
            using (var client = new HttpClient())
            {
                string url = "https://intermodular.fadedbytes.com/api/v1/route/fdbc284c99cbfb59b5e66531689f362b76cf8db325271b7cd183e0a9c2c0c135";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer "+GlobalToken.Token);
                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseContent);

                var json = JsonConvert.DeserializeObject<dynamic>(responseContent);
                MiniRoute.Name = json.name;
                MiniRoute.Description = json.description;
                int km = json.length;
                double length = ConvertToKm(km);
                MiniRoute.Length=length;
                MessageBox.Show(MiniRoute.Name+"\n"+MiniRoute.Description+"\n"+MiniRoute.Length);
                
            }
        }
        


        private async void LogginButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = LoginUserTextBox.Text;
            if (AlphanumericChecker.IsAlphanumeric(inputText))
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

                var data = System.Text.Json.JsonSerializer.Serialize<LoginPost>(post);
                HttpContent content =
                    new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync(url, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string responseString = await httpResponse.Content.ReadAsStringAsync();
                    HttpRequestMessage request = new HttpRequestMessage();

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var headers = httpResponse.Headers;
                        string token = null;


                        foreach (var foundToken in headers.GetValues("Authorization"))
                        {
                            token = foundToken;
                        }

                        if (token == null)
                        {
                            MessageBox.Show("Token not found.");
                        }
                        else
                        {
                            GlobalToken.Token = token;
                            FileCreator fileCreator = new FileCreator();
                            fileCreator.CreateTextFile("TOKEN", token);
                            userName = LoginUserTextBox.Text;
                            userPassword = tb_password.Password;
                            test();

                        }
                    }

                    MainWindow mw = new MainWindow();
                    this.Close();
                    mw.Show();
                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario no puede tener símbolos ni espacios. Por favor, vuelve a intentarlo.");
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
