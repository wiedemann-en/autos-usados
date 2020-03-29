using BusquedaVehiculos.Contracts.Busqueda;
using BusquedaVehiculos.Interfaces.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.SignalR
{
    public class BusquedaLongRunningTask : IBusquedaLongRunningTask
    {
        #region Eventos públicos
        public event EventHandler<IProgressEventArgs> ProgressChanged;
        public event EventHandler<IProgressEventArgs> Completed;
        #endregion

        #region Atributos estado ejecución
        private volatile Boolean _completed;
        public Boolean IsComplete { get { return _completed; } }

        private volatile Int32 _progress;
        public Int32 Progress { get { return _progress; } }
        #endregion

        #region Métodos notificación
        public void Report(BusquedaResponseDTO message)
        {
            OnProgressChanged(new ProgressEventArgs { Message = message });
        }

        public void Report(BusquedaResponseDTO message, Int32 progress)
        {
            OnProgressChanged(new ProgressEventArgs { Message = message, Progress = progress });
        }

        public void Complete()
        {
            if (!IsComplete)
            {
                _completed = true;
                OnCompleted(new ProgressEventArgs { Progress = 100 });
            }
        }
        #endregion

        #region Métodos protected
        protected virtual void OnProgressChanged(IProgressEventArgs e)
        {
            var handler = ProgressChanged;
            this._progress = e.Progress;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnCompleted(IProgressEventArgs e)
        {
            var handler = Completed;
            if (handler != null) handler(this, e);
        }
        #endregion
    }
}
