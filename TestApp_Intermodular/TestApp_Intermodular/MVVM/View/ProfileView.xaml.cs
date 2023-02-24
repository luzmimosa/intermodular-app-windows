using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Microsoft.Win32;
using Newtonsoft.Json;
using TestApp_Intermodular.Classes;

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        static String usuario, nombre, biografia;
        private bool _enabled = false;
        public ProfileView()
        {
            InitializeComponent();
            AssignUserValues();
        }
        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(filePath));
                Image.Source = imageSource;
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            BioDescriptionTextBlock.Text = BiographyTextBox.Text;
            NameTextBlock.Text = NameTextBox.Text;
            UserTextBlock.Text = UserTextBox.Text;

            _enabled = !_enabled;

            SaveButton.Visibility = Visibility.Collapsed;
            BiographyTextBox.Visibility = Visibility.Collapsed;
            BioDescriptionTextBlock.Visibility = Visibility.Visible;

            NameTextBlock.Visibility = Visibility.Visible;
            NameTextBox.Visibility = Visibility.Collapsed;

            UserTextBlock.Visibility = Visibility.Visible;
            UserTextBox.Visibility = Visibility.Collapsed;

            usuario = UserTextBlock.Text;
            nombre= NameTextBox.Text;
            biografia = BioDescriptionTextBlock.Text;
            ModifyUserAsync();

        }

        public static async Task<string> ModifyUserAsync()
        {
            using (var client = new HttpClient())
            {
                var data = new
                {
                    username = usuario,
                    displayName = nombre,
                    biography = biografia
                };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var response = await client.PostAsync("https://intermodular.fadedbytes.com/account/modify", content);

                MessageBox.Show(response.ToString());
                return await response.Content.ReadAsStringAsync();
            }
        }

        private void ModifyProfile_Click(object sender, RoutedEventArgs e) 
        {
            _enabled = !_enabled;
            if (_enabled == true)
            {
                SaveButton.Visibility= Visibility.Visible;
                BiographyTextBox.Visibility = Visibility.Visible;
                BioDescriptionTextBlock.Visibility = Visibility.Collapsed;

                NameTextBlock.Visibility = Visibility.Collapsed;
                NameTextBox.Visibility = Visibility.Visible;

                UserTextBlock.Visibility = Visibility.Collapsed;
                UserTextBox.Visibility = Visibility.Visible;
            }
            else 
            {
                SaveButton.Visibility = Visibility.Collapsed;
                BiographyTextBox.Visibility=Visibility.Collapsed;
                BioDescriptionTextBlock.Visibility = Visibility.Visible;

                NameTextBlock.Visibility = Visibility.Visible;
                NameTextBox.Visibility = Visibility.Collapsed;

                UserTextBlock.Visibility = Visibility.Visible;
                UserTextBox.Visibility = Visibility.Collapsed;
            }
        }

        //Metodo para recuperar información del usuario
        public static async Task<User> GetCurrentUserAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
            var response = await httpClient.GetAsync("https://intermodular.fadedbytes.com/api/v1/user/" + CurrentUser.username);

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }

        public async void AssignUserValues()
        {
            var currentUser = await GetCurrentUserAsync();

            NameTextBlock.Text = currentUser.displayName;
            NameTextBox.Text = currentUser.displayName;
            UserTextBlock.Text = currentUser.username;
            UserTextBox.Text = currentUser.username;
            BioDescriptionTextBlock.Text = currentUser.biography;
            BiographyTextBox.Text = currentUser.biography;
        }
    }
}
