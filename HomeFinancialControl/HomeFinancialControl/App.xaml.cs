using HomeFinancialControl.Domain.Services.Concepts;
using HomeFinancialControl.Domain.Services.Movements;
using HomeFinancialControl.Infraestructure.Context;
using HomeFinancialControl.Infraestructure.Generics;
using HomeFinancialControl.Infraestructure.Repositories;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;
using HomeFinancialControl.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;


namespace HomeFinancialControl
{
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider => _serviceProvider ?? throw new InvalidOperationException("El proveedor de servicios no ha sido inicializado");
        public App()
        {
            InitializeComponent();
            ConfigureServices();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void ConfigureServices()
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
            _serviceProvider = services.BuildServiceProvider();
            DependencyService.RegisterSingleton(_serviceProvider);
        }
    }
}
