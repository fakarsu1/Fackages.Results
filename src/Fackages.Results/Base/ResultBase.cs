using System.Text.Json.Serialization;

namespace Fackages.Results.Base
{
    public class ResultBase : IResult
    {
        public ResultBase(bool isSuccess, int code, string message, int httpStatusCode)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public bool IsSuccess { get; }
        public int Code { get; }
        public string Message { get; }

        [JsonIgnore]
        public int HttpStatusCode { get; }
    }
}