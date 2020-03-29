using BusquedaVehiculos.Web.Infra;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusquedaVehiculos.Web.Hubs
{
    public class BusquedaProgressHub : Hub
    {
        public BusquedaProgressHub()
        {
        }

        public void TrackJob(string jobId)
        {
            Groups.Add(Context.ConnectionId, jobId);
            BusquedaJobManager.StartJob(jobId);
        }
    }
}