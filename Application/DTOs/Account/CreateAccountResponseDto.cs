using Application.Common.Models;

namespace Application.DTOs;

public class CreateAccountResponseDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string GeneratedPassword { get; set; } = string.Empty;
}