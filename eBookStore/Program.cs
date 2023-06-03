using eBookStore;
using eBookStore.Application;
using eBookStore.Domain.Entities.Authorizations;
using eBookStore.Persistence;
using eBookStore.Persistence.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region Old
//builder.Services.AddDbContext<eBookStoreContext>();

//builder.Services.AddIdentity<User, Role>()
//                .AddEntityFrameworkStores<eBookStoreContext>()
//                .AddDefaultTokenProviders();



//builder.Services.AddDbContext<eBookStoreContext>();
//builder.Services.AddIdentity<User, Role>(options =>
//{
//    options.Password.RequiredLength = 5; // минимальная длина пароля
//    options.Password.RequireNonAlphanumeric = false;  // требуются ли не алфавитно-цифровые символы
//    options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
//    options.Password.RequireUppercase = false;// требуются ли символы в верхнем регистре
//                                              //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
//    options.Password.RequireDigit = false; // требуются ли цифры
//    options.Lockout.MaxFailedAccessAttempts = 5; // попытка блока
//}).AddEntityFrameworkStores<eBookStoreContext>().AddDefaultTokenProviders();
#endregion

builder.Services.AddDataBase();
builder.Services.AddSWG();
builder.Services.AddAuth(builder.Configuration);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());






builder.Services.AddApplicationLayerService();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();