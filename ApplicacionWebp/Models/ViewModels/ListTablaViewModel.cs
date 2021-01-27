using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicacionWebp.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Edad { get; set; }
        public bool isactive { get; set; }

    }
}