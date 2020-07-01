using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class ProfileBL
    {
        ProfileDB profileDB = new ProfileDB();

        public List<Profile> list()
        {
            return profileDB.list();
        }
        public Profile Read(int id)
        {
            return profileDB.Read(id);
        }
        public int Create(Profile pro)
        {
            return profileDB.Create(pro);
        }
        public int Update(Profile pro)
        {
            return profileDB.Update(pro);
        }
        public int Delete(int id)
        {
            return profileDB.Delete(id);
        }
    }
}
