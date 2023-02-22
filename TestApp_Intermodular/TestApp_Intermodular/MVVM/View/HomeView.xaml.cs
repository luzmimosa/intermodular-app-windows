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
            DisplayRoutes();           
        }
        private async void DisplayRoutes()
        {
            var ruta = new List<MiniRoute>();
            ruta = await GetRandomRouteAsync();
            int cont = 0;
            foreach (var i in ruta) 
            {
                Grid grid = i.ShowRoutes();
                if (cont % 2 == 0)
                    {
                        ColumnA.Children.Add(grid);
                        cont++;
                    }
                    else
                    {
                        ColumnB.Children.Add(grid);
                        cont++;
                    }
            }
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
            var routes = new List<Route.Rootobject>();

            foreach (var i in routeIds)
            {
                int cont=0;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GlobalToken.Token);
                var url = "https://intermodular.fadedbytes.com/api/v1/route/"+i;

                try
                {
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var route = JsonConvert.DeserializeObject<Route.Rootobject>(responseBody);

                    routes.Add(route);                   


                    MiniRoute miniRoute = new MiniRoute();
                    miniRoute.Name = route.name;
                    miniRoute.Description = route.description;
                    miniRoute.Length = KmConverter.ConvertToKm(route.length);
                    miniRoute.UID = route.uid;
                    miniRoute.difficulty= route.difficulty;
                    miniRoute.creator= route.creator;
                    miniRoute.creationDatetime= route.creationDatetime;
                    RouteList.Add(miniRoute);

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"HTTP request exception: {e.Message}");
                }
            }
                return RouteList;
        }
    }
}
