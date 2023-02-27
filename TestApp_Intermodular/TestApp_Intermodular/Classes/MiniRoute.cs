using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TestApp_Intermodular.MVVM.View;

namespace TestApp_Intermodular.Classes
{
    public class MiniRoute
    {
        public event EventHandler OnClick;
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  float Length { get; set; }
        public  bool Fav { get; set; }
        public  string UID { get; set; }
        public string[] comments { get; set; }
        public string difficulty { get; set; }
        public string creator { get; set; }
        public string image { get; set; }


        public async Task<Grid> ShowRoutes() 
        {

            var grid = new Grid
            {
                Height = 150,
                Width = 300,
                Background = new SolidColorBrush(Color.FromArgb(153, 0, 0, 0)), //Brushes.LightGray,
                Margin = new Thickness(5)
            };
            var image = await GetImageAsync(this.image);
            grid.Background = new ImageBrush(image)
            {
                Stretch = Stretch.UniformToFill
            };

            var column1 = new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) };
            var column2 = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);


            var stackPanel1 = new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Bottom,
                Children = {
                    new TextBlock {
                        Text =(dynamic)Name,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.White,
                        FontSize = 24,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        MaxWidth = 250,
                        Margin = new Thickness(5,0,0,0)
                    },
                    new TextBlock {
                        Text =(dynamic)Description,
                        Foreground = Brushes.White,
                        FontSize = 16,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        MaxWidth = 200,
                        Margin = new Thickness(5,0,0,0)
                    }
                }
            };
            Grid.SetColumn(stackPanel1, 0);
            grid.Children.Add(stackPanel1);

            var stackPanel2 = new StackPanel
            {
                Orientation = Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                Children = {
                    new TextBlock {
                        Text =(dynamic)Length.ToString()+"km",
                        Foreground = Brushes.White,
                        FontSize = 16,
                        Margin = new Thickness(0,0,5,0)
                    }
                }
            };
            Grid.SetColumn(stackPanel2, 1);
            grid.Children.Add(stackPanel2);

            grid.MouseLeftButtonDown += new MouseButtonEventHandler(RaiseOnClickAsync);

            return grid;

            async void RaiseOnClickAsync(object sender, MouseEventArgs e)
            {
                var image = await GetImageAsync(this.image);

                DetailedRouteWindow DetailedRoute = new DetailedRouteWindow();
                DetailedRoute.RouteTitleTextBox.Text = this.Name;
                DetailedRoute.uid = this.UID;
                DetailedRoute.RouteDescriptionTextBox.Text = this.Description;
                DetailedRoute.RouteDistanceTextBox.Text = this.Length.ToString()+"Km";
                DetailedRoute.RouteDifficultyTextBox.Text = "Dificultad: "+this.difficulty;
                DetailedRoute.RouteAuthorTextBox.Text = "Autor: " + this.creator;
                DetailedRoute.RouteImage.Source = image;
                if (CurrentUser.username.Equals("goose") || CurrentUser.username.Equals(this.creator))
                {
                    DetailedRoute.DeleteRouteButton.Visibility = Visibility.Visible;
                }
                DetailedRoute.ShowDialog();              
            }
            async Task<BitmapImage> GetImageAsync(string id)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                    var response = await client.GetAsync("https://intermodular.fadedbytes.com/image/"+id);
                    response.EnsureSuccessStatusCode();

                    var imageData = await response.Content.ReadAsByteArrayAsync();

                    using (var stream = new MemoryStream(imageData))
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        return bitmap;
                    }
                }
            }
        }
        
    }
}
