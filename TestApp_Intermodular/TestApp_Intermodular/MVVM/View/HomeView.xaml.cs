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

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            //DisplayRoutes(13);
        }
        private void DisplayRoutes(int number)
        {
            int cont = 0;
            for (int i = 0; i < number; i++)
            {
                MiniRoute mr = new MiniRoute();
                Grid grid = mr.ShowRoutes();              

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

        private async void getRandomRoutesUIDs()
        {
            var client = new HttpClient();
            var url = "https://intermodular.fadedbytes.com/api/v1/randomroutes";

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var ids = JsonConvert.DeserializeObject<dynamic>(responseBody);

                var miniRoutes = new List<MiniRoute>();
                foreach (var id in ids)
                {
                    //// Create a new instance of MiniRoute for each ID
                    //var miniRoute = new MiniRoute
                    //{
                    //    Name = $"{id}",
                    //    Description = $"{id}",
                    //    Length = id * 2.5, // Example calculation
                    //    Fav = false,
                    //    UID = false
                    //};

                    //// Add the MiniRoute to the list
                    //miniRoutes.Add(miniRoute);
                }

                // Use the miniRoutes list as needed...
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP request exception: {e.Message}");
            }
        }
    }
}
