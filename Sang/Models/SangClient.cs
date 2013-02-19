using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class SangClient
    {
        public int SangClientID { get; set; }
        public int SangUserId { get; set; }
        public int HospitalId { get; set; }
        
        [Required(ErrorMessage="Requerido")]
        [Display(Name = "Nombres")]
        public string UserName { get; set; }

        //Datos
        //Mayores de edad
        [Required(ErrorMessage="Requerido")]
        [DisplayName("Apellido Paterno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [DisplayName("Apellido Materno")]
        public string LastName { get; set; }

        [DisplayName("Nombre completo")]
        public string CompleteName { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [DisplayName("Fecha de nacimiento")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [DisplayName("Genero")]
        public string Gender { get; set; }

        [DisplayName("Usuarios del colchón")]
        public int? nMattressUsers { get; set; }
        
        public int? Disorder1 { get; set; }
        public int? Disorder2 { get; set; }
        public int? Disorder3 { get; set; }
        public int? Disorder4 { get; set; }
        public int? Disorder5 { get; set; }
        public int? Disorder6 { get; set; }
        public int? Disorder7 { get; set; }
        public int? Disorder8 { get; set; }

        [DisplayName("Resultado menor de edad")]
        public int? CuestionaryResult { get; set; }

        [DisplayName("Email alterno")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Introduzca un email válido")]
        public string SecondaryEmail { get; set; }

        [DisplayName("Dirección")]
        public string Address { get; set; }

        [DisplayName("Colonia")]
        public string Colony { get; set; }

        [DisplayName("Código Postal")]
        public string PostalCode { get; set; }

        [DisplayName("Delegacion/Municipio")]
        public string Township { get; set; }

        [DisplayName("Estado")]
        public string ShortState { get; set; }

        [StringLength(3, ErrorMessage="La lada solo debe tener 3 caracteres")]
        [DisplayName("Lada")]
        public string Lada { get; set; }

        [DisplayName("Teléfono de casa")]
        public long? HomePhone { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [DisplayName("Teléfono movil")]
        public long?  MovilPhone { get; set; }

        //[DisplayName("¿Menor o mayor de edad?")]
        //public string UserType { get; set; }

        [DisplayName("Suscribirse a nuestro Newsletter")]
        public bool NewsLetter { get; set; }

        [Required(ErrorMessage="Requerido")]
        [DisplayName("He leído y acepto los Términos del Aviso de privacidad")]
        public bool PrivacyNotice { get; set; }

        //Coupon Data
        [DisplayName("Coupon number")]
        public string CouponNumber { get; set; }

        [DisplayName("Coupon Url")]
        public string CouponUrl { get; set; }

        [DisplayName("Sleeping Image result")]
        public string SleepingImageUrl { get; set; }

        [DisplayName("Sleeping Image Activo")]
        public bool SleepingImageIsActived { get; set; }

        public virtual SangUser SangUser { get; set; }

        [DisplayName("Seleccione un hospital")]
        public virtual Hospital Hospital { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}