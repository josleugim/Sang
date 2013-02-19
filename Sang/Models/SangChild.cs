using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class SangChild
    {
        public int SangChildID { get; set; }
        public int SangClientId { get; set; }

        [Required(ErrorMessage="Requerido")]
        [Display(Name="Nombres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [DisplayName("Apellido Paterno")]
        public string FirstName { get; set; }

        [DisplayName("Apellido Materno")]
        public string LastName { get; set; }

        [DisplayName("Nombre completo")]
        public string CompleteName { get; set; }

        [DisplayName("Fecha de nacimiento")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Resultado")]
        public int? CuestionaryResult { get; set; }

        //Coupon Data
        [DisplayName("Coupon number")]
        public string CouponNumber { get; set; }

        [DisplayName("Coupon Url")]
        public string CouponUrl { get; set; }

        [DisplayName("Sleeping Image result")]
        public string SleepingImageUrl { get; set; }

        public DateTime RegisterDate { get; set; }

        [DisplayName("Tutor")]
        public virtual SangClient SangClient { get; set; }
    }
}