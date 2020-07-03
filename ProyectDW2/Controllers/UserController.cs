using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace ProyectDW2.Controllers
{
    public class UserController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;
        UserBL bl = new UserBL();
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
                User n = new User();
                n.idUser = dr.GetInt32(0);
                n.PersonFirstName = dr.GetString(1);
                n.PersonSurName = dr.GetString(2);


                Session["idUser"] = n.idUser;
                Session["PersonFirstName"] = n.PersonFirstName;
                Session["PersonSurName"] = n.PersonSurName;
                cn.Close();
                return RedirectToAction("Index");
            }
            else
            {
                cn.Close();
                return RedirectToAction("Login");
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
            var json = JsonConvert.SerializeObject(bl.list());
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Read(int id)
        {
            var json = JsonConvert.SerializeObject(bl.Read(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Create(User u)
        {
            var json = JsonConvert.SerializeObject(bl.Create(u));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(User u)
        {
            var json = JsonConvert.SerializeObject(bl.Update(u));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var json = JsonConvert.SerializeObject(bl.Delete(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListUserPerf(int id)
        {
            var json = JsonConvert.SerializeObject(bl.listPerf(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult listDocEspecialidad(int id)
        {
            var json = JsonConvert.SerializeObject(bl.listDocEspecialidad(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}