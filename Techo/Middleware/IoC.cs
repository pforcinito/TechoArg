using Microsoft.Extensions.DependencyInjection;
using Techo.Contracts;
using Techo.Services;
using Techo.Services.Infraestructrure;
using Techo.Services.Validators;

namespace Techo.Middleware
{
    public static class IoC
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();           
            services.AddScoped<IContribuyenteService, ContribuyenteService>();
            services.AddScoped<IEntidadParticipativaService, EntidadParticipativaService>();
            services.AddScoped<IContribuyenteServiceCache, ContribuyenteCachet>();
            services.AddScoped<IValidateProductExcel, ValidateProductExcel>();
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}