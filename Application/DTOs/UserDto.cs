namespace Application.DTOs;

public class UserDto
{
    public string Email { get; set; } = null!;
    public Guid RoleId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}