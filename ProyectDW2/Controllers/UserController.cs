using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using Newtonsoft.Json;

namespace ProyectDW2.Controllers
{
    public class UserController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;

        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verify(User u)
        {
            cmd = new SqlCommand("USP_LOGIN_VERIFY", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userName", u.userName);
            cmd.Parameters.AddWithValue("@userPass", u.userPass);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cn.Close();
                return RedirectToAction("Login");
            }
            else
            {
                cn.Close();
                return RedirectToAction("Login0");
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult List()
        {
            List<User> tmp = new List<User>();
            cmd = new SqlCommand("USP_LOGIN_LIST", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            User p = new User();
            while (dr.Read())
            {
                p = new User()
                {
                    idUser = dr.GetInt32(0),
                    PersonFirstName = dr.GetString(1),
                    PersonSurName = dr.GetString(2),
                    PersonLastName = dr.GetString(3),
                    PersonBirthday = dr.GetDateTime(4),
                    PersonNumber = dr.GetInt32(5),
                    PersonEmail = dr.GetString(6),
                    idPersonDoc = dr.GetInt32(7),
                    NumberDoc = dr.GetString(8),
                    idPersonSex = dr.GetInt32(9),
                    idDistrict = dr.GetInt32(10),
                    userName = dr.GetString(11),
                    userPass = dr.GetString(12),
                    idProfile = dr.GetInt32(13),
                    dateRegister = dr.GetDateTime(14),
                    flag_state = dr.GetInt32(15),
                };
                tmp.Add(p);
            }

            dr.Close();
            cn.Close();
            var json = JsonConvert.SerializeObject(tmp);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}