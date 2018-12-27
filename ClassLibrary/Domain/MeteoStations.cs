using ClassLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Domain
{
    public class MeteoStations
    {
        [DBField("id")]
        public int Id { get; set; }

        [DBField("name")]
        public string Name { get; set; }

        [DBField("longitude")]
        public double Longitude { get; set; }

        [DBField("latitude")]
        public double Latitude { get; set; }
    }
}
