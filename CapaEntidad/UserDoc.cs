using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class UserDoc
    {
        public int idUserDoc { get; set; }
        public string DocName { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
    }
}
