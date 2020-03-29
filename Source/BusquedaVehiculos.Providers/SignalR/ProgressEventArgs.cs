using BusquedaVehiculos.Interfaces.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.SignalR
{
    public class ProgressEventArgs : EventArgs, IProgressEventArgs
    {
        public Int32 Progress { get; set; }
        public Object Message { get; set; }
    }
}
