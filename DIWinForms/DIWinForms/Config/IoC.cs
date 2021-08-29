using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using DIWinForms.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace DIWinForms.Config
{
    public static class IoC
    {
        private static ServiceProvider ServiceProvider = null;

        public static T GetForm<T>() where T : Form
        {
            return ServiceProvider.GetRequiredService<T>();
        }

        public static void Init()
        {
            var services = new ServiceCollection();
            RegisterForms(services);

            var configFile = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var content = File.ReadAllText(configFile);

            var appSettings = JsonSerializer.Deserialize<AppSettings>(content);

            services.ConfigureApplicationServices(appSettings);
            services.ConfigureDataEf(appSettings);

            ServiceProvider = services.BuildServiceProvider();
        }

        private static void RegisterForms(IServiceCollection services)
        {
            //services.AddLogging();
            services.AddSingleton<Form1>();
            services.AddSingleton<Form2>();
            //services.AddSingleton<Core.FrmLoading>();
            //services.AddTransient<Countries.FrmCountryList>();
            //services.AddTransient<Users.FrmLogin>();
            //services.AddTransient<Users.FrmUserEdit>();
            //services.AddTransient<Users.FrmUserList>();
        }
    }
}
