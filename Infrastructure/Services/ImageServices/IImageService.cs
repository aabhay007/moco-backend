using moco_backend.Application.DTOs;

namespace moco_backend.Infrastructure.Services.ImageServices
{
    public interface IImageService
    {
        Task<ApiResponse<string>> UploadImageAsync(ImageDto dto);
        Task<ApiResponse<string>> CheckUploadLimit(string email);

        Task<ApiResponse<string>> GetImagesByUserAsync(string email);
    }
}
