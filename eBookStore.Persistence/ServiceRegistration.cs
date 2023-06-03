using eBookStore.Domain.Entities.Authorizations;
using eBookStore.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddDataBase(this IServiceCollection Services)
        {
            Services.AddDbContext<eBookStoreContext>();
            Services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 5; // минимальная длина пароля
                options.Password.RequireNonAlphanumeric = false;  // требуются ли не алфавитно-цифровые символы
                options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                options.Password.RequireUppercase = false;// требуются ли символы в верхнем регистре
                                                          //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Password.RequireDigit = false; // требуются ли цифры
                options.Lockout.MaxFailedAccessAttempts = 5; // попытка блока
            }).AddEntityFrameworkStores<eBookStoreContext>().AddDefaultTokenProviders();
        }
    }
}