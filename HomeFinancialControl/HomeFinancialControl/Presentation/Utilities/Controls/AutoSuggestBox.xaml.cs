using HomeFinancialControl.Domain.Services.Concepts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Utilities.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoSuggestBox : ContentView
    {
        private readonly IConceptService _conceptService;

        public AutoSuggestBox()
        {
            _conceptService = (IConceptService)App.ServiceProvider?.GetService(typeof(IConceptService));

            searchEntry = new Entry
            {
                Placeholder = "Buscar...",
            };

            suggestionsListView = new ListView
            {
                IsVisible = false
            };
            suggestionsListView.ItemTapped += SuggestionsListView_ItemTapped;

            searchEntry.TextChanged += SearchEntry_TextChangedAsync;

            var layout = new StackLayout();
            layout.Children.Add(searchEntry);
            layout.Children.Add(suggestionsListView);

            Content = layout;
        }

        private async void SearchEntry_TextChangedAsync(object sender, TextChangedEventArgs e)
        {
            var concepts = await _conceptService.GetConceptsByNameAsync(e.NewTextValue);

            List<string> suggestions = concepts.Select(x => x.Name).ToList();

            suggestionsListView.ItemsSource = suggestions;
            suggestionsListView.IsVisible = suggestions.Count > 0;
        }

        private void SuggestionsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is string suggestion)
            {
                searchEntry.Text = suggestion;
                suggestionsListView.IsVisible = false;
            }
        }
    }
}