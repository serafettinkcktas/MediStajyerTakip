using Domain.Entity;

namespace Application.Common.Helpers;

public class UserProfileHelper
{
    
    public async Task<UserProfile> CreateUserProfile(Guid profileId, Guid accountId, string name, string surname, string email)
    {
        UserProfile profile = new(
            profileId,
            accountId,
            name,
            surname,
            email);
        
        return profile;
    }
}