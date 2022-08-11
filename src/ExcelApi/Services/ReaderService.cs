using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using ExcelApi.Services;
using System.Data;

namespace ExcelApi.Services
{
    public class ReaderService : IReaderService
    {
        public void Readfile(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension == ".xlsx" || fileExtension == ".XLSX")
            {
                DataSet dsexcelRecords = new DataSet();
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        dsexcelRecords = reader.AsDataSet();
                    }
                }
                var listaSociedad=dsexcelRecords.LeerPrimerColumna();
                bool validadSociedad, validaNumeros;
                validadSociedad = listaSociedad.ValidateSociety();
                validaNumeros=dsexcelRecords.LeerNumeros(listaSociedad.Count);
                //var lista = stream.LeerPrimerColumna();
                //var listan = stream.LeerPagoProveedores(lista.Count);
            }
        }
    }
}
