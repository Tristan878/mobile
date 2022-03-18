using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mobile2.Models;
using SQLite;

namespace mobile2.ViewModels
{
    public class UserViewModel
    {
        private SQLiteAsyncConnection connection;
        public string StatusMessage { get; set; }
       public UserViewModel (string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<User>();
        }

        public async Task AddNewUserAsync(string Nom)
        {
            int result = 0;

            try
            {
                result = await connection.InsertAsync( new User { Nom = Nom });
                StatusMessage = $"{result} pokemon ajouté : { Nom}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'ajouter le pokemon : { Nom}.\n Erreur : {ex.Message} ";
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await connection.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'afficher les pokemons\n Erreur : {ex.Message} ";
            }

            return new List<User>();
        }
    }
}
