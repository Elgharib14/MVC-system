using Demo.BLL;
using Demo.BLL.Interface;
using Demo.BLL.Reposatory;
using Demo.DAL.context;
using Demo.DAL.Model;
using Demo.PL.Mapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionstring));

            builder.Services.AddAutoMapper(M=>M.AddProfile(new Maperprofile()));

            //builder.Services.AddScoped<IDepartment, DeprtmentRep>();
            //builder.Services.AddScoped<IEmployee,EmployeeRep>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(optios =>
                {
                    optios.LoginPath = "Acount/Login";

                });



            builder.Services.AddIdentity<AppAuth, IdentityRole>(
                option =>
                {
                    option.Password.RequireNonAlphanumeric = true;
                    option.Password.RequireUppercase = true;
                    option.Password.RequireLowercase = true;
                    option.Password.RequiredLength = 10;
                }).AddEntityFrameworkStores<AppDbContext>()
                  .AddDefaultTokenProviders();

            builder.Services.AddScoped<IUnitOfWork, UnitOFWork>();   
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Department}/{action=Index}/{id?}");

            app.Run();
        }
    }
}