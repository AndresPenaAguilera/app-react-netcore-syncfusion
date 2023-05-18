namespace Interfaces.API
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiResponse<T> CreateSuccessResponse(T data)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data
            };
        }

        public static ApiResponse<T> CreateErrorResponse(string errorMessage)
        {
            return new ApiResponse<T>
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
