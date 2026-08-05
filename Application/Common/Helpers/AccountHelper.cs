using Domain.Entity;

namespace Application.Common.Helpers;

public class AccountHelper
{
    
    //TODO => usecase içindeki account oluşturma kısmını buraya userprofili yeni bir metoda ve mentoru da yeni bir metoda aktar 
    public async Task<Account> CreateAccount(Guid id,string email,string passwordHash, Role role)
    {
        Account account = new Account(
            id,
            email,
            passwordHash,
            role.Id
            );
        return account;

    }

}