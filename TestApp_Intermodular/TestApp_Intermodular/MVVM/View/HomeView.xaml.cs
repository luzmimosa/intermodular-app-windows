using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApp_Intermodular.Classes;
using Newtonsoft.Json;
using System.Drawing;

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private List<string> RandomIds = new List<string>();
        private List<MiniRoute> RouteList = new List<MiniRoute>();
        public HomeView()
        {
            InitializeComponent();
            //DisplayRoutes();
            GetRandomRouteAsync();
        }
        private async void DisplayRoutes()
        {
            RouteList = await GetRandomRouteAsync();
            foreach (var i in RouteList) { MessageBox.Show(i.ToString()); }
            int cont = 0;
            //for (int i = 0; i < number; i++)
            //{
            //    MiniRoute mr = new MiniRoute();
            //    Grid grid = mr.ShowRoutes();              

            //    if (cont % 2 == 0)
            //    {
            //        ColumnA.Children.Add(grid);
            //        cont++;
            //    }
            //    else
            //    {
            //        ColumnB.Children.Add(grid);
            //        cont++;
            //    }
            //}
        }

        public async Task<List<string>> GetRandomRoutesUIDsAsync()
        {
            var client = new HttpClient();
            var url = "https://intermodular.fadedbytes.com/api/v1/randomroutes";

            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<string>>(responseBody);
                RandomIds.AddRange(result);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP request exception: {e.Message}");
            }
            return RandomIds;
        }
        public async Task<List<MiniRoute>> GetRandomRouteAsync()
        {
            var routeIds = new List<String>();
            routeIds = await GetRandomRoutesUIDsAsync();
            var routes = new List<MiniRoute>();
            int cont = 0;

            foreach (var routeId in routeIds)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var url = "https://intermodular.fadedbytes.com/api/v1/route/"+routeId.ToString();
                

                try
                {                    
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    MessageBox.Show(result.ToString());
                    MiniRoute route = new MiniRoute
                    {
                        UID = result.uid,
                        Name = result.name,
                        Description = result.description,
                        Length = result.distance
                    };
                    MessageBox.Show(route.ToString());
                    routes.Add(route);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"HTTP request exception: {e.Message}");
                }
            }
                return routes;
        }
    }
}
