using Domain.Entity;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repositories;

public class AdminRepository : BaseRepository<UserProfile>
{
    public AdminRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}