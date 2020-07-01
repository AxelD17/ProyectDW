using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Especialidad
    {
        public int idEspecialidad { get; set; }
        public string nombreEspecialidad { get; set; }
        public string descripcionEspecialidad { get; set; }
        public decimal precioEspecialidad { get; set; }
        public string duracionEspecialidad { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
    }
}
