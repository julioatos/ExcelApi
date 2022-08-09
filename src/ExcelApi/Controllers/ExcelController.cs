using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;
using ExcelApi.Services;

namespace ExcelApi.Controllers
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ExcelController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public ActionResult HelloWorld()
        {
            return Ok("Hola Mundo");
        }

        //resolver async
        [HttpPost]
        public ActionResult ReadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Content("No se envio un archivo");
            }
            else
                _readerService.Readfile(file);
            return Ok();
        }
    }
}

