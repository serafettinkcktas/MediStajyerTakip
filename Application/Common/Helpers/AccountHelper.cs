using Domain.Entity;

namespace Application.Common.Helpers;

public class AccountHelper
{
    
    //TODO => usecase içindeki account oluşturma kısmını buraya userprofili yeni bir metoda ve mentoru da yeni bir metoda aktar 
    public async Task<Account> CreateAccount(Guid accountId, string name,string surname,string email,string roleId)
    {
        Account account = new Account(
            
            );
        return 
        );

    }

}