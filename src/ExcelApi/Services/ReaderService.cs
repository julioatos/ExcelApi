using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using ExcelApi.Services;

namespace ExcelApi.Services
{
    public class ReaderService : IReaderService
    {
        public List<string> Readfile(IFormFile file)
        {
            List<string> resultData = new List<string>();
            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension == ".xlsx" || fileExtension == ".XLSX")
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 5;

                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        bool bandera = true;
                        int contador = 0;
                        do
                        {
                            while (reader.Read())
                            {
                                if (contador > 5 && bandera == true)
                                {
                                    var texto = reader.GetValue(0).ToString().Substring(0, 5);
                                    if (reader.GetValue(0).ToString().Substring(0, 5).Equals("Total"))
                                    {
                                        bandera = false;
                                    }
                                    else {
                                        resultData.Add(reader.GetValue(0).ToString());
                                    }
                                }
                                contador++;
                            }
                        } while (reader.NextResult());
                        resultData.ValidateSociety();
                        return resultData;
                    }
                }
            }
            return resultData;
        }
    }
}
