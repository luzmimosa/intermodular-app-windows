using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Drawing;
using Color = System.Windows.Media.Color;
using System.Net.Http;

namespace TestApp_Intermodular.Classes
{
    public class UserList 
    {
        public string Username { get; set; }
        public string NewUser { get; set; }
        public string DisplayName { get; set; }
        public string NewName { get; set; }

        public StackPanel DisplayList()
        {
            bool _is = false;
            var enabledBackground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            var disabledBackground = new SolidColorBrush(Color.FromRgb(192, 192, 192)); // Light gray

            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Height = 50,
                Background = new SolidColorBrush(Color.FromRgb(22, 138, 173)),
                Margin = new Thickness(5)
            };
            var textBlock1 = new TextBlock();
            textBlock1.Text = "Nombre: ";
            textBlock1.Margin = new Thickness(5, 0, 0, 0);
            textBlock1.Foreground = new SolidColorBrush(Color.FromRgb(0,0, 0));
            textBlock1.VerticalAlignment= VerticalAlignment.Center;

            var textBlock2 = new TextBlock();
            textBlock2.Text = "Usuario: ";
            textBlock2.Margin= new Thickness(5,0,0,0);
            textBlock2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            textBlock2.VerticalAlignment = VerticalAlignment.Center;

            var textBox1 = new TextBox();
            textBox1.Text = (dynamic)DisplayName;
            textBox1.IsReadOnly = true;
            textBox1.IsEnabled = false;
            textBox1.Foreground = disabledBackground;
            textBox1.Height = 20;
            textBox1.Width = 100;
            textBox1.Margin= new Thickness(2);
            textBox1.HorizontalAlignment = HorizontalAlignment.Right;

            var textBox2 = new TextBox();
            textBox2.Text = (dynamic)Username;
            textBox2.IsReadOnly = true;
            textBox2.IsEnabled = false;
            textBox2.Foreground = disabledBackground;
            textBox2.Height = 20;
            textBox2.Width = 100;
            textBox2.Margin = new Thickness(2);
            textBox2.HorizontalAlignment = HorizontalAlignment.Right;


            var modifyButton = new Button();
            modifyButton.Height = 30;
            modifyButton.Width = 100;
            modifyButton.Content = "Modificar usuario";
            modifyButton.Margin = new Thickness(2);
            modifyButton.Background = new SolidColorBrush(Color.FromRgb(153, 217, 140));
            modifyButton.HorizontalAlignment = HorizontalAlignment.Left;
            modifyButton.Foreground=new SolidColorBrush(Color.FromRgb(0, 0, 0));


            var deleteButton = new Button();
            deleteButton.Height = 30;
            deleteButton.Width = 100;
            deleteButton.Content = "Borrar usuario";
            deleteButton.IsEnabled = false;
            deleteButton.Margin = new Thickness(2);
            deleteButton.HorizontalAlignment = HorizontalAlignment.Left;
            deleteButton.Foreground = disabledBackground;
            deleteButton.Click += (sender, e) =>
            {
                
                DeleteUser(this.Username);
            };

            var saveButton = new Button();
            saveButton.Height = 30;
            saveButton.Width = 100;
            saveButton.Content = "Guardar cambios";
            saveButton.IsEnabled = false;
            saveButton.Margin = new Thickness(2);
            saveButton.HorizontalAlignment = HorizontalAlignment.Left;
            saveButton.Foreground = disabledBackground;
            saveButton.Click += (sender, e) =>
            {
                this.NewUser = textBox2.Text;
                this.NewName = textBox1.Text;
                ModifyUser(this.Username);
            };

            modifyButton.Click += (sender, e) =>
            {
                textBox1.IsReadOnly = _is;
                textBox2.IsReadOnly = _is;

                if (!_is)
                {
                    textBox1.Foreground = enabledBackground;
                    textBox2.Foreground = enabledBackground;
                    deleteButton.Background = new SolidColorBrush(Color.FromRgb(52, 160, 164));
                    deleteButton.Foreground = enabledBackground;
                    saveButton.Background = new SolidColorBrush(Color.FromRgb(181, 228, 140));
                    saveButton.Foreground = enabledBackground;
                }
                else 
                {
                    textBox1.Foreground = disabledBackground;
                    textBox2.Foreground = disabledBackground;
                    deleteButton.Foreground = disabledBackground;
                    saveButton.Foreground = disabledBackground;
                }
                

                textBox1.IsEnabled = !_is;
                textBox2.IsEnabled = !_is;

                saveButton.IsEnabled = !_is;
                deleteButton.IsEnabled = !_is;

                _is = !_is;
            };

            stackPanel.Children.Add(textBlock1);
            stackPanel.Children.Add(textBox1);
            stackPanel.Children.Add(textBlock2);
            stackPanel.Children.Add(textBox2);
            stackPanel.Children.Add(modifyButton);
            stackPanel.Children.Add(deleteButton);
            stackPanel.Children.Add(saveButton);

            return stackPanel;
        }
        private async void DeleteUser(String i)
        {
            string url = "https://intermodular.fadedbytes.com/api/v1/user/"+i;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode){MessageBox.Show("Usuario eliminado con éxito.");}
                else{MessageBox.Show("Ha ocurrido algún error, por favor, ponte en contacto con soporte.");}
            }
        }

        private async /*Task<string>*/ void ModifyUser(String i) 
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var data = new
                {
                    username = this.NewUser,
                    displayName = this.NewName,
                };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                
                var response = await client.PostAsync("https://intermodular.fadedbytes.com/account/modify/"+i, content);

                MessageBox.Show(response.ToString());
                //return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
