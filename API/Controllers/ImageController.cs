using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moco_backend.Application.DTOs;
using moco_backend.Infrastructure.Services.ImageServices;

namespace moco_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromBody] ImageDto dto)
        {
            var result = await _imageService.UploadImageAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

    }
}
