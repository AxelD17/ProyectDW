using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Sexo
    {
        public int idSex { get; set; }
        public string SexName { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
    }
}
