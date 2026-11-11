using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PotApp.Data;
using PotApp.Dtos.UserDtos;
using PotApp.Models;

namespace PotApp.Services
{
    public class UserService(DataContext context)
    {
        public async Task<GetUsersResponse> GetUsersAsync()
        {
            List<UserDto> users = await context.Users.Select(u => new UserDto(u.Id, u.Name, u.Email, u.RoleId, u.PhoneNumber, u.Address, u.Password)).ToListAsync();
            return new GetUsersResponse(users);
        }

        public async Task<UserDto?> CreateUserAsync(CreateUserRequest request)
        {
            bool roleExists = await context.Roles.AnyAsync(r => r.Id == request.RoleId);
            if (!roleExists)
            {
                return null;
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Password = request.Password,
                RoleId = request.RoleId
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new UserDto(
                user.Id,
                user.Name,
                user.Email,
                user.RoleId,
                user.PhoneNumber,
                user.Address,
                user.Password);
        }

        public async Task<bool?> DeleteUserAsync(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateUserAsync(int id, UpdateUserRequest userDto)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.RoleId = (int)userDto.RoleId;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Address = userDto.Address;
            user.Password = userDto.Password;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateUserPartialAsync(int id, UpdateUserRequest userDto)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            //Цикл проверяет каждое свойство из запроса, сравнивает его со свойством существующего юзера.
            //Если они не равны, то обновляет значение существующего юзера на значение из запроса.
            foreach (var userProperty in user.GetType().GetProperties())
            {
                if (userProperty.Name == nameof(user.Id))
                {
                    continue;
                }

                var dtoProperty = userDto.GetType().GetProperty(userProperty.Name);
                var dtoValue = dtoProperty.GetValue(userDto);
                if (dtoValue is null)
                {
                    continue;
                }
                var userValue = userProperty.GetValue(user);
                if (!Equals(userValue, dtoValue))
                {
                    userProperty.SetValue(user, dtoValue);
                }
            }

            await context.SaveChangesAsync();
            return true;
        }
    }
}
