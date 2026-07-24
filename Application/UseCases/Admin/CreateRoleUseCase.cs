using Domain.Interfaces;

namespace Application.UseCases.Admin;

public class CreateRoleUseCase(IRoleRepository roleRepository)
{
    private readonly IRoleRepository  _roleRepository = roleRepository;

    public async Task<string> CreateRole(string roleName)
    {
        var role = await _roleRepository.CreateRole(roleName);
        return role;
    }
}