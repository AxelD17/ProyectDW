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
    public class UserDB
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        public int verify(string userName, string userPass)
        {
            int rpta = 0;
            try
            {
                cmd = new SqlCommand("USP_LOGIN_VERIFY", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("userName", userName);
                cmd.Parameters.AddWithValue("userPass", userPass);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cn.Close();
                    rpta++;
                }
                else
                {
                    cn.Close();
                    rpta = 0;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                rpta = 0;
            }
            return rpta;

        }
        public List<User> list()
        {
            List<User> tmp = new List<User>();
            cmd = new SqlCommand("USP_USER_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            dr = cmd.ExecuteReader();
            User p = new User();
            while (dr.Read())
            {
                p = new User()
                {
                    idUser = dr.GetInt32(0),
                    PersonFirstName = dr.GetString(1),
                    PersonSurName = dr.GetString(2),
                    PersonLastName = dr.GetString(3),
                    NumberDoc = dr.GetString(4),
                    PersonNumber = dr.GetInt32(5),
                    PersonEmail = dr.GetString(6),
                    userName = dr.GetString(7),
                    idProfile = dr.GetInt32(8),
                    profile = new Profile() { 
                        ProfileName = dr.GetString(9)
                    },                        
                    dateRegister = dr.GetDateTime(10),
                    flag_state = dr.GetInt32(11)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public User Read(int id)
        {
            User tmp = new User();
            cmd = new SqlCommand("USP_USER_READ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idUser", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tmp.idUser = dr.GetInt32(0);
                tmp.PersonFirstName = dr.GetString(1);
                tmp.PersonSurName = dr.GetString(2);
                tmp.PersonLastName = dr.GetString(3);
                tmp.PersonBirthday = dr.GetDateTime(4);
                tmp.PersonNumber = dr.GetInt32(5);
                tmp.PersonEmail = dr.GetString(6);
                tmp.idPersonDoc = dr.GetInt32(7);
                tmp.NumberDoc = dr.GetString(8);
                tmp.idPersonSex = dr.GetInt32(9);
                tmp.idDistrict = dr.GetInt32(10);
                tmp.userName = dr.GetString(11);
                tmp.userPass = dr.GetString(12);
                tmp.idProfile = dr.GetInt32(13);
                tmp.dateRegister = dr.GetDateTime(14);
                tmp.flag_state = dr.GetInt32(15);
            }
            dr.Close();
            cn.Close();
            return tmp;
        }
        public int Create(User u)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_USER_CREATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("userName", u.userName);
                cmd.Parameters.AddWithValue("userPass", u.userPass);
                cmd.Parameters.AddWithValue("PersonFirstName", u.PersonFirstName);
                cmd.Parameters.AddWithValue("PersonSurName", u.PersonSurName);
                cmd.Parameters.AddWithValue("PersonLastName", u.PersonLastName);
                cmd.Parameters.AddWithValue("PersonBirthday", u.PersonBirthday);
                cmd.Parameters.AddWithValue("PersonNumber", u.PersonNumber);
                cmd.Parameters.AddWithValue("PersonEmail", u.PersonEmail);
                cmd.Parameters.AddWithValue("idPersonDoc", u.idPersonDoc);
                cmd.Parameters.AddWithValue("NumberDoc", u.NumberDoc);
                cmd.Parameters.AddWithValue("idPersonSex", u.idPersonSex);
                cmd.Parameters.AddWithValue("idDistrict", u.idDistrict);
                cmd.Parameters.AddWithValue("idProfile", u.idProfile);
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
        public int Update(User u)
        {
            int register = 0;
            try
            {
                cmd = new SqlCommand("USP_USER_UPDATE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idUser", u.idUser);
                cmd.Parameters.AddWithValue("userName", u.userName);
                cmd.Parameters.AddWithValue("userPass", u.userPass);
                cmd.Parameters.AddWithValue("PersonFirstName", u.PersonFirstName);
                cmd.Parameters.AddWithValue("PersonSurName", u.PersonSurName);
                cmd.Parameters.AddWithValue("PersonLastName", u.PersonLastName);
                cmd.Parameters.AddWithValue("PersonBirthday", u.PersonBirthday);
                cmd.Parameters.AddWithValue("PersonNumber", u.PersonNumber);
                cmd.Parameters.AddWithValue("PersonEmail", u.PersonEmail);
                cmd.Parameters.AddWithValue("idPersonDoc", u.idPersonDoc);
                cmd.Parameters.AddWithValue("NumberDoc", u.NumberDoc);
                cmd.Parameters.AddWithValue("idPersonSex", u.idPersonSex);
                cmd.Parameters.AddWithValue("idDistrict", u.idDistrict);
                cmd.Parameters.AddWithValue("idProfile", u.idProfile);
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
                cmd = new SqlCommand("USP_USER_DELETE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idUser", id);
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
        public List<User> listPerf(int id)
        {
            List<User> tmp = new List<User>();
            cmd = new SqlCommand("USP_USER_LIST_PROFILE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idProfile", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            User p = new User();
            while (dr.Read())
            {
                p = new User()
                {
                    idUser = dr.GetInt32(0),
                    PersonFirstName = dr.GetString(1),
                    PersonSurName = dr.GetString(2),
                    PersonLastName = dr.GetString(3)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
        public List<User> listDocEspecialidad(int id)
        {
            List<User> tmp = new List<User>();
            cmd = new SqlCommand("USP_ESPECIALIDAD_LIST_USER", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idEspecialidad", id);
            cn.Open();
            dr = cmd.ExecuteReader();
            User p = new User();
            while (dr.Read())
            {
                p = new User()
                {
                    idUser = dr.GetInt32(0),
                    PersonFirstName = dr.GetString(1),
                    PersonSurName = dr.GetString(2)
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            return tmp;
        }
    }
}
