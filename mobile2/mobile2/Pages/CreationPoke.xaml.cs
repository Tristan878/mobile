using mobile2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationPoke : ContentPage
    {
        public CreationPoke()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitListe();
        }

        private async void InitListe()
        {
            statusMessage.Text = "";
            List<PokeBdd> pokemons = await App.PokeBddViewModel.GetPokesAsync();

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"{pokemon.Id} - {pokemon.Nom}");
                collectionView.ItemsSource = await App.PokeBddViewModel.GetPokesAsync();
                statusMessage.Text = App.PokeBddViewModel.StatusMessage;
            }
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PokeBdd current = (e.CurrentSelection.FirstOrDefault() as PokeBdd);

            if (current == null)
            {
                return;
            }

          (sender as CollectionView).SelectedItem = null;

            await Navigation.PushAsync(new DetailCreationPoke(current));
        }

    }
}