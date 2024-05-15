namespace MediTech .Errors
{
    public class ApiExceptionError : ApiErrorResponse
    {
        public string? Details { get; set; }
        public ApiExceptionError(int statuscode , string? message=null , string?  details=null ):base(statuscode , message)
        {
            this.Details = details;

        }

    }
}
