using Npgsql;
using RIS_p2_LR5.Data;
using RIS_p2_LR5.Models;
using System.Data;

namespace RIS_p2_LR5.Services
{
    public class MaterialService
    {
        private readonly DatabaseConnection _dbConnection;
        
        public MaterialService(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<List<Material>> GetAllMaterialsAsync()
        {
            var query = @"
                SELECT Id, Name, Description, Unit, Price, StockQuantity, CreatedAt, UpdatedAt 
                FROM Materials 
                ORDER BY Name";
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query);
            return ConvertDataTableToMaterials(dataTable);
        }
        
        public async Task<Material?> GetMaterialByIdAsync(int id)
        {
            var query = @"
                SELECT Id, Name, Description, Unit, Price, StockQuantity, CreatedAt, UpdatedAt 
                FROM Materials 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", id)
            };
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query, parameters);
            var materials = ConvertDataTableToMaterials(dataTable);
            return materials.FirstOrDefault();
        }
        
        public async Task<int> CreateMaterialAsync(Material material)
        {
            var query = @"
                INSERT INTO Materials (Name, Description, Unit, Price, StockQuantity) 
                VALUES (@Name, @Description, @Unit, @Price, @StockQuantity) 
                RETURNING Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Name", material.Name),
                new NpgsqlParameter("@Description", material.Description),
                new NpgsqlParameter("@Unit", material.Unit),
                new NpgsqlParameter("@Price", material.Price),
                new NpgsqlParameter("@StockQuantity", material.StockQuantity)
            };
            
            var result = await _dbConnection.ExecuteScalarAsync(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateMaterialAsync(Material material)
        {
            var query = @"
                UPDATE Materials 
                SET Name = @Name, Description = @Description, Unit = @Unit, 
                    Price = @Price, StockQuantity = @StockQuantity 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", material.Id),
                new NpgsqlParameter("@Name", material.Name),
                new NpgsqlParameter("@Description", material.Description),
                new NpgsqlParameter("@Unit", material.Unit),
                new NpgsqlParameter("@Price", material.Price),
                new NpgsqlParameter("@StockQuantity", material.StockQuantity)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteMaterialAsync(int id)
        {
            var query = "DELETE FROM Materials WHERE Id = @Id";
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", id)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<int> GetCurrentStockAsync(int materialId)
        {
            var query = @"
                SELECT StockQuantity 
                FROM Materials 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", materialId)
            };
            
            var result = await _dbConnection.ExecuteScalarAsync(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> HasSufficientStockAsync(int materialId, int requiredQuantity)
        {
            var query = @"
                SELECT StockQuantity 
                FROM Materials 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", materialId)
            };
            
            var result = await _dbConnection.ExecuteScalarAsync(query, parameters);
            var currentStock = Convert.ToInt32(result);
            
            return currentStock >= requiredQuantity;
        }
        
        public async Task<bool> UpdateStockQuantityAsync(int materialId, int quantityChange)
        {
            var query = @"
                UPDATE Materials 
                SET StockQuantity = StockQuantity + @QuantityChange 
                WHERE Id = @Id AND StockQuantity + @QuantityChange >= 0";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", materialId),
                new NpgsqlParameter("@QuantityChange", quantityChange)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        private List<Material> ConvertDataTableToMaterials(DataTable dataTable)
        {
            var materials = new List<Material>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                materials.Add(new Material
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString() ?? string.Empty,
                    Description = row["Description"].ToString() ?? string.Empty,
                    Unit = row["Unit"].ToString() ?? string.Empty,
                    Price = Convert.ToDecimal(row["Price"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                });
            }
            
            return materials;
        }
    }
}
