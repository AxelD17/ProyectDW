using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class User
    {
        public int idUser { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonSurName { get; set; }
        public string PersonLastName { get; set; }
        public DateTime PersonBirthday { get; set; }
        public int PersonNumber { get; set; }
        public string PersonEmail { get; set; }
        public int idPersonDoc { get; set; }
        public string NumberDoc { get; set; }
        public int idPersonSex { get; set; }
        public int idDistrict { get; set; }
        public int idProfile { get; set; }
        public Profile profile { get; set; }
        public DateTime dateRegister { get; set; }
        public int flag_state { get; set; }
    }
}
