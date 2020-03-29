using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BusquedaVehiculos.Infra.Serialization
{
    public static class Extenders
    {
        /// <summary>
        /// Serialize with XmlSerializer
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Serialize(this object o)
        {
            var xmlSerializer = new XmlSerializer(o.GetType());

            using (var s = new StringWriter(new StringBuilder()))
            {
                xmlSerializer.Serialize(s, o);
                s.Flush();
                return s.ToString();
            }
        }

        /// <summary>
        /// Deserialize the given xml in an instance of T using XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this string xml)
        {
            return Serializer.Deserialize<T>(xml);
        }

        /// <summary>
        /// Serializa el objecto y guarda el xml en el directorio de ejecución con el nombre "[Tipo].xml"
        /// </summary>
        /// <param name="o"></param>
        public static void SerializeAndSave(this object o)
        {
            SerializeAndSave(o, Path.Combine(Environment.CurrentDirectory, o.GetType().ToString(), ".xml"));
        }

        /// <summary>
        /// Serializa el objecto y guarda el xml en la ruta indicada
        /// </summary>
        /// <param name="o"></param>
        /// <param name="FullFileName"></param>
        public static void SerializeAndSave(this object o, String FullFileName)
        {
            if (o != null)
            {
                var xmlSerializer = new XmlSerializer(o.GetType());
                using (var xmlFile = XmlWriter.Create(FullFileName))
                {
                    xmlSerializer.Serialize(xmlFile, o);
                }
                xmlSerializer = null;
            }
        }
    }
}
