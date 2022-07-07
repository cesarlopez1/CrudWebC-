using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientesWEBAPP.Models.ViewModels
{
    public class ClienteViewModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "edad")]
        public int Edad { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo electronico")]
        public string Correo { get; set; }

    }
}