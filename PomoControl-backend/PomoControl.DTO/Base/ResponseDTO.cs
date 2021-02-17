using System;
using System.Collections.Generic;
using System.Text;

namespace PomoControl.DTO.Base
{
    public class ResponseDTO
    {
        public List<string> SourceResponseTime { get; set; }
        public string SourceResponseAsString => SourceResponseTime != null && SourceResponseTime.Count > 0 ? string.Join('|', SourceResponseTime) : "";

        public ResponseDTO(List<string> sourceResponseTime = null)
        {
            SourceResponseTime = sourceResponseTime ?? new List<string>();
        }

        public ResponseDTO()
        {
            SourceResponseTime = new List<string>();
        }

        public ResponseDTO AddResponseTime(string endpoint, long time)
        {
            AddResponseTime(endpoint, time);
            return this;
        }
        public ResponseDTO ConcatResponseTime(List<string> sourceResponseTime)
        {
            SourceResponseTime.AddRange(sourceResponseTime);
            return this;
        }
    }

    public class ResponseDTO<T> : ResponseDTO
    {
        public T Data { get; set; }
        public ResponseDTO(T data, List<string> sourceResponseTime = null) : base(sourceResponseTime)
        {
            Data = data;
        }
        public ResponseDTO(List<string> sourceResponseTime = null) : base(sourceResponseTime)
        {

        }
        public ResponseDTO() : base()
        {

        }

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
