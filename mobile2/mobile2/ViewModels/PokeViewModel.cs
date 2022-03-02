using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using mobile2.Models;

namespace mobile2.ViewModels
{
    class PokeViewModel : BaseViewModel
    {
        public static PokeViewModel Instance { get { return _instance; } }
        private static PokeViewModel _instance = new PokeViewModel();

        public ObservableCollection<Poke> PokemonList
        {
            get { return GetValue<ObservableCollection<Poke>>(); }
            set { SetValue(value); }
        }

        public PokeViewModel()
        {
            PokemonList = new ObservableCollection<Poke>()
            {
                new Poke()
                {
                    nom = "pika",
                    element = "elec",
                    pv = 12
                },
            };
        }
    }
}
