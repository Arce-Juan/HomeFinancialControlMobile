using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Domain.Services.Concepts;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Views.Concepts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConceptList : ContentPage
    {
        private readonly IConceptService _conceptService;
        public List<Concept> Model { get; set; } = new List<Concept>();

        public ConceptList()
        {
            InitializeComponent();
            BindingContext = this;
            _conceptService = (IConceptService)App.ServiceProvider?.GetService(typeof(IConceptService));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Model = await _conceptService.GetAllConceptAsync();
            OnPropertyChanged(nameof(Model));
        }

        private async void AddConcept_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddConcept());
        }

        private async void DeleteConcept_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            var concept = (Concept)button.BindingContext;
            int conceptId = concept.Id;
            await _conceptService.DeleteConceptAsync(conceptId);
        }
    }
}
