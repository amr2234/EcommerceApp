using EcommerceApp.Errors;

namespace EcommerceApp.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int Statuscode, string Message = null, string detials = null) : base(Statuscode, Message)
        {
            Detials = detials;
        }

        public string Detials { get; set; }
    }
}


