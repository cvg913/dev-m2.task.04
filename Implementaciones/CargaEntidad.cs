using System;
using System.IO;
using System.Linq;
using dev_m2.task._03.Models;


namespace dev_m2.task._04
{

    public class CargaEntidad : ICargaDatos
    {

        private string _RutaArchivo { get; set; }

        public CargaEntidad(string archivo)
        {
            _RutaArchivo = archivo;
        }


        public void CargarDatos(){
            if(!ExistenDatos()){
                var datos = File.ReadAllLines(_RutaArchivo);
                var contador = 0;
                using(var conexion = new ElcoBitContext()  ){
                foreach(var ln in datos){
                    if(ln.Length>1){
                        var dato = ln.Split(',');
                        var id =  Funciones.EnteroSinComilla(dato[0]);
                        if( id != 0) {
                            
                                EntidaFederativa nuevaEntidad = new EntidaFederativa();
                                nuevaEntidad.EntidadId = id;
                                nuevaEntidad.Nombre = Funciones.TextoSinComilla(dato[1]);;
                                nuevaEntidad.NombreAbreviado = Funciones.TextoSinComilla(dato[2]);
                                nuevaEntidad.PoblacionTotal = Funciones.EnteroSinComilla(dato[3]);
                                nuevaEntidad.PoblacionMasculina = Funciones.EnteroSinComilla(dato[5]);
                                nuevaEntidad.PoblacionFemenina = Funciones.EnteroSinComilla(dato[6]);

                                conexion.EntidaFederativas.Add(nuevaEntidad);
                               
                                contador ++;
                            }
                        }
                    }
                conexion.SaveChanges();
                }
                Console.WriteLine($"{contador} datos cargados exitosamente");
            }
            else{
                Console.WriteLine("Ya existen datos cargados.");
            }
        }

        public bool ExistenDatos(){
            using(var conexion = new ElcoBitContext()  ){
                var entidades = conexion.EntidaFederativas.Count();  
                return entidades>0;             
            }
        }

       
    }

}