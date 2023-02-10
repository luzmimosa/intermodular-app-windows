using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp_Intermodular.Classes
{
    public class Route
    {
        public class Rootobject
        {
            public string uid { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string image { get; set; }
            public Startinglocation startingLocation { get; set; }
            public Location[] locations { get; set; }
            public string[] types { get; set; }
            public float length { get; set; }
            public string difficulty { get; set; }
            public string creator { get; set; }
            public long creationDatetime { get; set; }
        }

        public class Startinglocation
        {
            public float longitude { get; set; }
            public float latitude { get; set; }
            public string _id { get; set; }
        }

        public class Location
        {
            public float longitude { get; set; }
            public float latitude { get; set; }
            public string _id { get; set; }
            public Waypoint waypoint { get; set; }
        }

        public class Waypoint
        {
            public string name { get; set; }
            public string description { get; set; }
            public string image { get; set; }
            public string _id { get; set; }
        }

    }
}
