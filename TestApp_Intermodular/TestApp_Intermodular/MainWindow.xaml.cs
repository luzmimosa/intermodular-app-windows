using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
using TestApp_Intermodular.Classes;

namespace TestApp_Intermodular
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
         public MainWindow()
        {
            InitializeComponent();
            welcome.Text = "Bienvenido, "+CurrentUser.username+".";

            if (CurrentUser.username.Equals("goose")) 
            { Administrador.Visibility = Visibility.Visible; }
            
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void logout(object sender, RoutedEventArgs e)
        {
            LoginWindows lg= new LoginWindows();
            this.Close();
            lg.Show();
        }
    }
}
