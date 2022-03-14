using SQLite;
using mobile2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile2
{
    public class PokemonDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PokemonDataBase> Instance = new AsyncLazy<PokemonDataBase>(async () =>
        {
            var instance = new PokemonDataBase();
            CreateTableResult result = await Database.CreateTableAsync<Poke>();
            return instance;
        });

        public PokemonDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        //...

        public Task<List<Poke>> GetItemsAsync()
        {
            return Database.Table<Poke>().ToListAsync();
        }

        public Task<List<Poke>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Poke>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Poke> GetItemAsync(int id)
        {
            return Database.Table<Poke>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Poke item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Poke item)
        {
            return Database.DeleteAsync(item);
        }
}
}
