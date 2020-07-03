using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CitasBL
    {
        CitasDB citasDB = new CitasDB();

        public List<Citas> list()
        {
            return citasDB.list();
        }
        public int Create(Citas c)
        {
            return citasDB.Create(c);
        }
        public int Update(Citas c)
        {
            return citasDB.Update(c);
        }
        public int Delete(int id)
        {
            return citasDB.Delete(id);
        }
        public List<Citas> listCar(int id)
        {
            return citasDB.listCar(id);
        }
        public int Buy(int id)
        {
            return citasDB.Buy(id);
        }
    }
}
