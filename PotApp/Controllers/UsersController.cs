using Microsoft.AspNetCore.Mvc;
using PotApp.Services;
using PotApp.Dtos.UserDtos;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UserService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetUsersResponse>> GetUsers()
        => Ok(await service.GetUsersAsync());

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserRequest request)
    {
        var user = await service.CreateUserAsync(request);
        if (user is null)
        {
            return NotFound("Role was not found.");
        }

        return StatusCode(StatusCodes.Status201Created, user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, UpdateUserRequest request)
    {
        var updatedUser = await service.UpdateUserAsync(id, request);
        if (updatedUser is null)
        {
            return NotFound("User with this Id was not found.");
        }
        return Ok(updatedUser);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateUserPartial(int id, UpdateUserRequest request)
    {
        var updatedUser = await service.UpdateUserAsync(id, request);
        if (updatedUser is null)
        {
            return NotFound("User with this Id was not found.");
        }
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var result = await service.DeleteUserAsync(id);
        if (result is null)
        {
            return NotFound("User with this Id was not found.");
        }
        return Ok("User deleted successfully.");
    }

}
