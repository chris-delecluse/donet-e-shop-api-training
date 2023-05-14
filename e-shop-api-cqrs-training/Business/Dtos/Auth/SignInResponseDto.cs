namespace Business.Dtos.Auth;

public record SignInResponseDto(string AccessToken, long Iat);
