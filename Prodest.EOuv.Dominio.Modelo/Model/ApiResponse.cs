namespace Prodest.EOuv.Dominio.Modelo
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(ApiResponse<object> errorResponse)
        {
            StatusCode = errorResponse.StatusCode;
            Message = errorResponse.Message;
        }
    }
}