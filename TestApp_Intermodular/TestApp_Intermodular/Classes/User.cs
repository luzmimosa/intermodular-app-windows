
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp_Intermodular.Classes
{
    public class User
    {
        public string username { get; set; }
        public string profilePicture { get; set; }
        public string displayName { get; set; }
        public object[] toDoRoutes { get; set; }
        public object[] featuredRoutes { get; set; }
        public string biography { get; set; }
    }
}
