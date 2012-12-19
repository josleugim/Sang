using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class ModelMattress
    {
        public int ModelMattressID { get; set; }
        public int CollectionId { get; set; }

        [DisplayName("Modelo del colchón")]
        public string ModelName { get; set; }

        [DisplayName("Tamaño del colchón")]
        public string MattressSize { get; set; }

        [DisplayName("Activo")]
        public Boolean IsActived { get; set; }

        public DateTime RegisterDate { get; set; }
        public virtual Collection Collection { get; set; }
    }
}