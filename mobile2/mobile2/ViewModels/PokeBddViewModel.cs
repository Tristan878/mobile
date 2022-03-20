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
            connection.CreateTableAsync<PokeBdd>();
        }

        

        /* public async Task AddNewPokeAsync(string Nom, float Height, float Weight, int Hp, string Types)
        {
            int result = 0;

            try
            {
                result = await connection.InsertAsync(new PokeBdd { Nom = Nom, Height = Height, Weight = Weight, Hp = Hp, Types = Types });
                StatusMessage = $"{result} pokemon ajouté : { Nom}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'ajouter le pokemon : { Nom}.\n Erreur : {ex.Message} ";
            }
        } */ 

   
        public async Task<List<PokeBdd>> GetPokesAsync()
        {
            try
            {
                return await connection.Table<PokeBdd>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'afficher les pokemons\n Erreur : {ex.Message} ";
            }

            return new List<PokeBdd>();
        }


        public Task<int> SavePokeAsync(PokeBdd PokeBdd)
        {
            return connection.InsertAsync(PokeBdd);
        }





    }
}
