namespace PomoControl.Service.DTO
{
    public class ResponseDTO
    {
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public ResponseDTO()
        { }

        public ResponseDTO(dynamic data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
