using System;
using System.Collections.Generic;
using mobile2.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutPoke : ContentPage
    {
        public AjoutPoke()
        {
            InitializeComponent();
        }
        private async void OnNewButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            await App.PokeBddViewModel.AddNewPokeAsync(newPoke.Text);
            statusMessage.Text = App.PokeBddViewModel.StatusMessage;
        }

        private async void OnGetButtonClicked(object sender, EventArgs e)
        {
            statusMessage.Text = "";
            List<PokeBdd> pokemons = await App.PokeBddViewModel.GetPokesAsync();

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"{pokemon.Id} - {pokemon.Nom}");

                statusMessage.Text = App.PokeBddViewModel.StatusMessage;
            }
        }
    }
}