using Npgsql;
using RIS_p2_LR5.Data;
using RIS_p2_LR5.Models;
using System.Data;

namespace RIS_p2_LR5.Services
{
    public class CustomerService
    {
        private readonly DatabaseConnection _dbConnection;
        
        public CustomerService(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var query = @"
                SELECT Id, CompanyName, ContactPerson, Phone, Email, Address, CreatedAt, UpdatedAt 
                FROM Customers 
                ORDER BY CompanyName";
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query);
            return ConvertDataTableToCustomers(dataTable);
        }
        
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            var query = @"
                SELECT Id, CompanyName, ContactPerson, Phone, Email, Address, CreatedAt, UpdatedAt 
                FROM Customers 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", id)
            };
            
            var dataTable = await _dbConnection.ExecuteQueryAsync(query, parameters);
            var customers = ConvertDataTableToCustomers(dataTable);
            return customers.FirstOrDefault();
        }
        
        public async Task<int> CreateCustomerAsync(Customer customer)
        {
            var query = @"
                INSERT INTO Customers (CompanyName, ContactPerson, Phone, Email, Address) 
                VALUES (@CompanyName, @ContactPerson, @Phone, @Email, @Address) 
                RETURNING Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@CompanyName", customer.CompanyName),
                new NpgsqlParameter("@ContactPerson", customer.ContactPerson),
                new NpgsqlParameter("@Phone", customer.Phone),
                new NpgsqlParameter("@Email", customer.Email),
                new NpgsqlParameter("@Address", customer.Address)
            };
            
            var result = await _dbConnection.ExecuteScalarAsync(query, parameters);
            return Convert.ToInt32(result);
        }
        
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var query = @"
                UPDATE Customers 
                SET CompanyName = @CompanyName, ContactPerson = @ContactPerson, 
                    Phone = @Phone, Email = @Email, Address = @Address 
                WHERE Id = @Id";
            
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", customer.Id),
                new NpgsqlParameter("@CompanyName", customer.CompanyName),
                new NpgsqlParameter("@ContactPerson", customer.ContactPerson),
                new NpgsqlParameter("@Phone", customer.Phone),
                new NpgsqlParameter("@Email", customer.Email),
                new NpgsqlParameter("@Address", customer.Address)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var query = "DELETE FROM Customers WHERE Id = @Id";
            var parameters = new[]
            {
                new NpgsqlParameter("@Id", id)
            };
            
            var rowsAffected = await _dbConnection.ExecuteNonQueryAsync(query, parameters);
            return rowsAffected > 0;
        }
        
        private List<Customer> ConvertDataTableToCustomers(DataTable dataTable)
        {
            var customers = new List<Customer>();
            
            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(new Customer
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CompanyName = row["CompanyName"].ToString() ?? string.Empty,
                    ContactPerson = row["ContactPerson"].ToString() ?? string.Empty,
                    Phone = row["Phone"].ToString() ?? string.Empty,
                    Email = row["Email"].ToString() ?? string.Empty,
                    Address = row["Address"].ToString() ?? string.Empty,
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                });
            }
            
            return customers;
        }
    }
}
