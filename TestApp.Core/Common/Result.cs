using System.Net;

namespace TestApp.Core.Common
{
    public class Result
    {
        public Result(bool isSuccessfull)
        {
            IsSuccessfull = isSuccessfull;
        }

        public Result(bool isSuccessfull, List<string> errorMessages) : this(isSuccessfull)
        {
            ErrorMessages = errorMessages;
        }

        public Result(bool isSuccessfull, List<string> errorMessages, HttpStatusCode statusCode) : this(isSuccessfull, errorMessages)
        {
            StatusCode = statusCode;
        }

        public bool IsSuccessfull { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public HttpStatusCode StatusCode { get; set; }
    }
    public class Result<T> : Result
    {
#pragma warning disable CS8618 // Non-nullable property 'Data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Result(bool isSuccessfull) : base(isSuccessfull)
#pragma warning restore CS8618 // Non-nullable property 'Data' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        {
        }
        public Result(bool isSuccessfull, T data) : base(isSuccessfull)
        {
            Data = data;
        }

        public Result(bool isSuccessfull, List<string> errorMessages) : base(isSuccessfull, errorMessages)
        {
        }
        public Result(bool isSuccessfull, List<string> errorMessages, T data) : base(isSuccessfull, errorMessages)
        {
            Data = data;
        }
        public Result(bool isSuccessfull, List<string> errorMessages, T data, HttpStatusCode statusCode = HttpStatusCode.OK) : base(isSuccessfull, errorMessages, statusCode)
        {
            Data = data;
        }
        public Result(bool isSuccessfull, List<string> errorMessages, HttpStatusCode statusCode = HttpStatusCode.OK) : base(isSuccessfull, errorMessages, statusCode)
        {
        }

        public T Data { get; set; }
    }
}
