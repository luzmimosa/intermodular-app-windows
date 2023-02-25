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
        public string DisplayName { get; set; }

        public StackPanel DisplayList()
        {
            bool _is = false;
            var enabledBackground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            var disabledBackground = new SolidColorBrush(Color.FromRgb(192, 192, 192)); // Light gray

            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Height = 50,
                Background = new SolidColorBrush(Color.FromRgb(0x10, 0xa7, 0x4f)),
                Margin = new Thickness(5)
            };

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
            modifyButton.HorizontalAlignment = HorizontalAlignment.Left;
            

            var deleteButton = new Button();
            deleteButton.Height = 30;
            deleteButton.Width = 100;
            deleteButton.Content = "Borrar usuario";
            deleteButton.IsEnabled = false;
            deleteButton.Margin = new Thickness(2);
            deleteButton.HorizontalAlignment = HorizontalAlignment.Left;
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
            saveButton.Click += (sender, e) =>
            {
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
                    deleteButton.Background = new SolidColorBrush(Color.FromRgb(236, 112, 99));
                }
                else 
                {
                    textBox1.Foreground = disabledBackground;
                    textBox2.Foreground = disabledBackground;
                }
                

                textBox1.IsEnabled = !_is;
                textBox2.IsEnabled = !_is;

                saveButton.IsEnabled = !_is;
                deleteButton.IsEnabled = !_is;

                _is = !_is;
            };

            stackPanel.Children.Add(textBox1);
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

        private async void ModifyUser(String i) 
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var data = new
                {
                    username = this.Username,
                    displayName = this.DisplayName,
                };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                MessageBox.Show(content.ToString());
                MessageBox.Show("https://intermodular.fadedbytes.com/account/modify/" + i);

                
                var response = await client.PostAsync("https://intermodular.fadedbytes.com/account/modify/"+i, content);

                MessageBox.Show(response.ToString());
            }
        }
    }
}
