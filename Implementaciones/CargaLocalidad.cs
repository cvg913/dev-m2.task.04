using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using dev_m2.task._03.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dev_m2.task._04
{

    public class CargaLocalidad : ICargaDatos
    {

        private string _RutaArchivo { get; set; }

        public CargaLocalidad(string archivo)
        {
            _RutaArchivo = archivo;
        }


        public void CargarDatos(){
            if(!ExistenDatos()){
                var datos = File.ReadAllLines(_RutaArchivo);
     using(var conexion = new ElcoBitContext()){
              //  List<Localidad> listaLoc = new List<Localidad>();
                    foreach(var ln in datos){
                        if(ln.Length > 1){
                            var dato = ln.Split("\",\"");
                            if(dato.Length < 17){
                                continue;
                            }
                            var entidadId =  Funciones.EnteroSinComilla(dato[1]);
                            if( entidadId != 0) {
                            
                                    Localidad item = new Localidad();

                                    item.EntidadId = entidadId;
                                    item.MunicipioId = Funciones.EnteroSinComilla(dato[4]);
                                    item.LocalidadId = Funciones.EnteroSinComilla(dato[6]);
                                    item.Nombre = Funciones.TextoSinComilla(dato[7]);
                                    item.Ambito = Funciones.TextoSinComilla(dato[8]);

                                    item.LatitudDecimal = Funciones.DecimalSinComilla(dato[11]);
                                    item.LongitudDecimal = Funciones.DecimalSinComilla(dato[12]);
                                    item.Altitud = Funciones.EnteroSinComilla(dato[13]);
                                    
                                    item.PoblacionTotal = Funciones.EnteroNullSinComilla(dato[15]);
                                    item.PoblacionMasculina = Funciones.EnteroNullSinComilla(dato[16]);
                                    item.PolacionFemenina = Funciones.EnteroNullSinComilla(dato[17]);                                                                                
                                    
                                    conexion.Localidades.Add(item);

                                }
                            }
                        }
                      
                         conexion.SaveChanges();
      
                       }
               
            }
            else{
                Console.WriteLine("Ya existen datos cargados.");


            }
        }

        public bool ExistenDatos(){
            using(var conexion = new ElcoBitContext()  ){
                var entidades = conexion.Localidades.AsNoTracking().Count();  
                return entidades > 0;             
            }
        }

       
    }

}