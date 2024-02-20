using System.Net;

namespace FacultySystem.Core.Bases
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {

        }
        public ResponseBase(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public ResponseBase(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public ResponseBase(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        //public Dictionary<string, List<string>> ErrorsBag { get; set; }
        public T Data { get; set; }
    }

}
