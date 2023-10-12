using Discount.Application;
using Discount.Application.Repositories;
using Grpc.Core;

namespace Discount.gRPCS.Services
{
    public class CouponService : CoupongRPCService.CoupongRPCServiceBase
    {
        private readonly IDiscountRepository _discountRepository;

        public CouponService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public override async Task<Coupon> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            return await _discountRepository.GetDiscount(request.CouponCode);
        }
        public override async Task<Coupon> GetCoupon(GetCouponRequest request, ServerCallContext context)
        {
            return await _discountRepository.GetCouponById(request.CouponId);
        }
        public override async Task<Coupon> AddCoupon(Coupon request, ServerCallContext context)
        {
            return await _discountRepository.AddDiscount(request);
        }
        public override async Task<Coupon> UpdateCoupon(Coupon request, ServerCallContext context)
        {
            return await _discountRepository.UpdateDiscount(request);
        }
        public override Task<DeleteCouponResponse> DeleteCoupon(DeleteCouponRequest request, ServerCallContext context)
        {
            return base.DeleteCoupon(request, context);
        }
    }
}
