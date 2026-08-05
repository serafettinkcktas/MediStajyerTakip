using System.Data;
using Dapper;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Persistence.Repositories;

public class RoleRepository(IDbConnectionFactory connectionFactory) : IRoleRepository
{
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

    public async Task<string> CreateRole(string roleName)
    {
        var id = Guid.NewGuid();
        const string sql = @"INSERT INTO Roles (id, name) VALUES (@Id, @RoleName)";

        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id, RoleName = roleName });
        connection.Close();
        return id.ToString(); 
    }

    public async Task<Role?> GetRoleByNameAsync(string roleName)
    {
        const string sql = @"(
        SELECT 
            CAST(Id AS UNIQUEIDENTIFIER) AS Id, 
            Name 
        FROM Roles 
        WHERE LOWER(Name) = LOWER(@RoleName))";
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Role?>(sql, new { RoleName = roleName });
        
    }
}