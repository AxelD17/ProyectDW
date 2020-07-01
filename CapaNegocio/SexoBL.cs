using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SexoBL
    {
        SexoDB SexoDB = new SexoDB();

        public List<Sexo> list()
        {
            return SexoDB.list();
        }
        public Sexo Read(int id)
        {
            return SexoDB.Read(id);
        }
        public int Create(Sexo s)
        {
            return SexoDB.Create(s);
        }
        public int Update(Sexo s)
        {
            return SexoDB.Update(s);
        }
        public int Delete(int id)
        {
            return SexoDB.Delete(id);
        }
    }
}
