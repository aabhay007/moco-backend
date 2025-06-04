using moco_backend.Application.DTOs;

namespace moco_backend.Infrastructure.Services.UserServices
{
    public interface IUserService
    {
        Task<ApiResponse<string>> CreateUserIfNotExistsAsync(UserDto userDto);
    }
}
