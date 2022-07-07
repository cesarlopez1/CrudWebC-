using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientesWEBAPP.Models.ViewModels
{
    public class ListClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }

    }
}