using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Infra.Exceptions
{
    public static class Extenders
    {
        public static String ToMessageAndCompleteStackTrace(this Exception exception)
        {
            var ex = exception;
            var stringBuilder = new StringBuilder();
            while (ex != null)
            {
                stringBuilder.AppendLine("Exception type: " + ex.GetType().FullName);
                stringBuilder.AppendLine("Message       : " + ex.Message);
                stringBuilder.AppendLine("Stacktrace:");
                stringBuilder.AppendLine(ex.StackTrace);
                stringBuilder.AppendLine();
                ex = ex.InnerException;
            }
            return stringBuilder.ToString();
        }

        public static List<String> ToListMessages(this Exception exception)
        {
            var ex = exception;
            var result = new List<String>();
            while (ex != null)
            {
                if (!result.Contains(ex.Message))
                    result.Add(ex.Message);
                ex = ex.InnerException;
            }
            return result;
        }
    }
}
