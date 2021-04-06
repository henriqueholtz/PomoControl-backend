using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PomoControl.Core.Exceptions
{
    public class PomoControlException : Exception
    {
        private string _message;
        private string _stackTrace;
        public List<string> SourceResponseTime { get; set; }
        public int StatusCode { get; }
        public PomoControlException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            SourceResponseTime = new List<string>();
            _message = message;
            StatusCode = (int)statusCode;
        }
        public PomoControlException(Exception innerException)
        {
            SourceResponseTime = new List<string>();
            _message = innerException.Message;
            _stackTrace = innerException.StackTrace;
            StatusCode = 500;
        }
        public PomoControlException AddResponseTime(string endpoint, long time)
        {
            SourceResponseTime.Add($"{endpoint}({time}ms)");
            return this;
        }

        public PomoControlException ConcatResponseTime(List<string> sourceResponseTime)
        {
            SourceResponseTime.AddRange(sourceResponseTime);
            return this;
        }
        public string SourceResponseAsString => string.Join('|', SourceResponseTime);
        public override string Message => _message;
        public override string StackTrace => _message ?? base.StackTrace;

        public override string ToString()
        {
            var obj = new
            {
                message = _message,
                stackTrace = StackTrace,
                source = Source
            };

            return JsonConvert.SerializeObject(obj);
        }
    }
}
