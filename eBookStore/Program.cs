using eBookStore;
using eBookStore.Application;
using eBookStore.Domain.Entities;
using eBookStore.Persistence;
using eBookStore.Persistence.EFContext;
using eBookStore.Shared.Helper.FileHelper;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwagger();
builder.Services.AddApplicationLayerService();
builder.Services.AddPersistenceLayerService();
builder.Services.AddAuth(builder.Configuration);

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddContext();
builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
