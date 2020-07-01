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
    public class UserDocDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public List<UserDoc> list()
        {
            List<UserDoc> tmp = new List<UserDoc>();
            cmd = new SqlCommand("USP_USER_DOC_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            UserDoc p = new UserDoc();
            while (dr.Read())
            {
                p = new UserDoc()
                {
                    idUserDoc = dr.GetInt32(0),
                    DocName = dr.GetString(1),
                    dateRegister = dr.GetDateTime(2),
                    flag_state = dr.GetInt32(3)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public UserDoc Read(int id)
        {
            UserDoc tmp = new UserDoc();
            cmd = new SqlCommand("USP_USER_DOC_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idUserDoc", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idUserDoc = dr.GetInt32(0);
                tmp.DocName = dr.GetString(1);
                tmp.dateRegister = dr.GetDateTime(2);
                tmp.flag_state = dr.GetInt32(3);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(UserDoc pro)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_USER_DOC_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DocName", pro.DocName);
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
        public int Update(UserDoc pro)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_USER_DOC_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idUserDoc", pro.idUserDoc);
                cmd.Parameters.AddWithValue("DocName", pro.DocName);
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
                cmd = new SqlCommand("USP_USER_DOC_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idUserDoc", id);
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
