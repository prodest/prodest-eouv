namespace Prodest.EOuv.Dominio.Modelo.Common
{
    public class ApiResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponseModel()
        {
        }

        public ApiResponseModel(ApiResponseModel<object> errorResponse)
        {
            StatusCode = errorResponse.StatusCode;
            Message = errorResponse.Message;
        }
    }
}