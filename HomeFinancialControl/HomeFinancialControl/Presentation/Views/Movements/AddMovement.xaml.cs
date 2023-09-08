using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Domain.Services.Concepts;
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
    public partial class AddMovement : ContentPage
    {
        private readonly IMovementService _movementService;
        private readonly IConceptService _conceptService;
        private AddMovementViewModel ViewModel;

        public AddMovement()
        {
            InitializeComponent();
            _movementService = (IMovementService)App.ServiceProvider?.GetService(typeof(IMovementService));
            _conceptService = (IConceptService)App.ServiceProvider?.GetService(typeof(IConceptService));
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var concepts = await _conceptService.GetAllConceptAsync();
            ViewModel = new AddMovementViewModel()
            {
                Concepts = concepts,
                ConceptNames = concepts.Select(x => x.Name).ToList()
            };
            BindingContext = ViewModel;
        }

        private async void AddMovement_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(AmountEntry.Text, out double amount) && ConceptPicker.SelectedItem == null)
                    await DisplayAlert("Error", "Revise que todos los datos esten cargados", "OK");
                else
                {
                    var selectedConcept = ViewModel.Concepts[ConceptPicker.SelectedIndex];

                    var movement = new Movement()
                    {
                        ConceptId = selectedConcept.Id,
                        Date = MovementDatePicker.Date,
                        Amount = amount
                    };

                    await _movementService.AddMovementAsync(movement);
                    await Navigation.PopAsync();
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Revise que todos los datos esten cargados", "OK");
            }
        }
    }
}