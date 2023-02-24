using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
        public string difficulty { get; set; }
        public string creator { get; set; }
        public long creationDatetime { get; set; }
        public int creationDay { get { return new DateTime(creationDatetime).Day; } }
        public int creationMonth { get { return new DateTime(creationDatetime).Month; } }
        public int creationYear { get { return new DateTime(creationDatetime).Year; } }


        public Grid ShowRoutes() 
        {

            var grid = new Grid
            {
                Height = 150,
                Width = 300,
                Background = Brushes.DarkGray,
                Margin = new Thickness(5)
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

            grid.MouseLeftButtonDown += new MouseButtonEventHandler(RaiseOnClick);

            return grid;

            void RaiseOnClick(object sender, MouseEventArgs e)
            {
                DetailedRouteWindow DetailedRoute = new DetailedRouteWindow();
                DetailedRoute.RouteTitleTextBox.Text = this.Name;
                DetailedRoute.RouteDescriptionTextBox.Text = this.Description;
                DetailedRoute.RouteDistanceTextBox.Text = this.Length.ToString()+"Km";
                DetailedRoute.RouteDifficultyTextBox.Text = "Dificultad: "+this.difficulty;
                DetailedRoute.RouteAuthorTextBox.Text = "Autor: " + this.creator;
                DetailedRoute.RouteCreationDateTextBox.Text = "Fecha: " + this.creationDay + "/" + this.creationMonth + "/" + this.creationYear;
                DetailedRoute.ShowDialog();              

            }
        }
        
    }
}
