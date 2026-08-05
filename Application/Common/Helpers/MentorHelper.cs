using Domain.Entity;

namespace Application.Common.Helpers;

public class MentorHelper
{
    public async Task<Mentor> CreateMentor(Guid mentorId, Guid accountId, Guid profileId)
    {
        Mentor mentor = new(
            mentorId,
            accountId,
            profileId
            );
        return mentor;
    }
}