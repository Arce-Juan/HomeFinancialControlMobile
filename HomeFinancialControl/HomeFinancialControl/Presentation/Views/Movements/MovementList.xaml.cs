using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Domain.Services.Movements;
using HomeFinancialControl.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Views.Movements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovementList : ContentPage
    {
        private readonly IMovementService _movementService;
        public MovementListViewModel Model { get; set; } = new MovementListViewModel();

        public MovementList()
        {
            InitializeComponent();
            BindingContext = this;
            _movementService = (IMovementService)App.ServiceProvider?.GetService(typeof(IMovementService));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var movements = await _movementService.GetAllMovementsAsync(DateTime.Now, DateTime.Now);
            var revenues = movements.Where(m => m.Concept.ConceptType == ConceptType.INGRESO).Sum(m => m.Amount);
            var expenses = movements.Where(m => m.Concept.ConceptType == ConceptType.EGRESO).Sum(m => m.Amount);
            Model.TotalRevenues = revenues.ToString();
            Model.TotalExpenses = expenses.ToString();
            Model.Total = (revenues - expenses).ToString();
            Model.Movements = movements.Select(m =>
                new MovementViewModel()
                {
                    ConceptName = m.Concept.Name,
                    Date = m.Date.ToString("dd/MM/yyyy"),
                    Amount = m.Amount.ToString(),
                    ConceptType = m.Concept.ConceptType.ToString()
                }
            ).ToList();
            OnPropertyChanged(nameof(Model));
        }

        private async void SearchByDates_Clicked(object sender, EventArgs e)
        {
            var startDate = pickerStartDate.Date;
            var endDate = pickerEndDate.Date;
            if (startDate > endDate)
            {
                await DisplayAlert("Error", "La fecha Desde no puede ser mayor a la fecha Hasta", "Ok");
                return;
            }

            var movements = await _movementService.GetAllMovementsAsync(startDate, endDate);
            var revenues = movements.Where(m => m.Concept.ConceptType == ConceptType.INGRESO).Sum(m => m.Amount);
            var expenses = movements.Where(m => m.Concept.ConceptType == ConceptType.EGRESO).Sum(m => m.Amount);
            Model.TotalRevenues = revenues.ToString();
            Model.TotalExpenses = expenses.ToString();
            Model.Total = (revenues - expenses).ToString();
            Model.Movements = movements.Select(m =>
                new MovementViewModel()
                {
                    ConceptName = m.Concept.Name,
                    Date = m.Date.ToString("dd/MM/yyyy"),
                    Amount = m.Amount.ToString(),
                    ConceptType = m.Concept.ConceptType.ToString()
                }
            ).ToList();
            OnPropertyChanged(nameof(Model));
        }

        private async void AddMovement_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMovement());
        }
    }
}