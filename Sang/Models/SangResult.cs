using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class SangResult
    {
        public int SangResultId { get; set; }
        public int SangClientId { get; set; }
        //public int SangChildId { get; set; }

        //Resultados de adultos
        public int? Disorder1 { get; set; }
        public int? Disorder2 { get; set; }
        public int? Disorder3 { get; set; }
        public int? Disorder4 { get; set; }
        public int? Disorder5 { get; set; }
        public int? Disorder6 { get; set; }
        public int? Disorder7 { get; set; }
        public int? Disorder8 { get; set; }

        //Resultado de menor de edad
        [DisplayName("Resultado menor de edad")]
        public int? CuestionaryResult { get; set; }

        public virtual SangClient SangClient { get; set; }
        //public virtual SangChild SangChild { get; set; }
    }
}