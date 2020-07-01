using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Profile
    {
        public int idProfile { get; set; }
        public string ProfileName { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
    }
}
