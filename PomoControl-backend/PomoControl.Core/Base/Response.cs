using System.Collections.Generic;

namespace PomoControl.Core
{
    public class Response
    {
        public List<string> SourceResponseTime { get; set; }
        public string SourceResponseAsString => SourceResponseTime != null && SourceResponseTime.Count > 0 ? string.Join('|', SourceResponseTime) : "";
        public Response(List<string> sourceResponseTime = null)
        {
            SourceResponseTime = sourceResponseTime ?? new List<string>();
        }
        public Response()
        {
            SourceResponseTime = new List<string>();
        }

        public Response AddResponseTime(string endpoint, long time)
        {
            SourceResponseTime.Add($"{endpoint}({time}ms)");
            return this;
        }

        public Response ConcatResponseTime(List<string> sourceReponseTime)
        {
            SourceResponseTime.AddRange(sourceReponseTime);
            return this;
        }
    }

    public class ResponseDTO<T> : Response
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public ResponseDTO(T data, string message, bool success, List<string> sourceResponseTime = null) : base(sourceResponseTime)
        {
            Message = message;
            Success = success;
            Data = data;
        }
        public ResponseDTO(string message, bool success, List<string> sourceResponseTime = null) : base(sourceResponseTime)
        {
            Message = message;
            Success = success;
        }
        public ResponseDTO() : base()
        { }

        public new ResponseDTO<T> AddResponseTime(string endpoint, long time)
        {
            base.AddResponseTime(endpoint, time);
            return this;
        }

        public new ResponseDTO<T> ConcatResponseTime(List<string> sourceResponseTime)
        {
            base.ConcatResponseTime(sourceResponseTime);
            return this;
        }
    }
}
