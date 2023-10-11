using Discount.Core.Entities;

namespace Discount.Application.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string couponCode);
        Task<Coupon> GetCouponById(int id);
        Task<Coupon> AddDiscount(Coupon entity);
        Task<Coupon> UpdateDiscount(Coupon entity);
    }
}
