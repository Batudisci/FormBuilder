using Lena.Business.Abstract;
using Lena.Business.Concrete;
using Lena.DataAccess.Abstract;
using Lena.DataAccess.Concrete.EntityFramework;
using Lena.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7115/")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed((host) => true);
        });
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IFormService, FormManager>();
builder.Services.AddSingleton<IFormDal, EfFormDal>();
builder.Services.AddSingleton<IFormFieldService, FormFieldManager>();
builder.Services.AddSingleton<IFormFieldDal, EfFormFieldDal>();
builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<LenaContext>();
builder.Services.AddDbContext<LenaContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
