using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelApi.Controllers
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        [HttpGet]
        public ActionResult HelloWorld()
        {
            return Ok("Hola Mundo");
        }
    }
}
