using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DoctorEspecialidad
    {
        public int idDocEspecilidad { get; set; }
        public int idDoctor { get; set; }
        public int idEspecialidad { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
        public User user { get; set; }
        public Especialidad especialidad { get; set; }
    }
}
