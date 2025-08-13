using EscolaDeIdiomasApp.Domain.Interfaces.Repositories;
using EscolaDeIdiomasApp.Domain.Interfaces.Services;
using EscolaDeIdiomasApp.Domain.Services;
using EscolasDeIdiomasApp.Infra.Repositories;

namespace EscolaDeIdiomasApp.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IAlunosDomainService, AlunosDomainService>();
            services.AddTransient<ITurmasDomainService, TurmasDomainService>();
            services.AddTransient<IAlunoTurmasDomainService, AlunoTurmasDomainService>();
            
            services.AddTransient<IAlunosRepository, AlunosRepository>();
            services.AddTransient<ITurmasRepository, TurmasRepository>();
            services.AddTransient<IAlunoTurmasRepository, AlunoTurmasRepository>();
        }
    }
}
