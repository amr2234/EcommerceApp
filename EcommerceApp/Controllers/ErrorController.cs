using EcommerceApp.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
