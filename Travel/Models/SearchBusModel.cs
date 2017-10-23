using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class SearchBusModel
    {
        public RouteViewModel routemodel { get; set; }
        public List<RouteViewModel> routelist { get; set; }
        public List<Table_bus> buslist { get; set; }
    }
}