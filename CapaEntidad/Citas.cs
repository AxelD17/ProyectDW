using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Citas
    {
        public int idDocumento { get; set; }
        public string correlaltivo { get; set; }
        public int idTipoDoc { get; set; }
        public int idCliente { get; set; }
        public DateTime dateEmision { get; set; }
        public int idProDisponibilidad { get; set; }
        public int idEspecialidad { get; set; }
        public int idDoctor { get; set; }
        public DateTime fechaAtencion { get; set; }
        public string horaAtencio { get; set; }
        public int idDetalleDoc { get; set; }
        public string precio { get; set; }
        public User cliente { get; set; }
        public User doctor { get; set; }
        public Especialidad especialidad { get; set; }
    }
}
