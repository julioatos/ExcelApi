using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using ExcelApi.Services;

namespace ExcelApi.Services
{
    public class ReaderService : IReaderService
    {
        public void Readfile(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension == ".xlsx" || fileExtension == ".XLSX")
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 5;
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    var lista = stream.LeerPrimerColumna();
                    var listan = stream.LeerPagoProveedores(lista.Count);
                }
            }
        }
    }
}
