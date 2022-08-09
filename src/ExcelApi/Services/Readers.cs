using ExcelDataReader;
using System.Collections.Generic;
using System.IO;

namespace ExcelApi.Services
{
    public static class Readers
    {
        public static List<string> LeerPrimerColumna(this MemoryStream stream) {
            List<string> resultData = new List<string>();
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
                            var texto = reader.GetValue(0).ToString(). Substring(0, 5);
                            if (reader.GetValue(0).ToString().Substring(0, 5).Equals("Total"))
                            {
                                bandera = false;
                            }
                            else
                            {
                                resultData.Add(reader.GetValue(1).ToString());
                            }
                        }
                        contador++;
                    }
                } while (reader.NextResult());
                resultData.ValidateSociety();
                return resultData;
            }
        }

        public static List<string> LeerPagoProveedores(this MemoryStream stream,int count)
        {
            count++;
            List<string> resultData = new List<string>();
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                int contador = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (contador > 5)
                        {
                                resultData.Add(reader.GetValue(1).ToString());
                        }
                        contador++;
                    }
                } while (reader.NextResult());
                resultData.ValidateSociety();
                return resultData;
            }
        }
    }
}
