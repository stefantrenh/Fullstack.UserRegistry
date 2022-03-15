using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UserRegistry.Domain.Managers;
using UserRegistry.Domain.Models;

namespace UserRegistrys.Application.Services
{
    public class UserCRUDOperationService : IUserCRUDOperationService
    {
        private readonly string _dbConnectionString;

        public UserCRUDOperationService(IConfiguration configuration)
        {
            _dbConnectionString = configuration.GetConnectionString("DbConnection");
        }
        public async Task<UserEntityModel> Create(UserEntityModel user)
        {
            var sqlQuery = "INSERT INTO [User](Name, Address) VALUES (@Name, @Address)";

            using (var sqlConnection = new SqlConnection(_dbConnectionString))
            {
                await sqlConnection.ExecuteAsync(sqlQuery, new 
                { 
                    user.Name,
                    user.Address
                });
            }

            return user;
        }

        public async Task Delete(int id)
        {
            var sqlQuery = "DELETE FROM [User] WHERE Id=@id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
        }

        public async Task<IEnumerable<UserEntityModel>> Get()
        {
            var sqlQuery = "SELECT * FROM [User]";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                return await connection.QueryAsync<UserEntityModel>(sqlQuery);
            }
        }

        public async Task<UserEntityModel> Get(int id)
        {
            var sqlQuery = "SELECT * FROM [User] WHERE Id=@UserId";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<UserEntityModel>(sqlQuery, new { UserId = id });
            }
        }

        public async Task Update(UserEntityModel user)
        {
            var sqlQuery = "UPDATE [User] SET Name=@Name, Address=@Address WHERE Id=@Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new 
                { 
                  user.Id,
                  user.Address,
                  user.Name
                });
            }
        }
    }
}
