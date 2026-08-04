namespace Domain.Entity;

public class UserProfile 
{
    public UserProfile(Guid id, Guid accountId, string name, string surname)
    {
        Id = id;
        AccountId = accountId;
        Name = name;
        Surname = surname;
    }

    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? PhotoUrl { get; set; }
    public string? CvUrl { get; set; }
}