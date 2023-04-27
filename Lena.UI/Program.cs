using Lena.Business.Abstract;
using Lena.Business.Concrete;
using Lena.DataAccess.Abstract;
using Lena.DataAccess.Concrete.EntityFramework;
using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFormService, FormManager>();
builder.Services.AddSingleton<IFormDal, EfFormDal>();
builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<LenaContext>();
builder.Services.AddDbContext<LenaContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/SignIn";
    options.AccessDeniedPath = "/Home/Index";
    options.SlidingExpiration = true;
});
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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
