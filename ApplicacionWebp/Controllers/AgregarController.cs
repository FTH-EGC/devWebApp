using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicacionWebp.Models.ViewModels;
using ApplicacionWebp.Models;

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


        public JsonResult GetData()
        {
            List<ListTablaViewModel> lst;
            lst = (from d in db.tbl_datos
                   select new ListTablaViewModel
                   {
                       Id = d.id,
                       Nombre = d.nombre,
                       Apellido_Paterno = d.apellido_paterno,
                       Apellido_Materno = d.apellido_materno,
                       Edad = d.edad,
                       isactive = d.isactve
                   }).ToList();


            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}