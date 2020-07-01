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
    public class DistrictDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<District> list()
        {
            List<District> tmp = new List<District>();
            cmd = new SqlCommand("USP_District_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            District p = new District();
            while (dr.Read())
            {
                p = new District()
                {
                    idDistrict = dr.GetInt32(0),
                    DistrictName = dr.GetString(1),
                    dateRegister = dr.GetDateTime(2),
                    flag_state = dr.GetInt32(3)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public District Read(int id)
        {
            District tmp = new District();
            cmd = new SqlCommand("USP_District_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idDistrict", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idDistrict = dr.GetInt32(0);
                tmp.DistrictName = dr.GetString(1);
                tmp.dateRegister = dr.GetDateTime(2);
                tmp.flag_state = dr.GetInt32(3);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(District d)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_District_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DistrictName", d.DistrictName);
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
        public int Update(District d)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_District_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDistrict", d.idDistrict);
                cmd.Parameters.AddWithValue("DistrictName", d.DistrictName);
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
                cmd = new SqlCommand("USP_District_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idDistrict", id);
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
