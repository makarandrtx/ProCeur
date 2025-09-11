namespace ProCeur.API.Shared.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response() { }

        public Response(T data, string message = "")
        {
            Succeeded = true;
            StatusCode = 200;
            Message = message;
            Data = data;
        }

        public Response(string message, int statusCode)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = message;
        }

        public Response(string message, bool succeeded, int statusCode)
        {
            Succeeded = succeeded;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
