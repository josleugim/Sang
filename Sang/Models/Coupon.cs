using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sang.Models
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public int SangUserId { get; set; }

        [Required(ErrorMessage = "Escriba un cupón")]
        [DisplayName("Cupón")]
        public string CouponNumber { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual SangUser SangUser { get; set; }
    }
}