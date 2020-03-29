using BusquedaVehiculos.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Import
{
    class Process
    {
        #region SQL
        private String KSQL_INSERT_MARCA = @"INSERT INTO TB_VehiculoMarca (CodVehiculoMarca, DescVehiculoMarca) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_SUBMARCA = @"INSERT INTO TB_VehiculoSubMarca (CodVehiculoMarca, CodVehiculoSubMarca, DescVehiculoSubMarca) VALUES ('{0}', '{1}', '{2}');";
        private String KSQL_INSERT_PROV = @"INSERT INTO TB_VehiculoProvincia (CodVehiculoProvincia, DescVehiculoProvincia) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_COL = @"INSERT INTO TB_VehiculoColor (CodVehiculoColor, DescVehiculoColor) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_COMB = @"INSERT INTO TB_VehiculoCombustible (CodVehiculoCombustible, DescVehiculoCombustible) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_TRANS = @"INSERT INTO TB_VehiculoTransmision (CodVehiculoTransmision, DescVehiculoTransmision) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_DIR = @"INSERT INTO TB_VehiculoDireccion (CodVehiculoDireccion, DescVehiculoDireccion) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_SEG = @"INSERT INTO TB_VehiculoSegmento (CodVehiculoSegmento, DescVehiculoSegmento) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_TRAC = @"INSERT INTO TB_VehiculoTraccion (CodVehiculoTraccion, DescVehiculoTraccion) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_PTA = @"INSERT INTO TB_VehiculoPuerta (CodVehiculoPuerta, DescVehiculoPuerta) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_ORD = @"INSERT INTO TB_VehiculoOrden (CodVehiculoOrden, DescVehiculoOrden) VALUES ('{0}', '{1}');";
        private String KSQL_INSERT_CI = @"INSERT INTO TB_ProviderCatalogoItem (CodProvider, CodCatalogo, CodItemProvider, DescItemProvider) VALUES ('{0}', '{1}', '{2}', '{3}');";
        private String KSQL_INSERT_CIV = @"INSERT INTO TB_ProviderCatalogoItemConv (CodProvider, CodCatalogo, CodItemProvider, CodItemConv) VALUES ('{0}', '{1}', '{2}', '{3}');";
        private String KSQL_SELECT_MARCA = @"
        SELECT 
	        CodItemProvider 
        FROM 
	        TB_ProviderCatalogoItemConv 
        WHERE 
	        CodProvider = '{0}' 
	        AND 
	        CodCatalogo = '{1}'
	        AND
	        CodItemConv = '{2}'";
        #endregion

        #region Atributos privados
        private DataTable RegistrosXLS { get; set; }
        private List<String> Inserts { get; set; }
        private List<String> InsertsCI { get; set; }
        private List<String> InsertsCIV { get; set; }
        #endregion

        #region Constructores
        public Process()
        {
            this.Inserts = new List<String>();
            this.InsertsCI = new List<String>();
            this.InsertsCIV = new List<String>();
        }
        #endregion

        #region Interfaz pública
        public void Execute(String catalogo, String path)
        {
            this.OpenFile(catalogo, path);
            this.LoadFile(catalogo, null);
            this.SaveInsertsFile(catalogo, null);
        }
        public void Execute(String catalogo, String path, String marca)
        {
            this.OpenFile(catalogo, path);
            this.LoadFile(catalogo, marca);
            this.SaveInsertsFile(catalogo, marca);
        }
        #endregion

        #region métodos privados
        private void OpenFile(String catalogo, String path)
        {
            //var connString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", path);
            //var con = new OleDbConnection(connString);
            var con = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\"", path));
            var da = new OleDbDataAdapter(String.Format("SELECT * FROM [{0}$]", catalogo), con);
            RegistrosXLS = new DataTable();
            da.Fill(RegistrosXLS);
        }
        private void LoadFile(String catalogo, String marca)
        {
            //[0]->SITIO
            //[1]->DEAUTOS
            //[2]->DEMOTORES
            //[3]->MERCADOLIBRE
            //[4]->AUTOFOCO
            //[5]->OLX
            //[0]->ALAMAULA

            foreach (var row in RegistrosXLS.AsEnumerable())
            {
                var contentSitio = row["SITIO"].ToString().Trim();
                var contentDeAutos = row["DEAUTOS"].ToString().Trim();
                var contentDeMotores = row["DEMOTORES"].ToString().Trim();
                var contentMercadoLibre = row["MERCADOLIBRE"].ToString().Trim();
                var contentAutoFoco = row["AUTOFOCO"].ToString().Trim();
                var contentOlx = row["OLX"].ToString().Trim();
                var contentAlaMaula = row["ALAMAULA"].ToString().Trim();

                //this.TratamientoSitio(catalogo, contentSitio, marca);

                var idSitio = this.LimpiarCadena(contentSitio);
                this.TratamientoDeAutos(catalogo, contentDeAutos, idSitio, marca);
                this.TratamientoDeMotores(catalogo, contentDeMotores, idSitio, marca);
                this.TratamientoMercadoLibre(catalogo, contentMercadoLibre, idSitio, marca);
                this.TratamientoAutoFoco(catalogo, contentAutoFoco, idSitio, marca);
                this.TratamientoOlx(catalogo, contentOlx, idSitio, marca);
                this.TratamientoAlaMaula(catalogo, contentAlaMaula, idSitio, marca);
            }
        }
        private void SaveInsertsFile(String catalogo, String marca)
        {
            //Tabla
            if (this.Inserts.Count > 0)
            {
                this.Inserts = this.Inserts.OrderBy(x => x).ToList();
                var fileName = String.Empty;
                if (!String.IsNullOrEmpty(marca))
                {
                    fileName = DateTime.Now.ToString("yyyyMMdd") + "_Inserts" + catalogo + "_" + marca + ".sql";
                }
                else
                {
                    fileName = DateTime.Now.ToString("yyyyMMdd") + "_Inserts" + catalogo + ".sql";
                }
                var path = @"C:\Users\EstebanNicolas\Desktop\Autos\_Inserts\" + fileName;
                using (TextWriter tw = new StreamWriter(path))
                {
                    foreach (String s in this.Inserts)
                        tw.WriteLine(s);
                }
            }

            //Tabla Conversión
            if (this.InsertsCI.Count > 0)
            {
                this.InsertsCI = this.InsertsCI.OrderBy(x => x).ToList();
                var fileNameCI = String.Empty;
                if (!String.IsNullOrEmpty(marca))
                {
                    fileNameCI = DateTime.Now.ToString("yyyyMMdd") + "_Inserts" + catalogo + "_" + marca + "CI.sql";
                }
                else
                {
                    fileNameCI = DateTime.Now.ToString("yyyyMMdd") + "_Inserts" + catalogo + "CI.sql";
                }
                var pathCI = @"C:\Users\EstebanNicolas\Desktop\Autos\_Inserts\" + fileNameCI;
                using (TextWriter tw = new StreamWriter(pathCI))
                {
                    foreach (String s in this.InsertsCI)
                        tw.WriteLine(s);
                }
            }

            //Tabla Conversión Valores
            if (this.InsertsCIV.Count > 0)
            {
                this.InsertsCIV = this.InsertsCIV.OrderBy(x => x).ToList();
                var fileNameCIV = String.Empty;
                if (!String.IsNullOrEmpty(marca))
                {
                    fileNameCIV = DateTime.Now.ToString("yyyyMMdd") + "_Inserts" + catalogo + "_" + marca + "CIV.sql";
                }
                else
                {
                    fileNameCIV = DateTime.Now.ToString("yyyyMMdd") + "_Inserts" + catalogo + "CIV.sql";
                }
                var pathCIV = @"C:\Users\EstebanNicolas\Desktop\Autos\_Inserts\" + fileNameCIV;
                using (TextWriter tw = new StreamWriter(pathCIV))
                {
                    foreach (String s in this.InsertsCIV)
                        tw.WriteLine(s);
                }
            }
        }
        #endregion

        #region Tratmientos
        private void TratamientoSitio(String catalogo, String content, String marca)
        {
            var id = this.LimpiarCadena(content);
            switch (catalogo)
            {
                case "Marca":
                    this.Inserts.Add(String.Format(KSQL_INSERT_MARCA, id, content));
                    break;
                case "Modelo":
                    this.Inserts.Add(String.Format(KSQL_INSERT_SUBMARCA, this.LimpiarCadena(marca), id, content));
                    break;
                case "Provincia":
                    this.Inserts.Add(String.Format(KSQL_INSERT_PROV, id, content));
                    break;
                case "Color":
                    this.Inserts.Add(String.Format(KSQL_INSERT_COL, id, content));
                    break;
                case "Combustible":
                    this.Inserts.Add(String.Format(KSQL_INSERT_COMB, id, content));
                    break;
                case "Transmision":
                    this.Inserts.Add(String.Format(KSQL_INSERT_TRANS, id, content));
                    break;
                case "Direccion":
                    this.Inserts.Add(String.Format(KSQL_INSERT_DIR, id, content));
                    break;
                case "Segmento":
                    this.Inserts.Add(String.Format(KSQL_INSERT_SEG, id, content));
                    break;
                case "Traccion":
                    this.Inserts.Add(String.Format(KSQL_INSERT_TRAC, id, content));
                    break;
                case "Puertas":
                    this.Inserts.Add(String.Format(KSQL_INSERT_PTA, id, content));
                    break;
                case "Orden":
                    this.Inserts.Add(String.Format(KSQL_INSERT_ORD, id, content));
                    break;
                default:
                    break;
            }
        }
        private void TratamientoDeAutos(String catalogo, String content, String valueSitio, String marca)
        {
            if (String.IsNullOrEmpty(content))
                return;

            var htmlDeAutos = new HtmlDocument();
            htmlDeAutos.LoadHtml(content);

            Regex r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
            var sarasa = r.Match(content);
            var id = sarasa.Groups["href"].Value.Replace("/autos-usados-", String.Empty);
            id = id.Replace("autos-usados/", String.Empty);
            var value = sarasa.Groups["value"].Value.Trim();
            if (!String.IsNullOrEmpty(value))
            {
                id = id.Replace(this.LimpiarCadena(value), String.Empty);
                id = id.Replace(this.LimpiarCadena(value.Replace(" ", String.Empty)), String.Empty);
                id = id.Replace(value.Replace(" ", String.Empty), String.Empty);
                id = id.Replace(value.ToLower(), String.Empty);
                id = id.Replace(value, String.Empty);
            }

            id = id.Replace("VTYY1", String.Empty);
            id = id.Replace("WWMAYY", String.Empty);
            id = id.Replace("WWMOYY", String.Empty);
            id = id.Replace("WWYEYY", String.Empty);
            id = id.Replace("WWPRYY", String.Empty);
            id = id.Replace("WWVFYY", String.Empty);
            id = id.Replace("WWSGYY", String.Empty);
            id = id.Replace("WWVKYY", String.Empty);
            id = id.Replace("WWPVYY", String.Empty);
            id = id.Replace("WWVCYY", String.Empty);
            id = id.Replace("WWSOYY", String.Empty);
            id = id.Replace("/", String.Empty);
            id = id.Replace("-", String.Empty);

            if (!String.IsNullOrEmpty(marca))
            {
                id = id.Replace(marca.ToLower(), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "+"), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "-"), String.Empty);
            }

            //Tratamiento para adicionar marca
            if (!String.IsNullOrEmpty(id))
            {
                id = String.Format("{0}@{1}", id.Substring(0, 3), id.Substring(3));
            }

            //Armamos insert
            this.InsertsCI.Add(String.Format(KSQL_INSERT_CI, "DEAUTOS", this.GetCodCatalogo(catalogo), id, value));
            if (!String.IsNullOrEmpty(marca))
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "DEAUTOS", this.GetCodCatalogo(catalogo), id, String.Format("{0}@{1}", this.LimpiarCadena(marca), valueSitio)));
            }
            else
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "DEAUTOS", this.GetCodCatalogo(catalogo), id, valueSitio));
            }
        }
        private void TratamientoDeMotores(String catalogo, String content, String valueSitio, String marca)
        {
            if (String.IsNullOrEmpty(content))
                return;

            var htmlDeMotores = new HtmlDocument();
            htmlDeMotores.LoadHtml(content);

            Regex r = null;
            if (content.Contains("</a>"))
                r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
            else
                r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)");
            var sarasa = r.Match(content);
            var id = sarasa.Groups["href"].Value.Replace("http://autos.demotores.com.ar/autos-usados-", String.Empty);
            id = id.Replace("http://autos.demotores.com.ar/", String.Empty);
            id = id.Replace("autos-usados/", String.Empty);
            var value = sarasa.Groups["value"].Value.Trim();
            if (!content.Contains("</a>") && String.IsNullOrEmpty(value))
                value = content.Substring(content.LastIndexOf('>') + 1);
            if (!String.IsNullOrEmpty(value))
            {
                id = id.Replace(this.LimpiarCadena(value), String.Empty);
                id = id.Replace(this.LimpiarCadena(value.Replace(" ", String.Empty)), String.Empty);
                id = id.Replace(value.Replace(" ", String.Empty), String.Empty);
                id = id.Replace(value.ToLower(), String.Empty);
                id = id.Replace(value, String.Empty);
            }

            id = id.Replace("vtZ1", String.Empty);
            id = id.Replace("QQbrZ", String.Empty);
            id = id.Replace("QQmoZ", String.Empty);
            id = id.Replace("QQreZ", String.Empty);
            id = id.Replace("QQfuelZ", String.Empty);
            id = id.Replace("QQstZ", String.Empty);
            id = id.Replace("QQsstZ", String.Empty);
            id = id.Replace("QQsgZ", String.Empty);
            id = id.Replace("QQnZ", String.Empty);
            id = id.Replace("QQtrZ", String.Empty);
            id = id.Replace("QQdZ", String.Empty);
            id = id.Replace("QQcolZ", String.Empty);
            id = id.Replace("QQyZ", String.Empty);
            id = id.Replace("QQpZ", String.Empty);
            id = id.Replace("QQkmZ", String.Empty);
            id = id.Replace("QQsortZ", String.Empty);
            id = id.Replace("/", String.Empty);

            if (!String.IsNullOrEmpty(id) && id.StartsWith("0") && catalogo == "Color")
                id = id.Substring(1);
            if (!String.IsNullOrEmpty(marca))
            {
                id = id.Replace(marca.ToLower(), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "+"), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "-"), String.Empty);
            }
            if (!String.IsNullOrEmpty(id) && id.StartsWith("-"))
                id = id.Substring(1);

            //Tratamiento para adicionar marca
            if (!String.IsNullOrEmpty(id))
            {
                var codMarcaProvider = this.GetMarcaProvider("DEMOTORES", marca);
                id = String.Format("{0}@{1}", codMarcaProvider, id);
            }

            //Armamos insert
            this.InsertsCI.Add(String.Format(KSQL_INSERT_CI, "DEMOTORES", this.GetCodCatalogo(catalogo), id, value));
            if (!String.IsNullOrEmpty(marca))
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "DEMOTORES", this.GetCodCatalogo(catalogo), id, String.Format("{0}@{1}", this.LimpiarCadena(marca), valueSitio)));
            }
            else
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "DEMOTORES", this.GetCodCatalogo(catalogo), id, valueSitio));
            }
        }
        private void TratamientoMercadoLibre(String catalogo, String content, String valueSitio, String marca)
        {
            if (String.IsNullOrEmpty(content))
                return;

            var htmlMercadoLibre = new HtmlDocument();
            htmlMercadoLibre.LoadHtml(content);

            Regex r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
            var sarasa = r.Match(content);
            var id = sarasa.Groups["href"].Value.Replace("http://autos.mercadolibre.com.ar/", String.Empty);
            var value = sarasa.Groups["value"].Value.Trim();
            //if (!String.IsNullOrEmpty(value))
            //    id = id.Replace(this.LimpiarCadena(value), String.Empty);

            id = id.Replace("OrderId_", String.Empty);
            id = id.Replace("YearRange_", String.Empty);
            id = id.Replace("PriceRange_", String.Empty);
            id = id.Replace("Color-exterior_", String.Empty);
            id = id.Replace("Combustible_", String.Empty);
            id = id.Replace("Direccion_", String.Empty);
            id = id.Replace("Cantidad-puertas_", String.Empty);
            id = id.Replace("Transmision_", String.Empty);
            id = id.Replace("kilometers_", String.Empty);
            id = id.Replace("/", String.Empty);

            if (!String.IsNullOrEmpty(id) && id.StartsWith("_"))
                id = id.Substring(1);
            if (!String.IsNullOrEmpty(marca))
            {
                id = id.Replace(marca.ToLower(), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "+"), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "-"), String.Empty);
            }

            //Tratamiento para adicionar marca
            if (!String.IsNullOrEmpty(id))
            {
                var codMarcaProvider = this.GetMarcaProvider("MERCADOLIBRE", marca);
                id = String.Format("{0}@{1}", codMarcaProvider, id);
            }

            //Armamos insert
            this.InsertsCI.Add(String.Format(KSQL_INSERT_CI, "MERCADOLIBRE", this.GetCodCatalogo(catalogo), id, value));
            if (!String.IsNullOrEmpty(marca))
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "MERCADOLIBRE", this.GetCodCatalogo(catalogo), id, String.Format("{0}@{1}", this.LimpiarCadena(marca), valueSitio)));
            }
            else
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "MERCADOLIBRE", this.GetCodCatalogo(catalogo), id, valueSitio));
            }
        }
        private void TratamientoAutoFoco(String catalogo, String content, String valueSitio, String marca)
        {
            if (String.IsNullOrEmpty(content))
                return;

            var htmlAutoFoco = new HtmlDocument();
            htmlAutoFoco.LoadHtml(content);

            string id = string.Empty;
            string value = string.Empty;

            if (content.Contains("</li>"))
            {
                Regex r = new Regex(@"<li.*?>(?<value>.*?)</li>");
                var sarasa = r.Match(content);
                id = sarasa.Groups["value"].Value.Trim();
                value = sarasa.Groups["value"].Value.Trim();
            }
            else if (content.Contains("<input"))
            {
                Regex r = new Regex(@"<input.*?value=(""|')(?<value>.*?)(""|').*?>(?<text>.*?)</label>");
                var sarasa = r.Match(content);
                id = sarasa.Groups["value"].Value.Trim();
                value = sarasa.Groups["text"].Value.Trim();
                //if (!String.IsNullOrEmpty(value))
                //    id = id.Replace(this.LimpiarCadena(value), String.Empty);
            }
            else
            {
                Regex r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
                var sarasa = r.Match(content);
                id = sarasa.Groups["href"].Value;
                value = sarasa.Groups["value"].Value.Trim();
                //if (!String.IsNullOrEmpty(value))
                //    id = id.Replace(this.LimpiarCadena(value), String.Empty);
            }

            if (catalogo == "Modelo")
                id = this.LimpiarCadena(id, "+");

            id = id.Replace("https://www.autofoco.com/todos/-/autos/-/volkswagen/gol?order_by=", String.Empty);
            id = id.Replace("/todos/-/autos/", String.Empty);
            id = id.Replace("/todos/", String.Empty);
            id = id.Replace("/volkswagen?order_by=1", String.Empty);
            id = id.Replace("autos?order_by=1", String.Empty);
            id = id.Replace("/autos-cat-378", String.Empty);

            if (!String.IsNullOrEmpty(id) && id.EndsWith("-/"))
                id = id.Substring(0, id.Length - 2);
            if (!String.IsNullOrEmpty(marca))
            {
                id = id.Replace(marca.ToLower(), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "+"), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "-"), String.Empty);
            }

            id = id.Replace("/", String.Empty);

            //Tratamiento para adicionar marca
            if (!String.IsNullOrEmpty(id))
            {
                var codMarcaProvider = this.GetMarcaProvider("AUTOFOCO", marca);
                id = String.Format("{0}@{1}", codMarcaProvider, id);
            }

            //Armamos insert
            this.InsertsCI.Add(String.Format(KSQL_INSERT_CI, "AUTOFOCO", this.GetCodCatalogo(catalogo), id, value));
            if (!String.IsNullOrEmpty(marca))
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "AUTOFOCO", this.GetCodCatalogo(catalogo), id, String.Format("{0}@{1}", this.LimpiarCadena(marca), valueSitio)));
            }
            else
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "AUTOFOCO", this.GetCodCatalogo(catalogo), id, valueSitio));
            }
        }
        private void TratamientoOlx(String catalogo, String content, String valueSitio, String marca)
        {
            if (String.IsNullOrEmpty(content))
                return;

            var htmlOlx = new HtmlDocument();
            htmlOlx.LoadHtml(content);

            string id = string.Empty;
            string value = string.Empty;

            if (content.Contains("input"))
            {
                Regex r = new Regex(@"<input.*?value=(""|')(?<value>.*?)(""|').*?>(?<text>.*?)");
                var sarasa = r.Match(content);
                id = sarasa.Groups["value"].Value.Trim();
                value = content.Substring(content.LastIndexOf('>') + 1);
                //if (!String.IsNullOrEmpty(value))
                //    id = id.Replace(this.LimpiarCadena(value), String.Empty);
            }
            else
            {
                Regex r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
                var sarasa = r.Match(content);
                id = sarasa.Groups["href"].Value;
                value = sarasa.Groups["value"].Value.Trim();
                //if (!String.IsNullOrEmpty(value))
                //    id = id.Replace(this.LimpiarCadena(value), String.Empty);
            }

            id = id.Replace("/autos-cat-378", String.Empty);
            id = id.Replace(".olx.com.ar", String.Empty);
            id = id.Replace("//", String.Empty);

            if (!String.IsNullOrEmpty(marca))
            {
                id = id.Replace(marca.ToLower(), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "+"), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "-"), String.Empty);
            }

            //Tratamiento para adicionar marca
            if (!String.IsNullOrEmpty(id))
            {
                var codMarcaProvider = this.GetMarcaProvider("OLX", marca);
                id = String.Format("{0}@{1}", codMarcaProvider, id);
            }

            //Armamos insert
            this.InsertsCI.Add(String.Format(KSQL_INSERT_CI, "OLX", this.GetCodCatalogo(catalogo), id, value));
            if (!String.IsNullOrEmpty(marca))
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "OLX", this.GetCodCatalogo(catalogo), id, String.Format("{0}@{1}", this.LimpiarCadena(marca), valueSitio)));
            }
            else
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "OLX", this.GetCodCatalogo(catalogo), id, valueSitio));
            }
        }
        private void TratamientoAlaMaula(String catalogo, String content, String valueSitio, String marca)
        {
            if (String.IsNullOrEmpty(content))
                return;

            var htmlAlaMaula = new HtmlDocument();
            htmlAlaMaula.LoadHtml(content);

            Regex r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
            var sarasa = r.Match(content);
            var id = sarasa.Groups["href"].Value.Replace("/s-autos-usados/", String.Empty);
            var value = sarasa.Groups["value"].Value.Trim();
            if (!String.IsNullOrEmpty(value) && catalogo == "Provincia")
                id = id.Replace(this.LimpiarCadena(value), String.Empty);

            id = id.Replace("v1c64", String.Empty);
            id = id.Replace("v1c65", String.Empty);
            //id = id.Replace("l2", String.Empty);
            id = id.Replace("l2a1", String.Empty);
            id = id.Replace("a4", String.Empty);
            id = id.Replace("a2", String.Empty);
            id = id.Replace("mamo", String.Empty);
            //id = id.Replace("ma", String.Empty);
            //id = id.Replace("mo", String.Empty);
            id = id.Replace("cf", String.Empty);
            //id = id.Replace("co", String.Empty);
            id = id.Replace("p1", String.Empty);
            id = id.Replace("/a1", String.Empty);
            id = id.Replace("buenos-aires/", String.Empty);
            id = id.Replace("/s-vehiculos/", String.Empty);
            id = id.Replace("/", String.Empty);
            id = id.Replace("~", String.Empty);

            if (!String.IsNullOrEmpty(marca))
            {
                id = id.Replace(marca.ToLower(), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "+"), String.Empty);
                id = id.Replace(this.LimpiarCadena(marca.ToLower(), "-"), String.Empty);
            }

            //Tratamiento para adicionar marca
            if (!String.IsNullOrEmpty(id))
            {
                var codMarcaProvider = this.GetMarcaProvider("ALAMAULA", marca);
                id = String.Format("{0}@{1}", codMarcaProvider, id);
            }

            //Armamos insert
            this.InsertsCI.Add(String.Format(KSQL_INSERT_CI, "ALAMAULA", this.GetCodCatalogo(catalogo), id, value));
            if (!String.IsNullOrEmpty(marca))
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "ALAMAULA", this.GetCodCatalogo(catalogo), id, String.Format("{0}@{1}", this.LimpiarCadena(marca), valueSitio)));
            }
            else
            {
                this.InsertsCIV.Add(String.Format(KSQL_INSERT_CIV, "ALAMAULA", this.GetCodCatalogo(catalogo), id, valueSitio));
            }
        }
        #endregion

        #region Helpers
        private String GetCodCatalogo(String catalogo)
        {
            switch (catalogo)
            {
                case "Marca":
                    return "MAR";
                case "Modelo":
                    return "MOD";
                case "Provincia":
                    return "PROV";
                case "Color":
                    return "COL";
                case "Combustible":
                    return "COMB";
                case "Transmision":
                    return "TRANS";
                case "Direccion":
                    return "DIR";
                case "Segmento":
                    return "SEG";
                case "Traccion":
                    return "TRAC";
                case "Puertas":
                    return "PTAS";
                case "Orden":
                    return "ORD";
                default:
                    return "";
            }
        }
        private String LimpiarCadena(String input, String separador = "-")
        {
            var retorno = input.ToLower().Trim().Replace(" ", separador);
            Regex a = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex e = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex i = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex o = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex u = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            Regex n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
            retorno = a.Replace(retorno, "a");
            retorno = e.Replace(retorno, "e");
            retorno = i.Replace(retorno, "i");
            retorno = o.Replace(retorno, "o");
            retorno = u.Replace(retorno, "u");
            retorno = n.Replace(retorno, "n");
            return retorno;
        }
        #endregion

        #region Helpers SQL
        private String GetMarcaProvider(String codProvider, String marca)
        {
            var retorno = String.Empty;
            using (var dbContext = new ModelContext())
            {
                var query = String.Format(KSQL_SELECT_MARCA, codProvider, "MAR", this.LimpiarCadena(marca));
                var codMarcaProvider = dbContext.Database.SqlQuery<String>(query).ToList();
                if (codMarcaProvider != null && codMarcaProvider.Count > 0)
                    retorno = codMarcaProvider.First();
            }
            return retorno;
        }
        #endregion
    }
}
