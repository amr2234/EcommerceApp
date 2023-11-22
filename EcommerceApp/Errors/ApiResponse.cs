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
                400 => " Bad Request, you have made",
                401 => " Authorized , you are not",
                404 => " Resource found , it was not",
                500 => " Errors are the path to the dark side",
                _=> null
            };

        }
    }

}
