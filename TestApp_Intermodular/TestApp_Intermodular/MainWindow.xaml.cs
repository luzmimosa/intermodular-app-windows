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

namespace TestApp_Intermodular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool simulacro = true;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Simulacro_Click(object sender, RoutedEventArgs e)
        {
            RadioButton inicioButton = this.FindName("Inicio") as RadioButton;
            RadioButton mapButton = this.FindName("Mapa") as RadioButton;
            RadioButton favButton = this.FindName("Favoritos") as RadioButton;
            RadioButton profileButton = this.FindName("Perfil") as RadioButton;
            RadioButton logoutButton = this.FindName("Salir") as RadioButton;
            RadioButton loginButton = this.FindName("login") as RadioButton;

            if (simulacro == true)
            {
                inicioButton.Visibility = Visibility.Visible;
                inicioButton.IsChecked = true;
                loginButton.IsChecked = false;
                mapButton.Visibility = Visibility.Visible;
                favButton.Visibility = Visibility.Visible;
                profileButton.Visibility = Visibility.Visible;
                logoutButton.Visibility = Visibility.Visible;
                loginButton.Visibility = Visibility.Collapsed;

                simulacro = !simulacro;
            }
            else 
            {
                inicioButton.Visibility = Visibility.Collapsed;
                inicioButton.IsChecked = false;
                loginButton.IsChecked = true;
                mapButton.Visibility = Visibility.Collapsed;
                favButton.Visibility = Visibility.Collapsed;
                profileButton.Visibility = Visibility.Collapsed;
                logoutButton.Visibility = Visibility.Collapsed;
                loginButton.Visibility = Visibility.Visible;

                simulacro= !simulacro;
            }
            
        }
        private void isLogged(object sender, RoutedEventArgs e)
        {
          RadioButton inicioButton = this.FindName("Inicio") as RadioButton;
          RadioButton mapButton = this.FindName("Mapa") as RadioButton;
          RadioButton favButton = this.FindName("Favoritos") as RadioButton;
          RadioButton profileButton = this.FindName("Perfil") as RadioButton;
          RadioButton logoutButton = this.FindName("Salir") as RadioButton;

          inicioButton.Visibility = Visibility.Visible;
          mapButton.Visibility = Visibility.Visible;
          favButton.Visibility = Visibility.Visible;
          profileButton.Visibility = Visibility.Visible;
          logoutButton.Visibility = Visibility.Visible;

        }
        private void isNotLogged(object sender, RoutedEventArgs e)
        {
            RadioButton inicioButton = this.FindName("Inicio") as RadioButton;
            RadioButton mapButton = this.FindName("Mapa") as RadioButton;
            RadioButton favButton = this.FindName("Favoritos") as RadioButton;
            RadioButton profileButton = this.FindName("Perfil") as RadioButton;
            RadioButton logoutButton = this.FindName("Salir") as RadioButton;

            inicioButton.Visibility = Visibility.Collapsed;
            mapButton.Visibility = Visibility.Collapsed;
            favButton.Visibility = Visibility.Collapsed;
            profileButton.Visibility = Visibility.Collapsed;
            logoutButton.Visibility = Visibility.Collapsed;

        }
    }
}
