using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TestApp_Intermodular
{
    /// <summary>
    /// Lógica de interacción para DetailedRouteWindow.xaml
    /// </summary>
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

        private void ImageUploadBtn_Click(object sender, RoutedEventArgs e, string filePath) 
        {
            ImageSource imageSource = new BitmapImage(new Uri(filePath));
            RouteImage.Source = imageSource;
            imagePaths.Add(filePath);
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

        private void ImageUploadBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
