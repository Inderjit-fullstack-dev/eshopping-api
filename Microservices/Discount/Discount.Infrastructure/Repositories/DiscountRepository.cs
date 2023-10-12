using AutoMapper;
using Discount.Application;
using Discount.Application.Repositories;
using Discount.Core.Entities;
using Discount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DiscountRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Coupon> GetCouponById(int id)
        {
            var result = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Coupon>(result);
        }

        public async Task<Coupon> GetDiscount(string couponCode)
        {
            var result = await _context.Coupons
                    .FirstOrDefaultAsync(x => x.CouponCode == couponCode 
                                            && x.IsApplied == false);

            return _mapper.Map<Coupon>(result);
        }
       
        public async Task<Coupon> AddDiscount(Coupon coupon)
        {

            var couponInDb = await _context.Coupons
                .FirstOrDefaultAsync(x => x.CouponCode == coupon.CouponCode);

            if (couponInDb != null)
            {
                throw new Exception("Duplicate coupon code.");
            }

            var couponEntity = _mapper.Map<CouponEntity>(coupon);

            _context.Coupons.Add(couponEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Coupon>(couponEntity);
        }

        public async Task<Coupon> UpdateDiscount(Coupon coupon)
        {
            var couponInDb = await _context.Coupons
                    .FirstOrDefaultAsync(x => x.CouponCode == coupon.CouponCode);
            if (couponInDb != null)
            {
                throw new Exception("Duplicate coupon code.");
            }
            var couponEntity = _mapper.Map(coupon, couponInDb);
            _context.Coupons.Update(couponEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Coupon>(couponEntity);
        }

        
    }
}
