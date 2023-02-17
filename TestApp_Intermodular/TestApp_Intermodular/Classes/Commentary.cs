using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestApp_Intermodular.Classes
{
    public class Commentary
    {
        private string _content;
        private DateTime _date;
        private string _user;
        private bool _isAdmin;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

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
    }

}

//< CUANDO SE VAYA A CREAR CADA INSTANCIA, AÑADIR ESTE BOTÓN EN EL C# DE CADA INSTANCIA CREADA
//Button Content = "Edit" Visibility = "{Binding CanEdit, Converter={StaticResource BoolToVisibilityConverter}}"
///>

