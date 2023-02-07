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

namespace TestApp_Intermodular.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public Data Data { get; set; }
        public HomeView()
        {
            InitializeComponent();
            //GetDataFromServer();
        }
        private async void GetDataFromServer()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://yourserver.com/api/data");

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string content = await response.Content.ReadAsStringAsync();

                    // Deserialize the content into an object
                    // For example, if the content is in JSON format, you could use Newtonsoft.Json or System.Text.Json to deserialize the content into an object

                    Data = new Data
                    {
                        ImageSource = new BitmapImage(new Uri("image.png", UriKind.Relative)),
                        Title = "Title",
                        Subtitle = "Subtitle",
                        Number = "123"
                    };
                }
            }
        }
    }
}
