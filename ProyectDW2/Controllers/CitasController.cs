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
    public class CitasController : Controller
    {
        CitasBL bl = new CitasBL();
        // GET: Citas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Citas()
        {
            return View();
        }
        [HttpGet]
        public JsonResult List()
        {
            var json = JsonConvert.SerializeObject(bl.list());
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Create(Citas c)
        {
            var json = JsonConvert.SerializeObject(bl.Create(c));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(Citas c)
        {
            var json = JsonConvert.SerializeObject(bl.Update(c));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            var json = JsonConvert.SerializeObject(bl.Delete(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListCarrito(int id)
        {
            var json = JsonConvert.SerializeObject(bl.listCar(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Comprar(int id)
        {
            var json = JsonConvert.SerializeObject(bl.Buy(id));
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}