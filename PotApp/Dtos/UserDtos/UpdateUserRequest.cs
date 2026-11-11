namespace PotApp.Dtos.UserDtos
{
    public record UpdateUserRequest(string? Name, string? Email, int? RoleId, string? PhoneNumber, string? Address, string? Password);

}
