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
    public class EspecialidadController : Controller
    {
        EspecialidadBL bl = new EspecialidadBL();
        // GET: Especialidad
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
        public JsonResult Create(Especialidad e)
        {
            var json = JsonConvert.SerializeObject(bl.Create(e));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Especialidad e)
        {
            var json = JsonConvert.SerializeObject(bl.Update(e));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var json = JsonConvert.SerializeObject(bl.Delete(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult listEspe(int id)
        {
            var json = JsonConvert.SerializeObject(bl.listEspe(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult listEspe2(int id, int es)
        {
            var json = JsonConvert.SerializeObject(bl.listEspe2(id, es));
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}