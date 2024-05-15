namespace MediTech.Errors
{
    public class ApiValditionError:ApiErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValditionError():base(400)
        {
            Errors = new List<string>();
        }
    }
}
