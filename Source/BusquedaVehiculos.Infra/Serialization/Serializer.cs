using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BusquedaVehiculos.Infra.Serialization
{
    public static class Serializer
    {
        public const string XmlHeaderUnicode = "<?xml version=\"1.0\" encoding=\"utf-16\"?>";

        private const string NAMESPACE_KEY = "xmlns";
        private const string END_TAG = ">";

        public static string DeleteElementNameSpace(string xml)
        {
            var begin = xml.IndexOf(NAMESPACE_KEY);
            var end = xml.IndexOf(END_TAG, begin);
            return xml.Remove(begin, end - begin);
        }

        /// <summary>
        /// Serializa el objecto y guarda el xml en la ruta indicada
        /// </summary>
        /// <param name="o"></param>
        /// <param name="FileName"></param>
        public static string Serialize(object o)
        {
            return o.Serialize();
        }

        /// <summary>
        /// Deserialize using XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            StringReader stringReader = new StringReader(xml);
            using (var xmlReader = new XmlTextReader(stringReader))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream xml)
        {
            using (var xmlReader = XmlTextReader.Create(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(xmlReader);
            }
        }

        /// <summary>
        /// Deserialize the xml in the given full path
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="xmlFullPath">full path of xml file</param>
        /// <returns></returns>
        public static T DeserializeFromPath<T>(string xmlFullPath)
        {
            var xml = File.ReadAllText(xmlFullPath);
            return Deserialize<T>(xml);
        }

        /// <summary>
        /// Deserialize the xml resource embebed
        /// </summary>
        /// <typeparam name="T">Result Type</typeparam>
        /// <param name="fullResourceName">full name of the embebed resource (ie:smartixhub.zurich.mapping.codigospostales.xml)</param>
        /// <param name="someTypeOnXmlAssembly">some type that exists in the same assembly of the xml resource</param>
        /// <returns></returns>
        public static T DeserializeFromResource<T>(string fullResourceName, Type someTypeOnXmlAssembly)
            where T : class, new()
        {
            T retorno = default(T);

            using (var streamResource = Assembly.GetAssembly(someTypeOnXmlAssembly).GetManifestResourceStream(fullResourceName))
            {
                retorno = Deserialize<T>(streamResource);
            }

            return retorno;
        }
    }
}
