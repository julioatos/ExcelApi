using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ExcelApi.Services
{
    public interface IReaderService
    {
        public bool Readfile(IFormFile file);
    }
}
