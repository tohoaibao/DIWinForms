using DIWinForms.Context;
using DIWinForms.Repositories;
using DIWinForms.Services;
using DIWinForms.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DIWinForms.Config
{
    

    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureDataEf(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(appSettings.DataBaseSettings.ConnectionString));

            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            //services.AddTransient<ICountriesRepository, CountriesRepository>();

            return services;
        }

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, AppSettings appSettings)
        {
            //services.AddTransient<ICountryService, CountryService>();
            //services.AddTransient<IEncryptText, EncryptTextSha1>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
