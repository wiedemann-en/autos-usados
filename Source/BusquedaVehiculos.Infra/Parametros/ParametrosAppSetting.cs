using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Infra.Parametros
{
    public static class ParametrosAppSetting
    {
        #region Valores
        public static String ConfigAmbienteTest
        {
            get { return GetSettingDefault("CONFIG:AmbienteTest", "N"); }
        }
        #endregion

        #region Helpers
        private static String GetSettingDefault(String codSetting, String defaultValue)
        {
            var retorno = ConfigurationManager.AppSettings[codSetting];
            if (String.IsNullOrWhiteSpace(retorno))
                return defaultValue;
            return retorno;
        }
        #endregion
    }
}
