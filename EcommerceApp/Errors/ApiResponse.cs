namespace EcommerceApp.Errors
{
    public class ApiResponse
    {
        
        public ApiResponse(int Statuscode , string  Message=null)
        {
            StatusCode = Statuscode ;
            ErrorMessage = Message ?? GetDefaultMassage(Statuscode);
            
        }

     

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        private string GetDefaultMassage(int statuscode)
        {
            return statuscode switch
            {
                400 => " You have made Bad Request",
                401 => " you are not Authorized ",
                404 => " Resource Not found ",
                500 => " Server Error",
                _ => null
            }; ;

        }
    }

}
