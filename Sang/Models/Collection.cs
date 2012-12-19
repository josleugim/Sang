using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class Collection
    {
        public int CollectionID { get; set; }

        [Required(ErrorMessage = "Escriba el nombre de la colección")]
        [DisplayName("Nombre de la colección")]
        public string CollectionName { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}