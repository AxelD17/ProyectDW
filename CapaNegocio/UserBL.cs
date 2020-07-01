using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class UserBL
    {
        UserDB userDB = new UserDB();

        public int verify(string userName, string userPass)
        {
            return userDB.verify(userName, userPass);
        }
        public List<User> list()
        {
            return userDB.list();
        }
        public User Read(int id)
        {
            return userDB.Read(id);
        }
        public int Create(User u)
        {
            return userDB.Create(u);
        }
        public int Update(User u)
        {
            return userDB.Update(u);
        }
        public int Delete(int id)
        {
            return userDB.Delete(id);
        }
        public List<User> listPerf(int id)
        {
            return userDB.listPerf(id);
        }
    }
}
