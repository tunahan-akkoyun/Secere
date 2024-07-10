using Identity_1.Data;
using Identity_1.Models;
using Identity_1.RegisterEmail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyData.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//// burada degisikleri oldu 
builder.Services.AddIdentity<AppUser, IdentityRole>(op=>op.SignIn.RequireConfirmedAccount=true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

/*
 
 
 1. builder.Services.AddIdentity<AppUser, IdentityRole>()
builder.Services: Bu, uygulamanın servis koleksiyonudur ve DI (Dependency Injection) konteynerine servisler 
eklemek için kullanılır.
AddIdentity<AppUser, IdentityRole>(): Bu, ASP.NET Core Identity sistemini yapılandırır.
AppUser: Kullanıcı bilgilerini temsil eden sınıftır. Genellikle, IdentityUser sınıfından türetilir ve ek 
kullanıcı özellikleri eklemek için özelleştirilir.
IdentityRole: Rol bilgilerini temsil eden sınıftır. Kullanıcıların hangi rollerde olduğunu belirlemek için
kullanılır.
2. .AddDefaultUI()
Bu metod, ASP.NET Core Identity sistemine varsayılan kullanıcı arayüzlerini (UI) ekler. Bu UI bileşenleri,
kayıt olma, giriş yapma, parola sıfırlama gibi işlemler için gerekli sayfaları içerir. Bu sayede, bu işlemler
için kendi kullanıcı arayüzünüzü yazmanız gerekmez.
3. .AddDefaultTokenProviders()
Bu metod, ASP.NET Core Identity sistemine varsayılan token sağlayıcılarını ekler. Bu tokenlar, e-posta doğrulama, 
iki faktörlü kimlik doğrulama, parola sıfırlama gibi işlemler için kullanılır. Token sağlayıcılar, bu işlemler 
için güvenli tokenlar oluşturur ve doğrular.
4. .AddEntityFrameworkStores<ApplicationDbContext>()
Bu metod, ASP.NET Core Identity sisteminin veritabanı işlemlerini gerçekleştirmek için Entity Framework Core 
kullanmasını sağlar.
ApplicationDbContext: Veritabanı bağlamını temsil eden sınıftır. DbContext sınıfından türetilir ve veritabanı 
tablolarını temsil eden DbSet<T> özelliklerini içerir. Bu bağlam, kullanıcı bilgilerini ve rollerini 
veritabanında saklamak için kullanılır.
Genel Özet
Bu kod bloğu, ASP.NET Core uygulamanızda kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini yapılandırmak 
için gerekli adımları içerir. Kullanıcı ve rol yönetimi, varsayılan kullanıcı arayüzleri ve güvenli token
sağlayıcıları ile birlikte, Entity Framework Core kullanarak veritabanı işlemlerini gerçekleştirir. 
Bu yapılandırma sayesinde, kullanıcı kayıtları, girişler, roller ve diğer kimlik doğrulama işlemleri
kolayca yönetilebilir hale gelir.
 
 
 
 */




builder.Services.AddRazorPages();

builder.Services.AddSingleton<IEmailSender, EmailOynama>();

builder.Services.AddSingleton<Ihelper<MyClass.Hayvan>, EntityHayvan>();
builder.Services.AddSingleton<Ihelper<MyClass.Tur>, EntityTur>();
builder.Services.AddSingleton<Ihelper<MyClass.Cins>, EntityCins>();
builder.Services.AddSingleton<Ihelper<MyClass.Iliski>, EntityIliski>();
builder.Services.AddSingleton<Ihelper<MyClass.Asi>, EntityAsi>();
builder.Services.AddSingleton<Ihelper<MyClass.Bakim>, EntityBakim>();
builder.Services.AddSingleton<Ihelper<MyClass.User>, EntityUser>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(Endpoints =>
{
    Endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    Endpoints.MapRazorPages();
});
app.MapRazorPages();

app.Run();
