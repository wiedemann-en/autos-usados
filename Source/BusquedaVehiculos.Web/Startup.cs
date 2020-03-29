using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(BusquedaVehiculos.Web.Startup))]
namespace BusquedaVehiculos.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureHubs(app);
            app.MapSignalR();
        }
    }
}