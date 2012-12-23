using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int ModelMattresstId { get; set; }
        public int WarrantyId { get; set; }

        [DisplayName("Número de factura")]
        public string BillNumber { get; set; }

        [DisplayName("Tamaño del colchón")]
        public string MattressSize { get; set; }

        [DisplayName("Tienda")]
        public string Store { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual Warranty Warranty { get; set; }

        [DisplayName("Modelo del colchón")]
        public virtual ModelMattress ModelMattress { get; set; }
    }
}