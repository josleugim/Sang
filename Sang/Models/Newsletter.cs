using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class Newsletter
    {
        public int NewsletterID { get; set; }
        [Required(ErrorMessage = "* Nombre completo requerido")]
        [DisplayName("Nombre completo")]
        public string CompleteName { get; set; }
        [Required(ErrorMessage = "* Email requerido")]
        [DisplayName("Email")]
        public string Email { get; set; }
        public bool? IsActived { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}