using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACI
{
    public class Evento
    {
        public int codigo;
        public int sellos;
        public string nombre;
        public string ponente;
        public string actividad;
        public string fecha;
        public string horarioInicio;
        public string horarioFin;
        public string descripcion;
        public string lugar;

        public int getCodigo()
        {
            int codigo = this.codigo;
            return codigo;
        }
        public int getSellos()
        {
            int sellos = this.sellos;
            return sellos;
        }
        public string getNombre()
        {
            string nombre = this.nombre;
            return nombre;
        }
        public string getPonente()
        {
            string ponente = this.ponente;
            return ponente;
        }
        public string getActividad()
        {
            string actividad = this.actividad;
            return actividad;
        }
        public string getFecha()
        {
            string fecha = this.fecha;
            return fecha;
        }
        public string getHorarioInicio()
        {
            string horarioI = this.horarioInicio;
            return horarioI;
        }
        public string getDescripcion()
        {
            string descripcion = this.descripcion;
            return descripcion;
        }
        public string getLugar()
        {
            string lugar = this.lugar;
            return lugar;
        }

    }
}
