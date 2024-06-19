using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Service.Services;

namespace API.H2A.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependecyInjectionConfiguration(this IServiceCollection service)
        {
            // Services
            service.AddScoped<IPacienteService, PacienteService>();

            // Repositories
            service.AddScoped<IPacienteRepository, PacienteRepository>();
        }
    }
}
