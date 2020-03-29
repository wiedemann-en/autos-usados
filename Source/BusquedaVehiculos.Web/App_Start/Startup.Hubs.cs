using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaVehiculos.Web
{
    public partial class Startup
    {
        public static void ConfigureHubs(IAppBuilder app)
        {
            // Register the default hubs route: ~/signalr/hubs
            app.MapSignalR();
        }
    }
}