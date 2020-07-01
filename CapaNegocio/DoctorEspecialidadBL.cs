using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DoctorEspecialidadBL
    {
        DoctorEspecialidadDB doctorespecialidadDB = new DoctorEspecialidadDB();

        public List<DoctorEspecialidad> list()
        {
            return doctorespecialidadDB.list();
        }
        public DoctorEspecialidad Read(int id)
        {
            return doctorespecialidadDB.Read(id);
        }
        public int Create(DoctorEspecialidad d)
        {
            return doctorespecialidadDB.Create(d);
        }
        public int Update(DoctorEspecialidad d)
        {
            return doctorespecialidadDB.Update(d);
        }
        public int Delete(int id)
        {
            return doctorespecialidadDB.Delete(id);
        }
    }
}
