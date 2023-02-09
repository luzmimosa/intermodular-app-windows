using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TestApp_Intermodular.Classes
{
    class MiniRoute
    {
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public int Number { get; private set; }

        public static void ShowRoutes() 
        {
            //Grid agrid = new Grid
            //{
            //    Height = 300,
            //    Width = 300
            //};
            //agrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            var dataContext = new MiniRoute
            {
                Title = "My Title",
                Subtitle = "My Subtitle",
                Number = 42
            };

            var grid = new Grid
            {
                Height = 300,
                Width = 300,
                DataContext = dataContext,
                Background = Brushes.DarkGray
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
                        Width = 250
                    },
                    new TextBlock {
                        Text =((dynamic)dataContext).Subtitle,
                        Foreground = Brushes.White,
                        FontSize = 16,
                        TextTrimming = TextTrimming.CharacterEllipsis,
                        Width = 200
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
                        FontSize = 16
                    }
                }
            };
            Grid.SetColumn(stackPanel2, 1);
            grid.Children.Add(stackPanel2);

        }
    }   
}
