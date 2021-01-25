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