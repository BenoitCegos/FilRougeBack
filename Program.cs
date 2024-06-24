using FilRouge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FilRouge.Controllers;
using FilRouge.Models;
using FilRouge.DAO;

namespace FilRouge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FilRougeContext>();

            //ajout des services pour chaque DAO
            builder.Services.AddScoped<ListeDAO>();

            var app = builder.Build();
            //ajout du CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            //builder.Services.AddDbContext<FilRougeContext>();
            // fin ajout du CORS



            builder.Services.AddDbContext<FilRougeContext>(options =>
            {
                options.UseSqlServer("Server=tcp:monserveursql2.database.windows.net,1433;Initial Catalog=BDDFilRouge;Persist Security Info=False;User ID=bendufBDDSQLServer;Password=Zorglub12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });


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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
