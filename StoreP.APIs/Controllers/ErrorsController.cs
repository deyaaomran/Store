using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreP.APIs.Errors;

namespace StoreP.APIs.Controllers
{
    [Route("error/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Errors(int code)
        {
            return NotFound(new ApiErrorResponse(StatusCodes.Status404NotFound,"Not Found End Point !"));
        }
    }
}
