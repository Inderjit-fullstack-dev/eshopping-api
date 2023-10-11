using Discount.Application;
using Discount.Infrastructure;
using Discount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddGrpc();

var app = builder.Build();

//app.MapGrpcService<CouponService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
