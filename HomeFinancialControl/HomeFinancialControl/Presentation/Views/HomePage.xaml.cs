using HomeFinancialControl.Presentation.Views.Concepts;
using HomeFinancialControl.Presentation.Views.Movements;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void MovementButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MovementList());
        }

        private async void ConceptButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConceptList());
        }
    }
}