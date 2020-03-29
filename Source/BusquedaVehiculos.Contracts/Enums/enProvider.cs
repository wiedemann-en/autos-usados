using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Contracts.Enums
{
    public static class enProvider
    {
        public static string AlaMaula = "ALAMAULA";
        public static string AutoFoco = "AUTOFOCO";
        public static string DeAutos = "DEAUTOS";
        public static string DeMotores = "DEMOTORES";
        public static string MercadoLibre = "MERCADOLIBRE";
        public static string Olx = "OLX";

        #region Logic
        public static List<String> GetProviders()
        {
            var retorno = new List<String>();
            retorno.Add(enProvider.AlaMaula);
            retorno.Add(enProvider.AutoFoco);
            retorno.Add(enProvider.DeAutos);
            retorno.Add(enProvider.DeMotores);
            retorno.Add(enProvider.MercadoLibre);
            retorno.Add(enProvider.Olx);
            return retorno;
        }
        #endregion
    }
}
