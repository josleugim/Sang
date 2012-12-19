using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class Warranty
    {
        public int WarrantyID { get; set; }
        public int? SangClientId { get; set; }

        [DisplayName("Garantía")]
        public string WarrantyCode { get; set; }

        public int NAttempts { get; set; }

        [DisplayName("Activa")]
        public Boolean IsActived { get; set; }

        [DisplayName("Fecha de expiración")]
        public DateTime ExpirationDate { get; set; }

        public DateTime RegisterDate { get; set; }

        [DisplayName("Cliente")]
        public virtual SangClient SangClient { get; set; }
    }
}