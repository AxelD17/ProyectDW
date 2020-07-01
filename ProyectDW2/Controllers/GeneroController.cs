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
    public class GeneroController : Controller
    {
        SexoBL bl = new SexoBL();
        // GET: Sexo
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
        public JsonResult Create(Sexo s)
        {
            var json = JsonConvert.SerializeObject(bl.Create(s));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Sexo s)
        {
            var json = JsonConvert.SerializeObject(bl.Update(s));
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