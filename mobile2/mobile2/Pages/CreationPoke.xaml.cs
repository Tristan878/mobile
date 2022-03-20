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

        /*methode permettant d'afficher la liste des pokemons créés*/
        private async void InitListe()
        {
            statusMessage.Text = "";
            List<PokeBdd> pokemons = await App.PokeBddViewModel.GetPokesAsync();

            /*boucle permettant d'afficher tous les pokemons de la bdd*/
            foreach (var pokemon in pokemons)
            {
                /*Dans la console*/
                Console.WriteLine($"{pokemon.Id} - {pokemon.Nom}");
                /*Sur l'application*/
                collectionView.ItemsSource = await App.PokeBddViewModel.GetPokesAsync();
                statusMessage.Text = App.PokeBddViewModel.StatusMessage;
            }
        }

        /*Methode permettant de d'afficher la page de details de pokemon créé lors d'un clic*/
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