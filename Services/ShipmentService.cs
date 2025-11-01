using Npgsql;
using RIS_p2_LR5.Data;
using RIS_p2_LR5.Models;
using System.Data;

namespace RIS_p2_LR5.Services
{
    public class ShipmentService
    {
        private readonly DatabaseConnection _dbConnection;
        
        public ShipmentService(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<List<Shipment>> GetAllShipmentsAsync()
        {
            var query = @"
                SELECT s.Id, s.ShipmentNumber, s.CustomerId, s.ShipmentDate, s.Status, 
                       s.TotalAmount, s.Notes, s.CreatedAt, s.UpdatedAt,
                       c.CompanyName, c.ContactPerson, c.Phone, c.Email, c.Address
                FROM Shipments s
                LEFT JOIN Customers c ON s.CustomerId = c.Id
                ORDER BY s.ShipmentDate DESC, s.ShipmentNumber";
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query);
            return ConvertDataTableToShipments(dataTable);
        }
        
        public async Task<Shipment?> GetShipmentByIdAsync(int id)
        {
            var query = @"
                SELECT s.Id, s.ShipmentNumber, s.CustomerId, s.ShipmentDate, s.Status, 
                       s.TotalAmount, s.Notes, s.CreatedAt, s.UpdatedAt,
                       c.CompanyName, c.ContactPerson, c.Phone, c.Email, c.Address
                FROM Shipments s
                LEFT JOIN Customers c ON s.CustomerId = c.Id
                WHERE s.Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", id)
            };
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query, parameters);
            var shipments = ConvertDataTableToShipments(dataTable);
            var shipment = shipments.FirstOrDefault();
            
            if (shipment != null)
            {
                shipment.Details = await GetShipmentDetailsAsync(shipment.Id);
            }
            
            return shipment;
        }
        
        public async Task<List<ShipmentDetail>> GetShipmentDetailsAsync(int shipmentId)
        {
            var query = @"
                SELECT sd.Id, sd.ShipmentId, sd.MaterialId, sd.Quantity, sd.UnitPrice, 
                       sd.TotalPrice, sd.CreatedAt,
                       m.Name, m.Description, m.Unit
                FROM ShipmentDetails sd
                LEFT JOIN Materials m ON sd.MaterialId = m.Id
                WHERE sd.ShipmentId = @ShipmentId
                ORDER BY sd.Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@ShipmentId", shipmentId)
            };
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query, parameters);
            return ConvertDataTableToShipmentDetails(dataTable);
        }
        
        public async Task<int> CreateShipmentAsync(Shipment shipment)
        {
            var query = @"
                INSERT INTO Shipments (ShipmentNumber, CustomerId, ShipmentDate, Status, TotalAmount, Notes) 
                VALUES (@ShipmentNumber, @CustomerId, @ShipmentDate, @Status, @TotalAmount, @Notes) 
                RETURNING Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@ShipmentNumber", shipment.ShipmentNumber),
                new NpgsqlParameter("@CustomerId", shipment.CustomerId),
                new NpgsqlParameter("@ShipmentDate", shipment.ShipmentDate),
                new NpgsqlParameter("@Status", shipment.Status),
                new NpgsqlParameter("@TotalAmount", shipment.TotalAmount),
                new NpgsqlParameter("@Notes", shipment.Notes)
            };
            
            var result = await _dbConnection.ExecuteScalarAsync(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateShipmentAsync(Shipment shipment)
        {
            var query = @"
                UPDATE Shipments 
                SET ShipmentNumber = @ShipmentNumber, CustomerId = @CustomerId, 
                    ShipmentDate = @ShipmentDate, Status = @Status, 
                    TotalAmount = @TotalAmount, Notes = @Notes 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", shipment.Id),
                new NpgsqlParameter("@ShipmentNumber", shipment.ShipmentNumber),
                new NpgsqlParameter("@CustomerId", shipment.CustomerId),
                new NpgsqlParameter("@ShipmentDate", shipment.ShipmentDate),
                new NpgsqlParameter("@Status", shipment.Status),
                new NpgsqlParameter("@TotalAmount", shipment.TotalAmount),
                new NpgsqlParameter("@Notes", shipment.Notes)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteShipmentAsync(int id)
        {
            var query = "DELETE FROM Shipments WHERE Id = @Id";
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", id)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<bool> AddShipmentDetailAsync(ShipmentDetail detail)
        {
            var query = @"
                INSERT INTO ShipmentDetails (ShipmentId, MaterialId, Quantity, UnitPrice, TotalPrice) 
                VALUES (@ShipmentId, @MaterialId, @Quantity, @UnitPrice, @TotalPrice)";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@ShipmentId", detail.ShipmentId),
                new NpgsqlParameter("@MaterialId", detail.MaterialId),
                new NpgsqlParameter("@Quantity", detail.Quantity),
                new NpgsqlParameter("@UnitPrice", detail.UnitPrice),
                new NpgsqlParameter("@TotalPrice", detail.TotalPrice)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<bool> UpdateShipmentTotalAsync(int shipmentId)
        {
            var query = @"
                UPDATE Shipments 
                SET TotalAmount = (
                    SELECT COALESCE(SUM(TotalPrice), 0) 
                    FROM ShipmentDetails 
                    WHERE ShipmentId = @ShipmentId
                ) 
                WHERE Id = @ShipmentId";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@ShipmentId", shipmentId)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<string> GenerateShipmentNumberAsync()
        {
            var query = "SELECT COUNT(*) FROM Shipments WHERE ShipmentDate >= CURRENT_DATE";
            var count = await _dbConnection.ExecuteScalarAsync(query);
            var todayCount = Convert.ToInt32(count) + 1;
            
            return $"SH{DateTime.Now:yyyyMMdd}{todayCount:D3}";
        }
        
        private List<Shipment> ConvertDataTableToShipments(DataTable dataTable)
        {
            var shipments = new List<Shipment>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                shipments.Add(new Shipment
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ShipmentNumber = row["ShipmentNumber"].ToString() ?? string.Empty,
                    CustomerId = Convert.ToInt32(row["CustomerId"]),
                    ShipmentDate = Convert.ToDateTime(row["ShipmentDate"]),
                    Status = row["Status"].ToString() ?? string.Empty,
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Notes = row["Notes"].ToString() ?? string.Empty,
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"]),
                    Customer = new Customer
                    {
                        Id = Convert.ToInt32(row["CustomerId"]),
                        CompanyName = row["CompanyName"].ToString() ?? string.Empty,
                        ContactPerson = row["ContactPerson"].ToString() ?? string.Empty,
                        Phone = row["Phone"].ToString() ?? string.Empty,
                        Email = row["Email"].ToString() ?? string.Empty,
                        Address = row["Address"].ToString() ?? string.Empty
                    }
                });
            }
            
            return shipments;
        }
        
        private List<ShipmentDetail> ConvertDataTableToShipmentDetails(DataTable dataTable)
        {
            var details = new List<ShipmentDetail>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                details.Add(new ShipmentDetail
                {
                    Id = Convert.ToInt32(row["Id"]),
                    ShipmentId = Convert.ToInt32(row["ShipmentId"]),
                    MaterialId = Convert.ToInt32(row["MaterialId"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    TotalPrice = Convert.ToDecimal(row["TotalPrice"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    Material = new Material
                    {
                        Id = Convert.ToInt32(row["MaterialId"]),
                        Name = row["Name"].ToString() ?? string.Empty,
                        Description = row["Description"].ToString() ?? string.Empty,
                        Unit = row["Unit"].ToString() ?? string.Empty
                    }
                });
            }
            
            return details;
        }
    }
}
