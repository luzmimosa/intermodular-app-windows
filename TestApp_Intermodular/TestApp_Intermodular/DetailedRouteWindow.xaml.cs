using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using Newtonsoft.Json;
using TestApp_Intermodular.Classes;

namespace TestApp_Intermodular
{
    public partial class DetailedRouteWindow : Window
    {
        public String uid { get; set; }
        public DetailedRouteWindow()
        {
            InitializeComponent();
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //private void PrevButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (currentImageIndex > 0)
        //    {
        //        currentImageIndex--;
        //        LoadImage();
        //    }
        //}

        private void ImageDeleteBtn_Click(object sender, RoutedEventArgs e) { }
        private void DeleteRoute_Click(object sender, RoutedEventArgs e) 
        {
            DeleteRoute(this.uid);
        }

        //private void NextButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (currentImageIndex < imagePaths.Count - 1)
        //    {
        //        currentImageIndex++;
        //        LoadImage();
        //    }
        //}

        private async void ImageUploadBtn_Click(object sender, RoutedEventArgs e)
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
                            MessageBox.Show(await response.Content.ReadAsStringAsync());
                        }
                        else
                        {
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Ocurrió un error durante la carga.");
                            MessageBox.Show(response.StatusCode  + " - " + await response.Content.ReadAsStringAsync());
                        }
                    }                   
                }
            }
        }
        private async void DeleteRoute(String i)
        {
            string url = "https://intermodular.fadedbytes.com/api/v1/route/" + i;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode) { MessageBox.Show("Ruta eliminada con éxito."); }
                else { MessageBox.Show("Ha ocurrido algún error, por favor, ponte en contacto con soporte."); }
            }
        }
    }
}
