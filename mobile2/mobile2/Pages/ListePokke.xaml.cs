using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobile2.Models;
using mobile2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListePokke : ContentPage
    {
        public ListePokke()
        {
            InitializeComponent();
            BindingContext = PokeViewModel.Instance;

        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Poke current = (e.CurrentSelection.FirstOrDefault() as Poke);

            if (current == null)
            {
                return;
            }

           (sender as CollectionView).SelectedItem = null;

            await Navigation.PushAsync(new DetailPokemon(current));
        }

        private async void OnGetButtonClicked(object sender, EventArgs e)
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
    }
}