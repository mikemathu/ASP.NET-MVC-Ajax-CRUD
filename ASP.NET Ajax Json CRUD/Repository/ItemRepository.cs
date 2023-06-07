using ASP.NET_Ajax_Json_CRUD.Models;
using ASP.NET_Ajax_Json_CRUD.Services;
using Npgsql;
using System.Data.Common;

namespace ASP.NET_Ajax_Json_CRUD.Repository
{
    public class ItemRepository : IItemRepository
    {
        private const string _itemsTable = "records";
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        public ItemRepository(IConfiguration config)
        {
            _config = config;
        }
        private void OpenConnection()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public async Task AddItem(ItemVM inventoryItemId)
        {
            OpenConnection();
            string commandText = $"INSERT INTO {_itemsTable} (fname, lname) VALUES (@fname, @lname)";

            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@fname", inventoryItemId.Fname);
                command.Parameters.AddWithValue("@lname", inventoryItemId.Lname);

                await command.ExecuteNonQueryAsync();
            }
            _connection.Close();
        }
    }
}
