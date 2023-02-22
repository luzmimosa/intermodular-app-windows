using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    /// <summary>
    /// Lógica de interacción para DetailedRouteWindow.xaml
    /// </summary>
    public class RandomRoute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
    }
    public partial class DetailedRouteWindow : Window
    {
        private List<string> imagePaths = new List<string>()
        {
            "path/to/image1.jpg",
            "path/to/image2.jpg",
            "path/to/image3.jpg",
            // add more image paths here
        };

        private int currentImageIndex = 0;

        public DetailedRouteWindow()
        {
            InitializeComponent();
            LoadImage();
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        private void LoadImage()
        {
            string imagePath = imagePaths[currentImageIndex];
            //RouteImage.Source = new BitmapImage(new Uri(imagePath));
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                LoadImage();
            }
        }

        private void ImageDeleteBtn_Click(object sender, RoutedEventArgs e) { }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                LoadImage();
            }
        }

        private async void ImageUploadBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                var selectedFile = openFileDialog.FileName;
                var fileStream = new FileStream(selectedFile, FileMode.Open, FileAccess.Read);
                var content = new StreamContent(fileStream);

                var httpClient = new HttpClient();

                MessageBox.Show(content.ToString());

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var response = await httpClient.PostAsync("https://intermodular.fadedbytes.com/image", content);
                MessageBox.Show(response.ToString());

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Imagen subida.");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la carga de la imagen.");
                }
            }
        }

        private void DisplayComments(int number)
        {
            int cont = 0;
            for (int i = 0; i < number; i++)
            {
                Grid grid = Commentary.CommentGrid();
                if (cont % 2 == 0)
                {
                    ColumnA.Children.Add(grid);
                    cont++;
                }
                else
                {
                    ColumnB.Children.Add(grid);
                    cont++;
                }
            }
        }
    }
}
