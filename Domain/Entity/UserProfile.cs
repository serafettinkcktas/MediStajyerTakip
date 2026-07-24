namespace Domain.Entity;

public class UserProfile 
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? PhotoUrl { get; set; }
    public string? CvUrl { get; set; }
}