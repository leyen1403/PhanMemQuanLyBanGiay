using Microsoft.EntityFrameworkCore;
using System;
using WebBanGiay.Models;
using WebBanGiay.Services;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ controller và view
builder.Services.AddControllersWithViews();

// Cấu hình DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm dịch vụ cho các service của bạn
builder.Services.AddScoped<SanPhamService>();
builder.Services.AddScoped<ThuongHieuService>();

// Cấu hình bộ nhớ cache và session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;  // Đảm bảo session được sử dụng ngay cả khi cookie không được bật
});

var app = builder.Build();

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

// Cấu hình routing và session
app.UseRouting();

// Kích hoạt session
app.UseSession();

// Kích hoạt authorization
app.UseAuthorization();

// Định nghĩa các route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
