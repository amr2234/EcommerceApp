using EcommerceApp.Errors;
using EcommerceClasslib.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class BuggyController :BaseApiController
    {
        private readonly EContext _context;

        public BuggyController(EContext context)
        {
            

            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetnotfoundRequest()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult Getservererror()
        {
            var thing = _context.Products.Find(50);
            var thingOnreturn = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult Getbadrequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetbadRequestbyId(int id)
        {
            return Ok();
        }
    }
}
