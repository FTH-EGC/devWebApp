using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicacionWebp.Models.ViewModels;
using ApplicacionWebp.Models;
using Newtonsoft.Json;
using ApplicacionWebp.DataAccess;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

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

        public ActionResult generarReporte()
        {
            DataAccessLayout objDB = new DataAccessLayout();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport2.rpt"));
            rd.SetDataSource(objDB.GetData().ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {

                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Lista_Usuarios.pdf");
            }catch(Exception ex)
            {
                throw ex;

            }


        }


        public ActionResult GetUsuarioById(int UserId)
        {
            DataAccessLayout objDB = new DataAccessLayout();

            return Json(objDB.GetDataBYID(UserId), JsonRequestBehavior.AllowGet);

        }

        public ActionResult CreateUser(ListTablaViewModel objUsu)
        {


            if (ModelState.IsValid)
            {
                DataAccessLayout objDB = new DataAccessLayout();
                string result = objDB.INSERTDATA(objUsu);
                TempData["userOBJ"] = result;
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Error en la insercion de datos");
                return View();
            }
        }

        public ActionResult UpdateUser(ListTablaViewModel objUsu) 
        {

            if (ModelState.IsValid)
            {
                DataAccessLayout objDB = new DataAccessLayout();
                string result = objDB.UPDATEDATA(objUsu);
                TempData["userOBJ"] = result;
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("", "Error en la Edicion de datos");
                return View();
            }

        }


        public ActionResult DeleteUser(int UserId)
        {
            DataAccessLayout objDB = new DataAccessLayout();
            int result = objDB.DELETE(UserId);

            TempData["userOBJ"] = result;

            ModelState.Clear();

            return RedirectToAction ("index");


        }



    }
}