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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ApplicacionWebp.Controllers
{
    public class ReportesController : Controller
    {


        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export_Solicitud_Servicio()
        {

            ReportDocument rd = new ReportDocument();

            rd.Load(Path.Combine(Server.MapPath("~/Reports/Solicitud_Servicio.rpt")));


            SqlSP spSql = new SqlSP();
            DataTable ServiciosGeneral = spSql.spGetData("[dbo].[rptFacturacionSolicitud]", new string[] { "@Accion:DetalledeFacturaId", "@idBA:" + 838 });
            List<Facturacion_Solicitud_Detalle> listServiciosGeneral = ServiciosGeneral.AsEnumerable().Select(x => new Facturacion_Solicitud_Detalle
            {
                Id = (int)x["Id"]
                ,Facturacion_SolicitudId = Convert.IsDBNull(x["Id"]) ? 0 : (int)x["Id"]
                ,Programa_Circulacion_CompletoITEM = Convert.IsDBNull(x["Programa_Circulacion_CompletoITEM"]) ? "" : (string)x["Programa_Circulacion_CompletoITEM"]
                ,Titulo = Convert.IsDBNull(x["TITULO"]) ? "" : (string)x["TITULO"]
                ,Item_Facturacion = Convert.IsDBNull(x["Item_Facturacion"]) ? "" : (string)x["Item_Facturacion"]
                ,Servicio = Convert.IsDBNull(x["Servicio"]) ? "" : (string)x["Servicio"]
                ,Cantidad_Solicitada_Solicitante = Convert.IsDBNull(x["Cantidad_Solicitada_Solicitante"]) ? 0 : (int)x["Cantidad_Solicitada_Solicitante"]
                ,Cantidad_Solicitada_Confirmada = Convert.IsDBNull(x["Cantidad_Solicitada_Confirmada"]) ? 0 : (int)x["Cantidad_Solicitada_Confirmada"]
                ,Costo_Unidad_Solicitante = Convert.IsDBNull(x["Costo_Unidad_Solicitante"]) ? 0.0 : Math.Round((double)x["Costo_Unidad_Solicitante"], 3)
                ,Costo_Unidad_Confirmada = Convert.IsDBNull(x["Costo_Unidad_Confirmada"]) ? 0.0 : Math.Round((double)x["Costo_Unidad_Confirmada"], 3)
                ,Cantidad_Ejecutada = Convert.IsDBNull(x["Cantidad_Ejecutada"]) ? 0 : (int)x["Cantidad_Ejecutada"]
                ,Creation_Timestamp = Convert.IsDBNull(x["Creation_Timestamp"]) ? DateTime.Parse("") : (DateTime)x["Creation_Timestamp"]
                ,Nombre = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]
                ,CostoUnitario_SinIVA = Convert.IsDBNull(x["CostoUnitario_SinIVA"]) ? 0.0 : Math.Round((double)x["CostoUnitario_SinIVA"], 3)
                ,Concepto_De_Facturacion = Convert.IsDBNull(x["Concepto_De_Facturacion"]) ? 0 : (int)x["Concepto_De_Facturacion"]
                ,Concepto_A_Facturar = Convert.IsDBNull(x["Concepto_A_Facturar"]) ? 0 : (int)x["Concepto_A_Facturar"]
                ,Importe_Antes_IVA = Convert.IsDBNull(x["Importes_Antes_IVA"]) ? 0 : (double)x["Importes_Antes_IVA"]
                ,Nombre_Elaboro = Convert.IsDBNull(x["Nombre_Elaboro"]) ? "" : (string)x["Nombre_Elaboro"]
                


            }).ToList();


            DataTable ServiciosGeneralSum = spSql.spGetData("[dbo].[rptFacturacionSolicitud]", new string[] { "@Accion:GetSum", "@idBA:" + 838 });
            List<Facturacion_Solicitud_Detalle> listServiciosGeneralSum = ServiciosGeneralSum.AsEnumerable().Select(x => new Facturacion_Solicitud_Detalle
            {
               TotalImporte = Convert.IsDBNull(x["TotalImporte"]) ? 0.0 : Math.Round((double)x["TotalImporte"], 3)
            }).ToList();

            listServiciosGeneral = listServiciosGeneral.Concat(listServiciosGeneralSum).ToList();

            rd.SetDataSource(listServiciosGeneral);
            Response.ClearContent();
            Response.Buffer = false;
            Response.ClearHeaders();

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);

                return File(stream, "application/pdf", "Solicitud_Servicio_" + 838 + ".pdf");

            }
            catch (Exception)
            {
                //return null;
                throw;
            }

        }



    }


}