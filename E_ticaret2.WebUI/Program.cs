using E_ticaret2.Data;
using E_ticaret2.Service.Abstract;
using E_ticaret2.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_ticaret2.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Uygulamada session kullanaca��m�z� bildidiyoruz
            builder.Services.AddSession(options => {
                options.Cookie.Name = "E_Ticaret.Session";
                options.Cookie.HttpOnly = true;  // Bu ayar, �erezin yaln�zca sunucu taraf�nda eri�ilebilir olmas�n� sa�lar.
                options.Cookie.IsEssential = true; // Bu ayar, �erezin zorunlu bir �erez oldu�unu belirtir. Kullan�c� �erez tercihleri sunuldu�unda, bu �erez kullan�c�n�n onay�na bak�lmaks�z�n olu�turulur.
                options.IdleTimeout = TimeSpan.FromDays(30); // Bu ayar, oturumun maksimum bo�ta kalma s�resini belirler.  1 g�n i�inde oturum kullan�lmazsa sona erer.
                options.IOTimeout = TimeSpan.FromMinutes(10); // Bu ayar, oturumun I/O i�lemleri s�ras�nda ne kadar s�re bekleyece�ini belirler. �rnekte, oturum I/O (giri�/��k��) i�lemleri i�in maksimum 10 dakika bekler. Bu s�re a��l�rsa i�lem bir hata ile sonlan�r.

            });

            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });

            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>)); // Her IService iste�i yapt���m�zda sistem arka tarafta service s�n�f�n�n bir �rne�ini olu�turup onu sunacak 

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Account/SignIn"; // Giri� yolu
                    x.LogoutPath = "/Account/SignIn"; // ��k�� yolu
                    x.AccessDeniedPath = "/AccessDenied"; // Eri�im engellendi ekran� kullan�c�n�n yetkisinin olmad��� zaman g�sterilecek 
                    x.Cookie.Name = "Account";
                    x.Cookie.MaxAge = TimeSpan.FromDays(30); // Cookie 'nin ya�am s�resi yani cookie ne kadar s�re ayakta kalacak
                    x.Cookie.IsEssential = true; // Kal�c� cookie olu�mas� sa�lan�yor.
                });
            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin")); // kullan�c� admin rol�ne sahipse bu ekranlara eri�ebilecek
                x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer")); // kullan�c� admin user veya customer rol�ne sahipse bu ekranlara eri�ebilecek
            }); // Yetkilendirme

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

            app.UseSession();  // Session kullan


            app.UseAuthentication(); // Bu �nce gelmeli �nce oturum a�ma
            app.UseAuthorization();  // sonra yetkilendirme



            app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
