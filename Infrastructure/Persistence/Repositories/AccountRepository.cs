using Dapper;
using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories;

public class AccountRepository : BaseRepository<Account>,IAccountRepository
{
    
    public AccountRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
        
    }

    public async Task<bool> IsUserExists(string email)
    {
        const string sql = @"
        (SELECT CASE WHEN EXISTS (
            SELECT 1 
            FROM Accounts 
            WHERE Email = @Email
        ) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END)";

        using var connection = _connectionFactory.CreateConnection();

        return await connection.ExecuteScalarAsync<bool>(sql, new { Email = email });
    }

    public async Task<bool> CreateUser(Account account, UserProfile profile, Guid roleId)
    {
        const string insertAccountSql = @"
        (INSERT INTO Accounts (Id, Email, PasswordHash, CreatedAt) 
        VALUES (@Id, @Email, @PasswordHash, @CreatedAt);)";

        const string insertProfileSql = @"(
        INSERT INTO UserProfiles (Id, AccountId, Name, Surname) 
        VALUES (@Id, @AccountId, @Name, @Surname);)";

        const string insertUserRoleSql = @"
        (INSERT INTO UserRoles (AccountId, RoleId) 
        VALUES (@AccountId, @RoleId);)";

        using var connection = _connectionFactory.CreateConnection();
        connection.Open(); 

        using var transaction = connection.BeginTransaction();

        try
        {
            await connection.ExecuteAsync(insertAccountSql, account, transaction);
            await connection.ExecuteAsync(insertProfileSql, profile, transaction);
            await connection.ExecuteAsync(
                insertUserRoleSql, 
                new { AccountId = account.Id, RoleId = roleId }, 
                transaction
            );

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}