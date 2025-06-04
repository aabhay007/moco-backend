using Microsoft.EntityFrameworkCore;
using moco_backend.Application.DTOs;
using moco_backend.Domain.Entities;
using moco_backend.Infrastructure.Data;

namespace moco_backend.Infrastructure.Services.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly NeonDbContext _context;
        public ImageService(NeonDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<string>> CheckUploadLimit(string email)
        {
            var result = await ValidateUserAndUploadLimit(email);
            return result.StatusCode == 200
                ? ApiResponse<string>.SuccessResponse("You can upload images", "Uploads available", 200)
                : result;
        }

        public async Task<ApiResponse<string>> UploadImageAsync(ImageDto dto)
        {
            var validationResult = await ValidateUserAndUploadLimit(dto.Email);
            if (validationResult.StatusCode != 200)
                return validationResult;

            var image = new ImageLibrary
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                ImageLink = dto.ImageLink,
                CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
            };

            _context.ImageLibraries.Add(image);
            await _context.SaveChangesAsync();

            return ApiResponse<string>.SuccessResponse(
                "Image uploaded successfully.",
                "Upload successful",
                200
            );
        }

        // Shared validation method
        private async Task<ApiResponse<string>> ValidateUserAndUploadLimit(string email)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == email);
            if (!userExists)
            {
                return ApiResponse<string>.FailResponse(
                    new List<string> { "User does not exist." },
                    "Operation failed",
                    404
                );
            }

            var now = DateTime.UtcNow;
            var today = DateTime.SpecifyKind(now.Date, DateTimeKind.Unspecified);
            var tomorrow = DateTime.SpecifyKind(now.Date.AddDays(1), DateTimeKind.Unspecified);

            var imageCount = await _context.ImageLibraries
                .Where(img =>
                    img.Email == email &&
                    img.CreatedAt.HasValue &&
                    img.CreatedAt.Value >= today &&
                    img.CreatedAt.Value < tomorrow)
                .CountAsync();

            if (imageCount >= 20)
            {
                return ApiResponse<string>.FailResponse(
                    new List<string> { "You have reached the daily upload limit of 20 images." },
                    "Daily limit reached",
                    429
                );
            }

            return ApiResponse<string>.SuccessResponse("Validation passed", null, 200);
        }
    }
}
