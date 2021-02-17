using System.Collections.Generic;

namespace PomoControll.Model
{
    public class Response
    {
        public List<string> SourceResponseTime { get; set; }
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

    public class Response<T> : Response
    {
        public T Data { get; set; }
        public Response(T data, List<string> sourceResponseTime = null) : base(sourceResponseTime)
        {
            Data = data;
        }
        public Response(List<string> sourceResponseTime = null) : base(sourceResponseTime)
        {

        }
        public Response() : base()
        {

        }

        public new Response<T> AddResponseTime(string endpoint, long time)
        {
            base.AddResponseTime(endpoint, time);
            return this;
        }

        public new Response<T> ConcatResponseTime(List<string> sourceResponseTime)
        {
            base.ConcatResponseTime(sourceResponseTime);
            return this;
        }
    }
}
