using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Domain.Services.Concepts;
using HomeFinancialControl.Presentation.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Views.Concepts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddConcept : ContentPage
    {
        private readonly IConceptService _conceptService;

        public AddConcept()
        {
            InitializeComponent();
            _conceptService = (IConceptService)App.ServiceProvider?.GetService(typeof(IConceptService));
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AddConceptViewModel()
            {
                Categories = _conceptService.GetAllCategories(),
                ConceptTypes = _conceptService.GetAllConceptTypes()
            };
        }

        private async void AddConcetp_Clicked(object sender, EventArgs e)
        {
            try
            {
                var concept = new Concept()
                {
                    Name = ConceptNameEntry.Text,
                    Category = (Category)Enum.Parse(typeof(Category), CategoryPicker.SelectedItem.ToString()),
                    ConceptType = (ConceptType)Enum.Parse(typeof(ConceptType), ConceptTypePicker.SelectedItem.ToString())
                };

                await _conceptService.AddConceptAsync(concept);
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Revise que todos los datos esten cargados", "OK");
            }
        }
    }
}