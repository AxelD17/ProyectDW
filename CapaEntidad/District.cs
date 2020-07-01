using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class District
    {
        public int idDistrict { get; set; }
        public string DistrictName { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
    }
}
