using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class ProfileDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<Profile> list()
        {
            List<Profile> tmp = new List<Profile>();
            cmd = new SqlCommand("USP_PROFILE_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            Profile p = new Profile();
            while (dr.Read())
            {
                p = new Profile()
                {
                    idProfile = dr.GetInt32(0),
                    ProfileName = dr.GetString(1),
                    dateRegister = dr.GetDateTime(2),
                    flag_state = dr.GetInt32(3)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public Profile Read(int id)
        {
            Profile tmp = new Profile();
            cmd = new SqlCommand("USP_PROFILE_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idProfile", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idProfile = dr.GetInt32(0);
                tmp.ProfileName = dr.GetString(1);
                tmp.dateRegister = dr.GetDateTime(2);
                tmp.flag_state = dr.GetInt32(3);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(Profile pro)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_PROFILE_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProfileName", pro.ProfileName);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                register++;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                register = 0;
            }

            return register;
        }
        public int Update(Profile pro)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_PROFILE_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idProfile", pro.idProfile);
                cmd.Parameters.AddWithValue("ProfileName", pro.ProfileName);
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
                cmd = new SqlCommand("USP_PROFILE_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idProfile", id);
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
