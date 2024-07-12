using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class Coupon
    {
        public int CouponID { get; set; }
        public string? Code { get; set; }
        public int DiscountID { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
