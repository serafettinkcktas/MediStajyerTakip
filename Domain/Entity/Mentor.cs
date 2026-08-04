namespace Domain.Entity;

public class Mentor
{
    public Mentor(Guid id, Guid accountId, Guid profileId)
    {
        Id = id;
        AccountId = accountId;
        ProfileId = profileId;
    }

    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ProfileId { get; set; }
}



