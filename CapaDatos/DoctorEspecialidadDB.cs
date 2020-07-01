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
    public class DoctorEspecialidadDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<DoctorEspecialidad> list()
        {
            List<DoctorEspecialidad> tmp = new List<DoctorEspecialidad>();
            cmd = new SqlCommand("USP_DOCTOR_ESPECIALIDAD_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            DoctorEspecialidad p = new DoctorEspecialidad();
            while (dr.Read())
            {
                p = new DoctorEspecialidad()
                {
                    idDocEspecilidad = dr.GetInt32(0),
                    idDoctor = dr.GetInt32(1),
                    idEspecialidad = dr.GetInt32(2),
                    dateRegister = dr.GetDateTime(3),
                    flag_state = dr.GetInt32(4),
                    user = new User()
                    {
                        PersonFirstName = dr.GetString(5),
                        PersonSurName = dr.GetString(6),
                    },
                    especialidad = new Especialidad()
                    {
                        nombreEspecialidad = dr.GetString(7)
                    }
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public DoctorEspecialidad Read(int id)
        {
            DoctorEspecialidad tmp = new DoctorEspecialidad();
            cmd = new SqlCommand("USP_DOCTOR_ESPECIALIDAD_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idDocEspecilidad", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idDocEspecilidad = dr.GetInt32(0);
                tmp.idDoctor = dr.GetInt32(1);
                tmp.idEspecialidad = dr.GetInt32(2);
                tmp.dateRegister = dr.GetDateTime(3);
                tmp.flag_state = dr.GetInt32(4);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(DoctorEspecialidad d)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_DOCTOR_ESPECIALIDAD_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDoctor", d.idDoctor);
                cmd.Parameters.AddWithValue("idEspecialidad", d.idEspecialidad);
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
        public int Update(DoctorEspecialidad d)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_DOCTOR_ESPECIALIDAD_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDocEspecilidad", d.idDocEspecilidad);
                cmd.Parameters.AddWithValue("idDoctor", d.idDoctor);
                cmd.Parameters.AddWithValue("idEspecialidad", d.idEspecialidad);
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
                cmd = new SqlCommand("USP_DOCTOR_ESPECIALIDAD_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDocEspecilidad", id);
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
    }
}
