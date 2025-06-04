namespace moco_backend.Application.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
        public List<string>? Errors { get; set; }

        public static ApiResponse<T> SuccessResponse(
            T data,
            string? message = null,
            int statusCode = 200
        )
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = statusCode,
                Message = message,
                Result = data,
            };
        }

        public static ApiResponse<T> FailResponse(
            List<string> errors,
            string? message = null,
            int statusCode = 400
        )
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
                Errors = errors,
                Result = default,
            };
        }
    }
}
