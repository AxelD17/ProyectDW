
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace ProyectDW2.Controllers
{
    public class ProfileController : Controller
    {
        ProfileBL bl = new ProfileBL();
        // GET: Profile
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
        public JsonResult Create(Profile pro)
        {
            var json = JsonConvert.SerializeObject(bl.Create(pro));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Profile pro)
        {
            var json = JsonConvert.SerializeObject(bl.Update(pro));
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