using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestApp_Intermodular.Classes
{
    public class Commentary
    {
        private static string _content;
        //private static DateTime _date;
        private static string _user;
        private static bool _isAdmin;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        //public DateTime Date
        //{
        //    get { return _date; }
        //    set { _date = value; }
        //}

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public bool CanEdit(string currentUser)
        {
            return _isAdmin || _user == currentUser;
        }

        public static Grid CommentGrid()
        {
            Grid grid = new Grid();

            StackPanel stackPanel = new StackPanel();
            TextBlock userTextBlock = new TextBlock();
            userTextBlock.Text = _user;
            TextBlock contentTextBlock = new TextBlock();
            contentTextBlock.Text = _content;
            TextBlock dateTextBlock = new TextBlock();
            //dateTextBlock.Text =_date.ToString();

            stackPanel.Children.Add(userTextBlock);
            stackPanel.Children.Add(contentTextBlock);
            stackPanel.Children.Add(dateTextBlock);

            grid.Children.Add(stackPanel);

            Grid.SetRow(stackPanel, 0);
            Grid.SetColumn(stackPanel, 0);
            Grid.SetColumnSpan(stackPanel, 2);

            return grid;
        }
    }

}

//< CUANDO SE VAYA A CREAR CADA INSTANCIA, AÑADIR ESTE BOTÓN EN EL C# DE CADA INSTANCIA CREADA
//Button Content = "Edit" Visibility = "{Binding CanEdit, Converter={StaticResource BoolToVisibilityConverter}}"
///>

