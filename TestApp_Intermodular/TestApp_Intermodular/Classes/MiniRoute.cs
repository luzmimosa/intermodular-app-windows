using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TestApp_Intermodular.MVVM.View;

namespace TestApp_Intermodular.Classes
{
    public class MiniRoute
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Number { get; set; }
        public bool? Fav { get; set; }

        public static Grid ShowRoutes() 
        {

            var dataContext = new MiniRoute
            {
                Title = "Titulo de la ruta",
                Subtitle = "Descripción breve de la ruta",
                Number = "kilómetros",
                Fav = false
            };

            var grid = new Grid
            {
                Height = 150,
                Width = 300,
                DataContext = dataContext,
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
                        Text =((dynamic)dataContext).Title,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.White,
                        FontSize = 24,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        Width = 250,
                        Margin = new Thickness(5,0,0,0)
                    },
                    new TextBlock {
                        Text =((dynamic)dataContext).Subtitle,
                        Foreground = Brushes.White,
                        FontSize = 16,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        Width = 200,
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
                        Text =((dynamic)dataContext).Number,
                        Foreground = Brushes.White,
                        FontSize = 16,
                        Margin = new Thickness(0,0,5,0)
                    }
                }
            };
            Grid.SetColumn(stackPanel2, 1);
            grid.Children.Add(stackPanel2);
            return grid;
        }
    }   
}
