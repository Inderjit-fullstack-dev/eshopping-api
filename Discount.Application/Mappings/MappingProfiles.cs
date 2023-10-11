using AutoMapper;
using Discount.Core.Entities;

namespace Discount.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CouponEntity, Coupon>().ReverseMap();
        }
    }
}
