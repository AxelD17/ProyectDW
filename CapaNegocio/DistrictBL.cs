using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class DistrictBL
    {
        DistrictDB districtDB = new DistrictDB();

        public List<District> list()
        {
            return districtDB.list();
        }
        public District Read(int id)
        {
            return districtDB.Read(id);
        }
        public int Create(District d)
        {
            return districtDB.Create(d);
        }
        public int Update(District d)
        {
            return districtDB.Update(d);
        }
        public int Delete(int id)
        {
            return districtDB.Delete(id);
        }
    }
}
