using Application.Common.Helpers;
using Application.Common.Models;
using Application.DTOs;
using Domain.Entity;
using Domain.Interfaces;

namespace Application.UseCases.Admin;

public class AddMentorUseCase(IAccountRepository accountRepository, IRoleRepository roleRepository)
{
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;

    /// <summary>
    /// Bu metod mentor ekler
    /// </summary>
    /// <param name="name"></param>
    /// <param name="surname"></param>
    /// <param name="email"></param>
    /// <returns>  </returns>
    public async Task<Result<CreateUserResponseDto>> AddMentorAsync(string name, string surname, string email)
    {
        var exists = await _accountRepository.IsUserExists(email);
        if (exists)
            return Result<CreateUserResponseDto>.Failure(ResultCode.EmailExists, "Bu email kayitli");

        var role = await _roleRepository.GetRoleByNameAsync("Mentor");
        if (role is null)
            return Result<CreateUserResponseDto>.Failure(ResultCode.RoleNotFound, "Mentor rolu bulunamadi");
        
        var password = PasswordHelper.Generate();
        var passwordHash = PasswordHelper.Hash(password);
        var accountId = Guid.NewGuid();
        var profileId = Guid.NewGuid();
        var mentorId = Guid.NewGuid();
        Account account = new(
            accountId,
            email,
            passwordHash,
            role.Id
        );

        UserProfile userProfile = new(
            profileId,
            accountId,
            name,
            surname
        );
        Mentor mentor = new(
            mentorId,
            accountId,
            profileId
            );
        var isCreated = await _accountRepository.CreateUser(account,userProfile,mentor);

        if (!isCreated)
            return Result<CreateUserResponseDto>.Failure(ResultCode.UnexpectedError, "Hesap olusturulamadi.");

        var responseDto = new CreateUserResponseDto
        {
            UserId = accountId,
            GeneratedPassword = password
        };

        return Result<CreateUserResponseDto>.Success(responseDto, "Hesap basariyla olusturuldu.");
    }
}