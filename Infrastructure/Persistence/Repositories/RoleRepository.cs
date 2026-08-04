using System.Data;
using Dapper;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories;

public class RoleRepository(IDbConnectionFactory connectionFactory) : IRoleRepository
{
    private readonly IDbConnectionFactory _connectionFactory = connectionFactory;

    public async Task<string> CreateRole(string roleName)
    {
        var id = Guid.NewGuid().ToString();
        const string sql = @"INSERT INTO Roles (id, name) VALUES (@Id, @RoleName)";

        using var connection = _connectionFactory.CreateConnection();
        await connection.ExecuteAsync(sql, new { Id = id, RoleName = roleName });
        return id; 
    }

    public async Task<Role?> GetRoleByNameAsync(string roleName)
    {
        const string sql = @"
        (SELECT Id 
        FROM Roles 
        WHERE LOWER(Name) = LOWER(@RoleName))";

        using var connection = _connectionFactory.CreateConnection();
        
        return await connection.ExecuteScalarAsync<Role?>(sql, new { RoleName = roleName });
    }
}