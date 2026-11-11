namespace PotApp.Dtos.UserDtos
{
    public record UserDto(int Id, string Name, string Email, int RoleId, string PhoneNumber, string Address, string Password);
}
