using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Providers.Helpers
{
    internal static class HtmlNodeHelpers
    {
        internal static HtmlNode GetElementByClassName(this HtmlNode htmlNode, String tagName, String className)
        {
            var retorno = htmlNode.Descendants(tagName)
                .FirstOrDefault(d => d.Attributes.Contains("class")
                    && d.Attributes["class"].Value.Contains(className));
            return retorno ?? new HtmlNode(HtmlNodeType.Element, null, 0);
        }

        internal static List<HtmlNode> GetElementsByClassName(this HtmlNode htmlNode, String tagName, String className)
        {
            var retorno = htmlNode.Descendants(tagName)
                .Where(d => d.Attributes.Contains("class")
                    && d.Attributes["class"].Value.Contains(className)).ToList();
            return retorno ?? new List<HtmlNode>();
        }
    }
}
