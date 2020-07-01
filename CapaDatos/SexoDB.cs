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
    public class SexoDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<Sexo> list()
        {
            List<Sexo> tmp = new List<Sexo>();
            cmd = new SqlCommand("USP_Sexo_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            Sexo p = new Sexo();
            while (dr.Read())
            {
                p = new Sexo()
                {
                    idSex = dr.GetInt32(0),
                    SexName = dr.GetString(1),
                    dateRegister = dr.GetDateTime(2),
                    flag_state = dr.GetInt32(3)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public Sexo Read(int id)
        {
            Sexo tmp = new Sexo();
            cmd = new SqlCommand("USP_Sexo_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idSex", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idSex = dr.GetInt32(0);
                tmp.SexName = dr.GetString(1);
                tmp.dateRegister = dr.GetDateTime(2);
                tmp.flag_state = dr.GetInt32(3);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(Sexo s)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_Sexo_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("SexName", s.SexName);
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
        public int Update(Sexo s)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_Sexo_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idSex", s.idSex);
                cmd.Parameters.AddWithValue("SexName", s.SexName);
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
                cmd = new SqlCommand("USP_Sexo_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idSex", id);
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
