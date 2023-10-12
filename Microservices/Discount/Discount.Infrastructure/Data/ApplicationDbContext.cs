using Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CouponEntity> Coupons { get; set; }
    }
}
