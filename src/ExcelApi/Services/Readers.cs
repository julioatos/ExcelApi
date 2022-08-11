using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ExcelApi.Services
{
    public static class Readers
    {
        public static List<string> LeerPrimerColumna(this DataSet dataset)
        {
            List<string> resultData = new List<string>();
            resultData = dataset.
                Tables[0].
                AsEnumerable().
                Select(r => r.Field<string>("Column0")).
                Where(r => r != null && !r.StartsWith("Total")).
                Skip(4).ToList();
            return resultData;
        }

        public static bool LeerNumeros(this DataSet dataset, int count)
        {
            List<double> resultData = new List<double>();
            int[] columnas = new int[] { 10,11,12,13,14,15,20,21,22 };
           //                            0   1   2  
            for (int i = 5; i < count + 5; i++)
            {
                try
                {
                    for (int j = 0; j < columnas.Length; j++)
                    {
                        
                        resultData.Add(double.Parse(dataset.Tables[0].Rows[i][columnas[j]].ToString()));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return resultData.ValidateNumbers(count);
        }
    }
}
