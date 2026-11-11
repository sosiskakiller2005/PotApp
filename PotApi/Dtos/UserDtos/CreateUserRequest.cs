namespace PotApp.Dtos.UserDtos
{
    public record CreateUserRequest(string Name, string Email, int RoleId, string PhoneNumber, string Address, string Password);
}
