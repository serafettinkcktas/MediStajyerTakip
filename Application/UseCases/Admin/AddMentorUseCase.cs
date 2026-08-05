using Application.Command.Mentor;
using Application.Common.Helpers;
using Application.Common.Models;
using Application.DTOs;
using Domain.Entity;
using Domain.Interfaces;

namespace Application.UseCases.Admin;

public class AddMentorUseCase(IAccountRepository accountRepository, IRoleRepository roleRepository, AccountHelper accounthelper, UserProfileHelper userProfileHelper)
{
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly AccountHelper _accounthelper = accounthelper;
    private readonly UserProfileHelper _userProfileHelper = userProfileHelper;
    private readonly MentorHelper _mentorHelper = new MentorHelper();

    /// <summary>
    /// Bu metod mentor ekler
    /// </summary>
    /// <param name="name">Mentor adi</param>
    /// <param name="surname">Mentor soyadi</param>
    /// <param name="email">Mentor e postasi </param>
    /// <returns>Hesap basariyla olusturulursa geriye mentor sifresi ve id degerini doner  </returns>
    public async Task<Result<CreateAccountResponseDto>> AddMentorAsync(CreateMentorCommand command)
    {
        var exists = await _accountRepository.IsUserExists(command.Email);
        if (exists)
            return Result<CreateAccountResponseDto>.Failure(ResultCode.EmailExists, "Bu email kayitli");

        var role = await _roleRepository.GetRoleByNameAsync("Mentor");
        if (role is null)
            return Result<CreateAccountResponseDto>.Failure(ResultCode.RoleNotFound, "Mentor rolu bulunamadi");
        
        var password = PasswordHelper.Generate();
        var passwordHash = PasswordHelper.Hash(password);
        var accountId = Guid.NewGuid();
        var profileId = Guid.NewGuid();
        var mentorId = Guid.NewGuid();
        var account = await _accounthelper.CreateAccount(accountId,command.Email,passwordHash,role);
        var profile = await _userProfileHelper.CreateUserProfile(profileId,accountId,command.Name,command.Surname,command.Email);
        var mentor = await _mentorHelper.CreateMentor(mentorId,accountId,profileId);
       
        var isCreated = await _accountRepository.CreateMentor(account,profile, mentor);

        if (!isCreated)
            return Result<CreateAccountResponseDto>.Failure(ResultCode.UnexpectedError, "Hesap olusturulamadi.");

        var responseDto = new CreateAccountResponseDto
        {
            Name = command.Name,
            Surname = command.Surname,
            Email = command.Email,
            Id = accountId,
            GeneratedPassword = password
        };

        Console.WriteLine("Mentor sifresi : "+password);
        return Result<CreateAccountResponseDto>.Success(responseDto, "Hesap basariyla olusturuldu.");
    }
}