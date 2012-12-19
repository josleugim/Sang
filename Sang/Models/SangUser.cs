using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class SangUser
    {
        public SangUser()
        {
            if (this.SecureCode == Guid.Empty) this.SecureCode = Guid.NewGuid();
        }

        public int SangUserID { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [DisplayName("Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ingresa un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage="La contraseña es requerida")]
        [DisplayName("Contraseña")]
        public string Pass { get; set; }

        [DisplayName("Código de seguridad")]
        public Guid SecureCode { get; set; }

        public string tempWarranty { get; set; }

        [DisplayName("Activo")]
        public bool IsActived { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}