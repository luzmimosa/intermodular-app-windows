using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TestApp_Intermodular.Classes;

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public string UserImage { get; set; }
        static String nombre, biografia;
        private bool _enabled = false;
        public class ImageResponse
        {
            public string id { get; set; }
        }
        public ProfileView()
        {

            InitializeComponent();          
            AssignUserValues();

            nombre = NameTextBox.Text;
            biografia = BiographyTextBox.Text;
        }
        async void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent("image"))
                {
                    var openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        var imageContent = new ByteArrayContent(File.ReadAllBytes(openFileDialog.FileName));
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                        content.Add(imageContent, "image", "image.jpeg");

                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                        var response = await httpClient.PostAsync("https://intermodular.fadedbytes.com/image", content);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Imagen subida correctamente.");

                            //Actualiza la iamgen en el peerfil de usuario en la API
                            var imageResponse = JsonConvert.DeserializeObject<ImageResponse>(await response.Content.ReadAsStringAsync());
                            string imageId = imageResponse.id;
                            ModifyUserProfilePicAsync(imageId);

                            //Recupera la nueva imagen y actualiza
                            var NewImg = await GetCurrentUserAsync();
                            var image = await GetImageAsync(NewImg.profilePicture);
                            Image.Source = image;
                        }
                        else
                        {
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Ocurrió un error durante la carga.");
                            MessageBox.Show(response.StatusCode + " - " + await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
        }
        async Task<BitmapImage> GetImageAsync(string id)
        {
            var bitmap = new BitmapImage();
            using (var client = new HttpClient())
            {
              client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
              var response = await client.GetAsync("https://intermodular.fadedbytes.com/image/"+id);
              response.EnsureSuccessStatusCode();

              var imageData = await response.Content.ReadAsByteArrayAsync();

              using (var stream = new MemoryStream(imageData))
               {
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();
                return bitmap;
              }                
            }
        }
        void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            BioDescriptionTextBlock.Text = BiographyTextBox.Text;
            NameTextBlock.Text = NameTextBox.Text;

            _enabled = !_enabled;

            SaveButton.Visibility = Visibility.Collapsed;
            BiographyTextBox.Visibility = Visibility.Collapsed;
            BioDescriptionTextBlock.Visibility = Visibility.Visible;

            NameTextBlock.Visibility = Visibility.Visible;
            NameTextBox.Visibility = Visibility.Collapsed;

            UserTextBlock.Visibility = Visibility.Visible;

            nombre= NameTextBox.Text;
            biografia = BioDescriptionTextBlock.Text;
            ModifyUserAsync();

        }

        static async Task<string> ModifyUserAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var data = new
                {
                    displayName = nombre,
                    biography = biografia
                };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                
                var response = await client.PostAsync("https://intermodular.fadedbytes.com/account/modify", content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        static async Task<string> ModifyUserProfilePicAsync(string img)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var data = new
                {
                    profilePicture = img
                };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");


                var response = await client.PostAsync("https://intermodular.fadedbytes.com/account/modify", content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        void ModifyProfile_Click(object sender, RoutedEventArgs e) 
        {
            _enabled = !_enabled;
            if (_enabled == true)
            {
                SaveButton.Visibility= Visibility.Visible;
                BiographyTextBox.Visibility = Visibility.Visible;
                BioDescriptionTextBlock.Visibility = Visibility.Collapsed;

                NameTextBlock.Visibility = Visibility.Collapsed;
                NameTextBox.Visibility = Visibility.Visible;
            }
            else 
            {
                SaveButton.Visibility = Visibility.Collapsed;
                BiographyTextBox.Visibility=Visibility.Collapsed;
                BioDescriptionTextBlock.Visibility = Visibility.Visible;

                NameTextBlock.Visibility = Visibility.Visible;
                NameTextBox.Visibility = Visibility.Collapsed;
            }
        }

        //Metodo para recuperar información del usuario
        static async Task<User> GetCurrentUserAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);

            var response = await httpClient.GetAsync("https://intermodular.fadedbytes.com/api/v1/user/" + CurrentUser.username);
            var json = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(json);

            return user;
        }

        async void AssignUserValues()
        {         
            var currentUser = await GetCurrentUserAsync();
            var image = await GetImageAsync(currentUser.profilePicture);

            NameTextBlock.Text = currentUser.displayName;
            NameTextBox.Text = currentUser.displayName;
            UserTextBlock.Text = currentUser.username;
            BioDescriptionTextBlock.Text = currentUser.biography;
            BiographyTextBox.Text = currentUser.biography;  
            Image.Source= image;
        }
    }
}
