using GameZone.Data;
using GameZone.Services;
using Microsoft.EntityFrameworkCore;

namespace GameZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IGameServices, GameServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddDbContext<ApplicationDbContext>
                (option => option.UseLazyLoadingProxies().UseSqlServer
                (builder.Configuration.GetConnectionString("defaultConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area:exists}/{controller}/{action}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Games}/{action=Index}/{id?}");

            app.Run();
        }
    }
}