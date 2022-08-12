using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using ExcelApi.Services;
using System.Data;
using System;

namespace ExcelApi.Services
{
    public class ResponseExcelService : IResponseExcelService
    {
        public Tuple<bool, string> ResponseExcelfile(IFormFile file)
        {
            bool esValido=false;
            string fileExtension = Path.GetExtension(file.FileName);
            List<string> listaSociedad;
            string errores = "";

            if (fileExtension == ".xlsx" || fileExtension == ".XLSX")
            {
                DataSet dsexcelRecords = new();
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    using var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    dsexcelRecords = reader.AsDataSet();
                }
                listaSociedad = dsexcelRecords.LeerPrimerColumna();
                bool validadSociedad = listaSociedad.ValidateSociety();
                bool validaNumeros = dsexcelRecords.LeerNumeros(listaSociedad.Count);
                esValido = (validadSociedad == true && validaNumeros == true);
                if (!esValido)
                {
                    errores += listaSociedad.GetSocietyErrors();
                    errores += dsexcelRecords.GetNumbersErrors(listaSociedad.Count);
                }
            }
            Tuple<bool, string> result = new(esValido, errores);
            return result;
        }
    }
}
