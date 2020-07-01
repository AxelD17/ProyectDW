using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EspecialidadDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<Especialidad> list()
        {
            List<Especialidad> tmp = new List<Especialidad>();
            cmd = new SqlCommand("USP_ESPECIALIDAD_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            Especialidad p = new Especialidad();
            while (dr.Read())
            {
                p = new Especialidad()
                {
                    idEspecialidad = dr.GetInt32(0),
                    nombreEspecialidad = dr.GetString(1),
                    descripcionEspecialidad = dr.GetString(2),
                    precioEspecialidad = dr.GetDecimal(3),
                    duracionEspecialidad = dr.GetString(4),
                    dateRegister = dr.GetDateTime(5),
                    flag_state = dr.GetInt32(6)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public Especialidad Read(int id)
        {
            Especialidad tmp = new Especialidad();
            cmd = new SqlCommand("USP_ESPECIALIDAD_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idEspecialidad", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idEspecialidad = dr.GetInt32(0);
                tmp.nombreEspecialidad = dr.GetString(1);
                tmp.descripcionEspecialidad = dr.GetString(2);
                tmp.precioEspecialidad = dr.GetDecimal(3);
                tmp.duracionEspecialidad = dr.GetString(4);
                tmp.dateRegister = dr.GetDateTime(5);
                tmp.flag_state = dr.GetInt32(6);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(Especialidad e)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_ESPECIALIDAD_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nombreEspecialidad", e.nombreEspecialidad);
                cmd.Parameters.AddWithValue("descripcionEspecialidad", e.descripcionEspecialidad);
                cmd.Parameters.AddWithValue("precioEspecialidad", e.precioEspecialidad);
                cmd.Parameters.AddWithValue("duracionEspecialidad", e.duracionEspecialidad);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                register++;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                register = 0;
            }

            return register;
        }
        public int Update(Especialidad e)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_ESPECIALIDAD_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idEspecialidad", e.idEspecialidad);
                cmd.Parameters.AddWithValue("nombreEspecialidad", e.nombreEspecialidad);
                cmd.Parameters.AddWithValue("descripcionEspecialidad", e.descripcionEspecialidad);
                cmd.Parameters.AddWithValue("precioEspecialidad", e.precioEspecialidad);
                cmd.Parameters.AddWithValue("duracionEspecialidad", e.duracionEspecialidad);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                register++;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                register = 0;
            }

            return register;
        }
        public int Delete(int id)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_ESPECIALIDAD_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idEspecialidad", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                register++;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                register = 0;
            }

            return register;
        }
        public List<Especialidad> listEspe(int id)
        {
            List<Especialidad> tmp = new List<Especialidad>();
            cmd = new SqlCommand("USP_ESPECIALIDAD_LIST_USER_NOT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idUser", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            Especialidad p = new Especialidad();
            while (dr.Read())
            {
                p = new Especialidad()
                {
                    idEspecialidad = dr.GetInt32(0),
                    nombreEspecialidad = dr.GetString(1)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public List<Especialidad> listEspe2(int id, int es)
        {
            List<Especialidad> tmp = new List<Especialidad>();
            cmd = new SqlCommand("USP_ESPECIALIDAD_LIST_USER_NOT_IN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idUser", id);
            cmd.Parameters.AddWithValue("idEspecialidad", es);
            cn.Open();
            dr = cmd.ExecuteReader();
            Especialidad p = new Especialidad();
            while (dr.Read())
            {
                p = new Especialidad()
                {
                    idEspecialidad = dr.GetInt32(0),
                    nombreEspecialidad = dr.GetString(1)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
    }
}
