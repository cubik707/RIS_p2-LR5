using Npgsql;
using RIS_p2_LR5.Configuration;
using System.Data;

namespace RIS_p2_LR5.Data
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;
        
        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public DatabaseConnection(string host, string database, string username, string password, int port = 5432)
        {
            _connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";
        }
        
        public DatabaseConnection(DatabaseSettings settings)
        {
            _connectionString = $"Host={settings.Host};Port={settings.Port};Database={settings.Database};Username={settings.Username};Password={settings.Password};";
        }
        
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
        
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                using var connection = GetConnection();
                await connection.OpenAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<DataTable> ExecuteQueryAsync(string query, params NpgsqlParameter[] parameters)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            
            using var command = new NpgsqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            
            using var adapter = new NpgsqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            
            return dataTable;
        }
        
        public async Task<int> ExecuteNonQueryAsync(string query, params NpgsqlParameter[] parameters)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            
            using var command = new NpgsqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            
            return await command.ExecuteNonQueryAsync();
        }
        
        public async Task<object> ExecuteScalarAsync(string query, params NpgsqlParameter[] parameters)
        {
            using var connection = GetConnection();
            await connection.OpenAsync();
            
            using var command = new NpgsqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            
            return await command.ExecuteScalarAsync();
        }
    }
}
