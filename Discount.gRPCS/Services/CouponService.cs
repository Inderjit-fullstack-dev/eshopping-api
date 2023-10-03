using Grpc.Core;

namespace Discount.gRPCS.Services
{
    public class CouponService : CoupongRPCService.CoupongRPCServiceBase
    {
        public override Task<Coupon> GetCoupon(GetCouponRequest request, ServerCallContext context)
        {
            return base.GetCoupon(request, context);
        }
        public override Task<Coupon> AddCoupon(Coupon request, ServerCallContext context)
        {
            return base.AddCoupon(request, context);
        }
        public override Task<Coupon> UpdateCoupon(Coupon request, ServerCallContext context)
        {
            return base.UpdateCoupon(request, context);
        }
        public override Task<DeleteCouponResponse> DeleteCoupon(DeleteCouponRequest request, ServerCallContext context)
        {
            return base.DeleteCoupon(request, context);
        }
    }
}
