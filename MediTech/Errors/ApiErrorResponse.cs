namespace MediTech.Errors
{
    public class ApiErrorResponse
    {
        public int ErrorCode {  get; set; }

        public string? ErrorMessage { get; set; }

        public ApiErrorResponse(int errorcode , string? message = null)
        {
            this.ErrorCode = errorcode; 
            this.ErrorMessage = message ?? getErrorMessage(errorcode);
        }

        private string ? getErrorMessage(int errorcode)
        {
            switch (errorcode)
            {
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unauthorized";
                case 403:
                    return "Forbidden";
                case 404:
                    return "Not Found";
                case 500:
                    return "Internal Server Error";
                default:
                    return null;
            }
        } 


    }
}
