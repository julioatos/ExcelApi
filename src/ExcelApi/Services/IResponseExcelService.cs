using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace ExcelApi.Services
{
    public interface IResponseExcelService
    {
        public Tuple<bool,string> ResponseExcelfile(IFormFile file);
    }
}
