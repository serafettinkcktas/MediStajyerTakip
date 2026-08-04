namespace Application.Common.Models;

public enum ResultCode
{
    Success = 0,
    EmailExists = 1,
    RoleNotFound = 2,
    ValidationError = 3,
    UnexpectedError = 99
}