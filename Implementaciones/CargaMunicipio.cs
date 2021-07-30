using System;
using System.IO;
using System.Linq;
using dev_m2.task._03.Models;


namespace dev_m2.task._04
{

    public class CargaMunicipio : ICargaDatos
    {

        private string _RutaArchivo { get; set; }

        public CargaMunicipio(string archivo)
        {
            _RutaArchivo = archivo;
        }


        public void CargarDatos()
        {
            if (!ExistenDatos())
            {
                var datos = File.ReadAllLines("C:/DevFundamentals/dev-m2.task.04/Archivos/Municipios.csv");
                var contador = 0;
                using (var conexion = new ElcoBitContext())
                {
                    foreach (var ln in datos)
                    {
                        if (ln.Length > 1)
                        {
                            var dato = ln.Split(',');
                            var entidadId = Funciones.EnteroSinComilla(dato[0]);
                            if (entidadId != 0)
                            {

                                Municipio item = new Municipio();
                                item.EntidadId = entidadId;
                                item.MunicipioId = Funciones.EnteroSinComilla(dato[3]);
                                item.Nombre = Funciones.TextoSinComilla(dato[4]); ;
                                item.PoblacionTotal = Funciones.EnteroSinComilla(dato[7]);
                                item.PoblacionMasculina = Funciones.EnteroSinComilla(dato[9]);
                                item.PolacionFemenina = Funciones.EnteroSinComilla(dato[10]);
                                conexion.Municipios.Add(item);

                                contador++;
                            }
                        }
                    }
                    conexion.SaveChanges();
                }
                Console.WriteLine($"{contador} datos cargados exitosamente");
            }
            else
            {
                Console.WriteLine("Ya existen datos cargados.");
            }
        }

        public bool ExistenDatos()
        {
            using (var conexion = new ElcoBitContext())
            {
                var entidades = conexion.Municipios.Count();
                return entidades > 0;
            }
        }
    }

}