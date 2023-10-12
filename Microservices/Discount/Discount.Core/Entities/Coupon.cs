using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discount.Core.Entities
{
    [Table("coupons")]
    public class CouponEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string CouponCode { get; set; }
        
        [Required]
        public string ProductId { get; set; }
        
        [Required]
        public int Amount { get; set; }
        public bool? IsApplied { get; set; }
    }
}