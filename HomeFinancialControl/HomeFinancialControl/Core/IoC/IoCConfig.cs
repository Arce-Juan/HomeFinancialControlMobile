using HomeFinancialControl.Domain.Services.Concepts;
using HomeFinancialControl.Domain.Services.Movements;
using HomeFinancialControl.Infraestructure.Context;
using HomeFinancialControl.Infraestructure.Generics;
using HomeFinancialControl.Infraestructure.Repositories;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace HomeFinancialControl.Core.IoC
{
    public static class IoCConfig
    {
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registrar dependencias
            services.AddScoped<IMyDbContext, MyDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IMovementRepository, MovementRepository>();

            services.AddScoped<IConceptService, ConceptService>();
            services.AddScoped<IConceptRepository, ConceptRepository>();

            // Establecer el proveedor de servicios
            var serviceProvider = services.BuildServiceProvider();
            DependencyService.RegisterSingleton(serviceProvider);
        }
    }
}
