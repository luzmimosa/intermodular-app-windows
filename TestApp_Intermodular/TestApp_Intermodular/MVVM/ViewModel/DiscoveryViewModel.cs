using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using TestApp_Intermodular.MVVM.View;

namespace TestApp_Intermodular.MVVM.ViewModel
{
    class DiscoveryViewModel : DiscoveryView
    {
        public DiscoveryViewModel()
        {
            WindowsFormsHost windowsFormsHost = new WindowsFormsHost();
            this.Content = windowsFormsHost;
            var webBrowser = new WebBrowser();
            windowsFormsHost.Child = webBrowser;
            webBrowser.Navigate("https://maps.google.com/maps?q=New+York&t=k&z=13&ie=UTF8&iwloc=&output=embed");
        }
    }

    
}
