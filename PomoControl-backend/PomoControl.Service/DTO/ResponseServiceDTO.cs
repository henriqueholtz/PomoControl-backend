namespace PomoControl.Service.DTO
{
    public class ResponseServiceDTO
    {
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public ResponseServiceDTO()
        { }

        public ResponseServiceDTO(int statusCode, dynamic data, string message, bool success)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            Success = success;
        }
    }

    public class ResonseWithTokenDTO : ResponseServiceDTO
    {
        public string AccessToken { get; set; }

        public ResonseWithTokenDTO(int statusCode, dynamic data, string accessToken, string message, bool success)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            Success = success;
            AccessToken = accessToken;
        }
    }
}
