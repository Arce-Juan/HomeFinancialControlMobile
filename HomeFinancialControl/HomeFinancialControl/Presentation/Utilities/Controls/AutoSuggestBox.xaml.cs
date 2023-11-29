using HomeFinancialControl.Domain.Services.Concepts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFinancialControl.Presentation.Utilities.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoSuggestBox : ContentView
    {
        private readonly IConceptService _conceptService;

        public int SelectedConceptId { get; set; }
        public string SearchEntryText
        {
            get { return searchEntry.Text; }
        }

        public AutoSuggestBox()
        {
            _conceptService = (IConceptService)App.ServiceProvider?.GetService(typeof(IConceptService));

            searchEntry = new Entry
            {
                Placeholder = "Escribe el nombre del Concepto...",
            };
            searchEntry.TextChanged += SearchEntry_TextChangedAsync;
            var clearButtonTapGesture = new TapGestureRecognizer();
            clearButtonTapGesture.Tapped += ClearButton_Tapped2;
            searchEntry.GestureRecognizers.Add(clearButtonTapGesture);

            suggestionsListView = new ListView
            {
                IsVisible = false
            };
            suggestionsListView.ItemTapped += SuggestionsListView_ItemTapped;


            var clearButton = new Image
            {
                Source = "delete.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 20,
                WidthRequest = 20
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += ClearButton_Tapped2;
            clearButton.GestureRecognizers.Add(tapGestureRecognizer);


            var layout = new StackLayout();
            layout.Children.Add(searchEntry);
            layout.Children.Add(suggestionsListView);
            layout.Children.Add(clearButton);

            Content = layout;
        }

        private async void SearchEntry_TextChangedAsync(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var concepts = await _conceptService.GetConceptsByNameAsync(e.NewTextValue);
                List<string> suggestions = concepts.Select(x => $"{x.Name} - {x.ConceptType} - {x.Id}").ToList();
                suggestionsListView.ItemsSource = suggestions;
                suggestionsListView.IsVisible = suggestions.Count > 0;
            }
        }

        private void SuggestionsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is string suggestion)
            {
                var arrayText = suggestion.Split('-');
                searchEntry.Text = arrayText[0];
                arrayText = suggestion.Replace(" ", "").Split('-');
                SelectedConceptId = int.Parse(arrayText[2]);
                suggestionsListView.IsVisible = false;
                searchEntry.IsEnabled = false;
            }
        }

        private void ClearButton_Tapped2(object sender, EventArgs e)
        {
            searchEntry.Text = string.Empty;
            searchEntry.IsEnabled = true;
        }
    }
}