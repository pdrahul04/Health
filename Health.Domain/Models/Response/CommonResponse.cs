using Health.Domain.Models.Validator;
using System.Net;

namespace Health.Domain.Models.Response
{
    public class CommonResponse
    {
        public List<ValidationError> Errors { get; set; }
        public string Details { get; set; }
        public string RequestId { get; set; }
        public int StatusCode { get; set; }
        public bool Successful { get; set; }
        public string Message { get; set; }
        public string MessageCode { get; set; } = "000000";
        public object Data { get; set; }
        public CommonResponse()
        {
        }

        public CommonResponse(HttpStatusCode httpStatus, string message, bool successful, object data = null, string status = "")
        {
            StatusCode = (int)httpStatus;
            Message = message;
            MessageCode = status;
            Successful = successful;
            Data = data;
        }

        public CommonResponse(HttpStatusCode httpStatus, string message, string status = "")
        {
            StatusCode = (int)httpStatus;
            Message = message;
            MessageCode = status;
            Successful = true;
        }

        public CommonResponse(string message, bool successful, string details, string status = "")
        {
            Message = message;
            MessageCode = status;
            Successful = successful;
            Details = details;
        }

        public static CommonResponse CreateSuccessResponse(HttpStatusCode httpStatus, string message = "", object data = null, string status = "")
        {
            return new CommonResponse(httpStatus, message, successful: true, data, status);
        }

        public static CommonResponse CreateSuccessResponse(HttpStatusCode httpStatus, string message = "", string status = "")
        {
            return new CommonResponse(httpStatus, message, status);
        }

        public static CommonResponse CreateFailedResponse(HttpStatusCode httpStatus, string message = "", string status = "")
        {
            return new CommonResponse(httpStatus, message, successful: false, null, status);
        }

        public static CommonResponse CreateErrorWithDetailsResponse(string message = "", string details = "", string status = "")
        {
            return new CommonResponse(message, successful: false, details, status);
        }
    }
}
