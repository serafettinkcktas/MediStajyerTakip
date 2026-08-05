using Domain.Entity;

namespace Domain.Interfaces;

public interface IAccountRepository
{
    public Task<bool> IsUserExists(string email);
    public Task<bool> CreateMentor(Account account, UserProfile profile,Mentor  mentor);
    
}