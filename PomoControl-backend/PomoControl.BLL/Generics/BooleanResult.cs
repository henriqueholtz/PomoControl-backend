namespace PomoControl.BLL.Generics
{
    public abstract class BooleanResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public BooleanResult() { }

        public BooleanResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

    public class GenericResult : BooleanResult
    {
        public object Data { get; set; }

        public GenericResult() { }

        public GenericResult(bool success, string message) : base(success, message) { }
        public GenericResult(bool success, string message, object data) : base(success, message)
        {
            Data = data;
        }
    }
}
