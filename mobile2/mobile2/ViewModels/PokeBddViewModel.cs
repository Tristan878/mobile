using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mobile2.Models;
using SQLite;

namespace mobile2.ViewModels
{
    public class PokeBddViewModel
    {
       private SQLiteAsyncConnection connection;
       public string StatusMessage { get; set; }

       public PokeBddViewModel (string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            /* création de la table stoquant nos pokemons*/
            connection.CreateTableAsync<PokeBdd>();
        }


        /*Methode permettant de renvoyer les information des pokemons stocker en bdd afin de les afficher*/
        public async Task<List<PokeBdd>> GetPokesAsync()
        {
            try
            {
                /*retourne le contenu de la table que nous avons créé au dessus afin de stocker nos pokemons*/
                return await connection.Table<PokeBdd>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'afficher les pokemons\n Erreur : {ex.Message} ";
            }

            return new List<PokeBdd>();
        }

        /*Methode permettant de sauvegarder les champs complétés par l'utilisateurs pour céer un pokemon en bdd*/
        public Task<int> SavePokeAsync(PokeBdd PokeBdd)
        {
            return connection.InsertAsync(PokeBdd);
        }





    }
}
