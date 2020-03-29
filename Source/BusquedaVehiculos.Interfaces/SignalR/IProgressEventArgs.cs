using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.SignalR
{
    public interface IProgressEventArgs
    {
        Int32 Progress { get; set; }
        Object Message { get; set; }
    }
}
