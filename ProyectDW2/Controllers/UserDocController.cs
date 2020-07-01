using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectDW2.Controllers
{
    public class UserDocController : Controller
    {
        UserDocBL bl = new UserDocBL();
        // GET: UserDoc
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
        public JsonResult Create(UserDoc u)
        {
            var json = JsonConvert.SerializeObject(bl.Create(u));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(UserDoc u)
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
    }
}