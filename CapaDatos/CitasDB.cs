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
    public class CitasDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<Citas> list()
        {
            List<Citas> tmp = new List<Citas>();
            cmd = new SqlCommand("USP_CITA_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            Citas p = new Citas();
            while (dr.Read())
            {
                p = new Citas()
                {
                    correlaltivo = dr.GetString(0),
                    doctor = new User()
                    {
                        PersonFirstName = dr.GetString(1),
                        PersonSurName = dr.GetString(2)
                    },
                    cliente = new User()
                    {
                        PersonFirstName = dr.GetString(3),
                        PersonSurName = dr.GetString(4)
                    },
                    especialidad = new Especialidad()
                    {
                        nombreEspecialidad = dr.GetString(5)
                    },
                    fechaAtencion = dr.GetDateTime(6),
                    horaAtencio = dr.GetString(7),
                    precio = dr.GetString(8)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(Citas c)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_CITA_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente", c.idCliente);
                cmd.Parameters.AddWithValue("idEspecialidad", c.idEspecialidad);
                cmd.Parameters.AddWithValue("idDoctor", c.idDoctor);
                cmd.Parameters.AddWithValue("fechaAtencion", c.fechaAtencion);
                cmd.Parameters.AddWithValue("horaAtencio", c.horaAtencio);
                cmd.Parameters.AddWithValue("precio", c.precio);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    register = dr.GetInt32(0);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                register = 0;
            }

            return register;
        }
        public int Update(Citas c)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_CITA_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDocumento", c.idDocumento);
                cmd.Parameters.AddWithValue("idCliente", c.idCliente);
                cmd.Parameters.AddWithValue("idEspecialidad", c.idEspecialidad);
                cmd.Parameters.AddWithValue("idDoctor", c.idDoctor);
                cmd.Parameters.AddWithValue("fechaAtencion", c.fechaAtencion);
                cmd.Parameters.AddWithValue("horaAtencio", c.horaAtencio);
                cmd.Parameters.AddWithValue("precio", c.precio);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    register = dr.GetInt32(0);
                }
                cn.Close();
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
                cmd = new SqlCommand("USP_CITA_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDetalleDoc", id);
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
        public List<Citas> listCar(int id)
        {
            List<Citas> tmp = new List<Citas>();
            cmd = new SqlCommand("USP_CITA_LIST_CARRITO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idDocumento", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            Citas p = new Citas();
            while (dr.Read())
            {
                p = new Citas()
                {
                    idDetalleDoc = dr.GetInt32(0),
                    doctor = new User()
                    {
                        PersonFirstName = dr.GetString(1),
                        PersonSurName = dr.GetString(2)
                    },
                    especialidad = new Especialidad()
                    {
                        nombreEspecialidad = dr.GetString(3)
                    },
                    fechaAtencion = dr.GetDateTime(4),
                    horaAtencio = dr.GetString(5),
                    precio = dr.GetString(6)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Buy(int id)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_CITA_BUY", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDocumento", id);
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
