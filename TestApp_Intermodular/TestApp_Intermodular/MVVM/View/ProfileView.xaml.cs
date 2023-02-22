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
using Microsoft.Win32;


namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private bool _enabled = false;
        public ProfileView()
        {
            InitializeComponent();
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
            BiographyTextBox.Text = BiographyTextBox.Text;
            
        }

        private void ModifyProfile_Click(object sender, RoutedEventArgs e) 
        {
            _enabled = !_enabled;
            if (_enabled == true)
            {
                SaveButton.Visibility= Visibility.Visible;
                BiographyTextBox.Visibility = Visibility.Visible;

                UsernameNameTextBlock.Visibility = Visibility.Visible;
                UsernameNameTextBox.Visibility = Visibility.Visible;

                UsernameTextBlock.Visibility = Visibility.Visible;
                UsernameTextBox.Visibility = Visibility.Visible;

                PasswordTextBlock.Visibility = Visibility.Visible;
                PasswordTextBox.Visibility = Visibility.Visible;

                NewPasswordTextBlock.Visibility = Visibility.Visible;
                NewPasswordTextBox.Visibility = Visibility.Visible;

                EmailTextBlock.Visibility = Visibility.Visible;
                EmailTextBox.Visibility = Visibility.Visible;

                NewEmailTextBlock.Visibility = Visibility.Visible;
                NewEmailTextBox.Visibility = Visibility.Visible;
            }
            else 
            {
                SaveButton.Visibility = Visibility.Collapsed;
                BiographyTextBox.Visibility=Visibility.Collapsed;

                UsernameNameTextBlock.Visibility = Visibility.Collapsed;
                UsernameNameTextBox.Visibility = Visibility.Collapsed;

                UsernameTextBlock.Visibility = Visibility.Collapsed;
                UsernameTextBox.Visibility = Visibility.Collapsed;

                PasswordTextBlock.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Collapsed;

                NewPasswordTextBlock.Visibility = Visibility.Collapsed;
                NewPasswordTextBox.Visibility = Visibility.Collapsed;

                EmailTextBlock.Visibility = Visibility.Collapsed;
                EmailTextBox.Visibility = Visibility.Collapsed;

                NewEmailTextBlock.Visibility = Visibility.Collapsed;
                NewEmailTextBox.Visibility = Visibility.Collapsed;

            }
        }
    }
}
