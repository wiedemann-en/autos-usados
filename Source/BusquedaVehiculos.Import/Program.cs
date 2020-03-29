using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaVehiculos.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"C:\Users\EstebanNicolas\Desktop\Autos\SitiosAutos.xlsx";

            //new Process().Execute("Marca", path);
            //new Process().Execute("Provincia", path);
            //new Process().Execute("Color", path);
            //new Process().Execute("Combustible", path);
            //new Process().Execute("Transmision", path);
            //new Process().Execute("Direccion", path);
            //new Process().Execute("Segmento", path);
            //new Process().Execute("Traccion", path);
            //new Process().Execute("Kiloemtraje", path);
            //new Process().Execute("Puertas", path);
            //new Process().Execute("Orden", path);

            var pathModelos = @"C:\Users\EstebanNicolas\Desktop\Autos\Unificados";
            var files = Directory.EnumerateFiles(pathModelos, "*.xlsx");
            foreach (string file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var marca = fileName.Split('_')[1];
                new Process().Execute("Modelo", file, marca);
            }

            //var file = @"C:\Users\EstebanNicolas\Desktop\Autos\Unificados\Modelos_Volkswagen.xlsx";
            //new Process().Execute("Modelo", file, "Volkswagen");

            //var file1 = @"C:\Users\EstebanNicolas\Desktop\Autos\Unificados\Modelos_Renault.xlsx";
            //new Process().Execute("Modelo", file1, "Renault");

        }
    }
}
