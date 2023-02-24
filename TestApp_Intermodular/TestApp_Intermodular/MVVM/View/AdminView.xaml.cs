using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestApp_Intermodular.Classes;

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        private List<UserList> Users = new List<UserList>();
        private List<String> UsersList = new List<String>();
        public AdminView()
        {
            InitializeComponent();
            DisplayUsers();

            
        }
        public async void DisplayUsers() 
        {
            var stackPanel = new StackPanel();
            var usuario = new List<UserList>();
            usuario = await GetUserInfoAsync();

            foreach (var user in usuario) 
            {
                StackPanel sp = user.DisplayList();
                stackPanel.Children.Add(sp);
            }
            scrollViewer.Content = stackPanel;
        }
        public async Task<List<String>> GetAllUsersAsync()
        {
            var client = new HttpClient();
            var url = "https://intermodular.fadedbytes.com/api/v1/allusers";

            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<string>>(responseBody);
                UsersList.AddRange(result);             
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP request exception: {e.Message}");
            }
            return UsersList;
        }
        public async Task<List<UserList>> GetUserInfoAsync()
        {
            var AllUsersList = new List<String>();
            AllUsersList = await GetAllUsersAsync();

            foreach (var i in AllUsersList)
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var response = await httpClient.GetAsync("https://intermodular.fadedbytes.com/api/v1/user/" + i);

                var json = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(json);

                UserList Listado = new UserList();
                Listado.Username = user.username;
                Listado.DisplayName = user.displayName;
                Users.Add(Listado);
            }
            return Users;
        }
    }
}
