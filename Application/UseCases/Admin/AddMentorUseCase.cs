using Application.Common.Helpers;
using Application.Common.Models;
using Application.DTOs;
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
    public async Task<Result<CreateUserResponseDto>> AddMentorAsync(string name,string surname, string email)
    {
        var exists = await _accountRepository.IsUserExists(email);
        if (exists)
            return Result<CreateUserResponseDto>.Failure(ResultCode.EmailExists, "Bu email kayitli");
        var roleId = await _roleRepository.GetRoleByNameAsync("Mentor");
        var accountId = Guid.NewGuid();
        var password = PasswordHelper.Generate();
        var passwordHash = PasswordHelper.Hash(password); 
        var isCreated = await _accountRepository.CreateUser(accountId, name,surname,email,roleId,passwordHash,"Mentor");
        var responseDto = new CreateUserResponseDto
        {
            UserId = accountId,
            GeneratedPassword = password
        };
        if(isCreated)
        {
            return Result<CreateUserResponseDto>.Success(responseDto,"Hesap basariyla olusturuldu.");
        }
        return Result<CreateUserResponseDto>.Failure(ResultCode.UnexpectedError, "Hesap olusturulamadi.");
       
    }
}