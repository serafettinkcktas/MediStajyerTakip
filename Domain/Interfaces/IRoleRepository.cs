using Domain.Entity;

namespace Domain.Interfaces;

public interface IRoleRepository
{
    Task<string> CreateRole(string roleName);
    Task<Role?> GetRoleByNameAsync(string roleName);
}