using HomeFinancialControl.Domain.Services.Movements;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Movements : ContentPage
    {
        private readonly IMovementService _movementService;

        public Movements()
        {
            InitializeComponent();
            _movementService = (IMovementService)App.ServiceProvider?.GetService(typeof(IMovementService));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var movements = await _movementService.GetAllMovementsAsync();
            OnPropertyChanged(nameof(movements));
        }

        private async void BuscarPorFecha_Clicked(object sender, EventArgs e)
        {
            var movements = await _movementService.GetAllMovementsAsync();
            OnPropertyChanged(nameof(movements));
        }
    }
}