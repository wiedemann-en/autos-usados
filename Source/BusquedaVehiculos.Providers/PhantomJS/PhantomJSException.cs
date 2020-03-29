using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.PhantomJS
{
    public class PhantomJSException : Exception
    {
        #region Atributos públicos
        public int ErrorCode { get; private set; }
        #endregion

        #region Constructores
        public PhantomJSException(int errCode, string message)
          : base(string.Format("PhantomJS exit code {0}: {1}", (object)errCode, (object)message))
        {
            this.ErrorCode = errCode;
        }
        #endregion
    }
}
