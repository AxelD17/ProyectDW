using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UserDocBL
    {
        UserDocDB UserDocDB = new UserDocDB();

        public List<UserDoc> list()
        {
            return UserDocDB.list();
        }
        public UserDoc Read(int id)
        {
            return UserDocDB.Read(id);
        }
        public int Create(UserDoc d)
        {
            return UserDocDB.Create(d);
        }
        public int Update(UserDoc d)
        {
            return UserDocDB.Update(d);
        }
        public int Delete(int id)
        {
            return UserDocDB.Delete(id);
        }
    }
}
