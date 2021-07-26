using System;
using System.Collections.Generic;

namespace dev_m2.task._04
{
    class Program
    {
        static void Main(string[] args)
        {

             string pathEntidades = System.IO.Path.GetFullPath("Archivos/EntidadFederativa.csv");
             string pathMunicipios = System.IO.Path.GetFullPath("Archivos/Municipios.csv");
             string pathLocalidades = System.IO.Path.GetFullPath("Archivos/Localidades.csv");
             
             List<ICargaDatos> archivos = new List<ICargaDatos>();

             archivos.Add(new CargaEntidad(pathEntidades));
             archivos.Add(new CargaMunicipio(pathMunicipios));
             archivos.Add(new CargaLocalidad(pathLocalidades));

             foreach(var archivo in archivos){
                 archivo.CargarDatos();
             }

           
                
        }
    }
}
