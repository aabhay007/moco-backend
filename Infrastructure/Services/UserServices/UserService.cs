using Microsoft.EntityFrameworkCore;
using moco_backend.Application.DTOs;
using moco_backend.Domain.Entities;
using moco_backend.Infrastructure.Data;

namespace moco_backend.Infrastructure.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly NeonDbContext _context;

        public UserService(NeonDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<string>> CreateUserIfNotExistsAsync(UserDto userDto)
        {
            var existingUser = await _context.Users
           .FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (existingUser != null)
            {
                return ApiResponse<string>.SuccessResponse(
               "User Already Existed!",
               "User Existed",
               409
              );
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                DisplayName = userDto.DisplayName,
                CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

             return ApiResponse<string>.SuccessResponse(
                "User created successfully.",
                "User Created",
                200
            );
        }
    }
}
