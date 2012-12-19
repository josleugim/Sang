using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class Hospital
    {
        public int HospitalID { get; set; }

        [DisplayName("Nombre del hospital")]
        public string HospitalName { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}