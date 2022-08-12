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
        private readonly IResponseExcelService _readerService;

        public ExcelController(IResponseExcelService readerService)
        {
            _readerService = readerService;
        }

        [HttpPost]
        public async Task<IActionResult> AnalizeFile(IFormFile file)
        {
            bool valido;
            if (file == null || file.Length == 0)
            {
                return Content("No se envio un archivo");
            }
            else
                valido=_readerService.ResponseExcelfile(file).Item1;
            if (!valido)
                return BadRequest($"El archivo no cumplio con las carcaterisitcas\n{_readerService.ResponseExcelfile(file).Item2}");
            else
                return Ok("La hoja de calculo cumple con los requerimientos");
        }
    }
}

