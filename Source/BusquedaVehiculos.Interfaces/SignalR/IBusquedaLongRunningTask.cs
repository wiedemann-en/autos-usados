using BusquedaVehiculos.Contracts.Busqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Interfaces.SignalR
{
    public interface IBusquedaLongRunningTask
    {
        event EventHandler<IProgressEventArgs> ProgressChanged;
        event EventHandler<IProgressEventArgs> Completed;

        Boolean IsComplete { get; }
        Int32 Progress { get; }

        void Report(BusquedaResponseDTO message);
        void Report(BusquedaResponseDTO message, int progress);
        void Complete();
    }
}
