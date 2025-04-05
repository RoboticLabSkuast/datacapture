using SQLite;
using System.IO;


namespace datacapture.services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Datalist>().Wait();
        }

        // Get all items (lists) from the database
        public Task<List<Datalist>> GetAllListsAsync()
        {
            return _database.Table<Datalist>().ToListAsync();
        }

       

        // Clear all items (lists) from the database
        public Task<int> ClearListsAsync()
        {
            return _database.DeleteAllAsync<Datalist>();
        }

        // Optional: Save a single item (if needed)
        public Task<int> SaveDatalistAsync(Datalist item)
        {
            return _database.InsertAsync(item);
        }

       
    }

}

