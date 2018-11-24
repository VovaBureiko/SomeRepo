using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test_For_NewComers.BLL.Interfaces;
using Test_For_NewComers.BLL.Services;
using Test_For_NewComers.DAL;

namespace Test_For_NewComers.AppStart
{
    public static class IoCConfig
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            RegisterContext(services, configuration);
            RegisterServices(services);
        }

        private static void RegisterContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DisciplesContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ITestPreparationService, PreparationService>();
        }
    }
}

