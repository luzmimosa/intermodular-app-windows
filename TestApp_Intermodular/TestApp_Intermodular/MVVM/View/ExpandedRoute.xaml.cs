using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para ExpandedRoute.xaml
    /// </summary>
    public partial class ExpandedRoute : UserControl
    {
        private List<string> imagePaths = new List<string>()
        {
            "path/to/image1.jpg",
            "path/to/image2.jpg",
            "path/to/image3.jpg",
            // add more image paths here
        };

        private int currentImageIndex = 0;

        public ExpandedRoute()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            string imagePath = imagePaths[currentImageIndex];
            RouteImage.Source = new BitmapImage(new Uri(imagePath));
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                LoadImage();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                LoadImage();
            }
        }
    }
}
