using Application.Common.Models;

namespace Application.DTOs;

public class CreateUserResponseDto
{
    public CreateUserResponseDto(bool isSuccess, ResultCode resultCode, string? message, string? generatedPassword, Guid? userId)
    {
        IsSuccess = isSuccess;
        ResultCode = resultCode;
        Message = message;
        GeneratedPassword = generatedPassword;
        UserId = userId;
    }

    public CreateUserResponseDto()
    {
        
    }

    public bool IsSuccess { get; set; }
    public ResultCode ResultCode { get; set; }
    public string? Message { get; set; }
    public string? GeneratedPassword { get; set; }
    public Guid? UserId { get; set; }
    
    
    public static CreateUserResponseDto Success(Guid? userId, string? generatedPassword = null) => new()
    {
        IsSuccess = true,
        ResultCode = ResultCode.Success,
        UserId = userId,
        GeneratedPassword = generatedPassword,
        Message = "Kullanıcı başarıyla oluşturuldu."
    };
    
    public static CreateUserResponseDto Failure(ResultCode code, string message) => new()
    {
        IsSuccess = false,
        ResultCode = code,
        Message = message
    };
}