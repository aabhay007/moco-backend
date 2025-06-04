using moco_backend.Application.DTOs;

namespace moco_backend.Infrastructure.Services.ImageServices
{
    public interface IImageService
    {
        Task<ApiResponse<string>> UploadImageAsync(ImageDto dto);
    }
}
