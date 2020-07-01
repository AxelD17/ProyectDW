using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EspecialidadBL
    {
        EspecialidadDB especialidadDB = new EspecialidadDB();
        public List<Especialidad> list()
        {
            return especialidadDB.list();
        }
        public Especialidad Read(int id)
        {
            return especialidadDB.Read(id);
        }
        public int Create(Especialidad e)
        {
            return especialidadDB.Create(e);
        }
        public int Update(Especialidad e)
        {
            return especialidadDB.Update(e);
        }
        public int Delete(int id)
        {
            return especialidadDB.Delete(id);
        }
        public List<Especialidad> listEspe(int id)
        {
            return especialidadDB.listEspe(id);
        }
        public List<Especialidad> listEspe2(int id, int es)
        {
            return especialidadDB.listEspe2(id, es);
        }
    }
}
