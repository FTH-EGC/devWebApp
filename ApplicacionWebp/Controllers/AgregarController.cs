using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicacionWebp.Models.ViewModels;
using ApplicacionWebp.Models;
using Newtonsoft.Json;
using ApplicacionWebp.DataAccess;


namespace ApplicacionWebp.Controllers
{
    public class AgregarController : Controller
    {
        // GET: Agregar
        usuariosEntities db = new usuariosEntities();
        public ActionResult Index()
        {
            
            return View();
        }



        [HttpGet]
        public JsonResult GetInfo()
        {


            DataAccessLayout objDB = new DataAccessLayout();

            return Json(objDB.GetData(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetUsuarioById(int UserId)
        {
            tbl_datos model = db.tbl_datos.Where(d => d.id == UserId).SingleOrDefault();
            string value = string.Empty;

            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }); 

            return Json(value, JsonRequestBehavior.AllowGet);

        }


        public JsonResult SaveDatainDB(ListTablaViewModel model)
        {

            var result = false;
            try
            {

                if (model.Id > 0)
                {
                    tbl_datos usu = db.tbl_datos.SingleOrDefault(d => d.id == model.Id);
                    usu.nombre = model.Nombre;
                    usu.apellido_paterno = model.Apellido_Paterno;
                    usu.apellido_materno = model.Apellido_Materno;
                    usu.edad = model.Edad;
                    usu.isactve = model.isactive;
                    db.SaveChanges();
                    result = true;
                }

            }
            catch (Exception ex) {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}