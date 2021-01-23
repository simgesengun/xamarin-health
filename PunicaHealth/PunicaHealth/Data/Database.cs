using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PunicaHealth.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public void DeleteUsersAsync()
        {
            _database.DropTableAsync<User>().Wait();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }
        public async Task<bool> userExistsAsync(string email, string password)
        {
            bool exists = (await _database.Table<User>().Where(f => f.email == email && f.password == password).CountAsync()) > 0;

            if (exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> emailAvailableAsync(string email)
        {
            bool exists = (await _database.Table<User>().Where(f => f.email == email).CountAsync()) > 0;

            if (exists)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
