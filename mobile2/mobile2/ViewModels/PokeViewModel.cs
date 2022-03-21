using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using mobile2.Models;
using PokeApiNet;

namespace mobile2.ViewModels
{
    class PokeViewModel : BaseViewModel
    {
        public ObservableCollection<Poke> PokemonList
        {
            get { return GetValue<ObservableCollection<Poke>>(); }
            set { SetValue(value); }
        }

        private static PokeViewModel _instance = new PokeViewModel();
        public static PokeViewModel Instance { get { return _instance; } }
        
        public PokeViewModel()
        {
             
        PokemonList = new ObservableCollection<Poke>();
            CallApi();
        }

        /* Fonction permettant d'initilaiser l'api et de retourner les informations des 50 Pokemons de la liste */
        async void CallApi() {
            PokeApiClient ClientPokeApi = new PokeApiClient();
            PokeApiClient pokeApiClient = new PokeApiClient();
            
            for (int num = 1; num <= 50; num++)
            {
                Pokemon pokeApi = await Task.Run(() => ClientPokeApi.GetResourceAsync<Pokemon>(num));

                Poke pokemon = new Poke();
                pokemon.Id = pokeApi.Id;
                pokemon.Name = pokeApi.Name[0].ToString().ToUpper() + pokeApi.Name.Substring(1);
                pokemon.Height = pokeApi.Height;
                pokemon.Weight = pokeApi.Weight;
                pokemon.Pictures = pokeApi.Sprites.FrontDefault;
                pokemon.Hp = pokeApi.Stats[0].BaseStat;
                pokemon.Type1 = pokeApi.Types[0].Type.Name[0].ToString().ToUpper() + pokeApi.Types[0].Type.Name.Substring(1); ;

                if (pokeApi.Types.Count == 2)
                    pokemon.Type2 = pokeApi.Types[1].Type.Name[0].ToString().ToUpper() + pokeApi.Types[1].Type.Name.Substring(1); 

                PokemonList.Add(pokemon);
            }
        }
    }
}
