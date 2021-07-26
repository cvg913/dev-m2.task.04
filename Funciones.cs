using System;

namespace dev_m2.task._04
{
    public static class Funciones
    {
        public static string TextoSinComilla(string dato){
            return dato.Replace('"',' ').TrimStart().TrimEnd();  
        }

        public static int? EnteroNullSinComilla(string dato){
            var numero = TextoSinComilla(dato);
            int entero = 0;
            if(int.TryParse(numero,out entero))
            {
                return entero;
            }
            else{
                return null;
            }
        }
         public static int EnteroSinComilla(string dato){
            var numero = TextoSinComilla(dato);
            int entero = 0;
            int.TryParse(numero,out entero);
            return entero;
        }

        public static decimal DecimalSinComilla(string dato){
            var numero = TextoSinComilla(dato);
            decimal dc = new decimal(0.0);
            decimal.TryParse(numero,out dc);
            return dc;

        }
        public static decimal? DecimalNullSinComilla(string dato){
            var numero = TextoSinComilla(dato);
            decimal dc = new decimal(0.0);
            if(decimal.TryParse(numero,out dc)){
                return dc;
            }
            else{
                return null;
            }
        }
    }
}
