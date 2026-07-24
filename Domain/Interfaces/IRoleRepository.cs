namespace Domain.Interfaces;

public interface IRoleRepository
{
    Task<string> CreateRole(string roleName);
    
}