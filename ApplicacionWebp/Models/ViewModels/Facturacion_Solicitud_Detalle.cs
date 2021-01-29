using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicacionWebp.Models.ViewModels
{
    public class Facturacion_Solicitud_Detalle
    {

        public int Id { get; set; }
        public int Facturacion_SolicitudId { get; set; }
        public DateTime Creation_Timestamp { get; set; }
        public string Nombre { get; set; }
        public string Servicio { get; set; }
        public string Unidad { get; set; }
        public string Item_Facturacion { get; set; }
        public string Titulo { get; set; }
        public double Cantidad_Solicitada_Solicitante { get; set; }
        public double CostoUnitario_SinIVA { get; set; }
        public string Programa_Circulacion_CompletoITEM { get; set; }
        public double Cantidad_Solicitada_Confirmada { get; set; }
        public double Costo_Unidad_Confirmada { get; set; }
        public double Costo_Unidad_Solicitante { get; set; }
        public int Cantidad_Ejecutada { get; set; }
        public int Concepto_De_Facturacion { get; set; }
        public double Concepto_A_Facturar { get; set; }
        public double Importe_Antes_IVA { get; set; }
        public double TotalImporte { get; set; }

    }
}