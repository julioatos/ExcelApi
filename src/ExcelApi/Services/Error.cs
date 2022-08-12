using System;
using System.Collections.Generic;
using System.Data;

namespace ExcelApi.Services
{
    public static class Error
    {
        public static string GetSocietyErrors(this List<string> list)
        {
            string errores = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0] != list[i])
                {
                    errores += $"\nError de nombre en la Columna A Fila {i + 6}\n";
                }
            }
            return errores;
        }

        public static string GetNumbersErrors(this DataSet dataset, int count)
        {
            string errores = "";

            List<double> resultData = new();
            int[] columnas = new int[] { 10, 11, 12, 13, 14, 15, 20, 21, 22 };
            int fila;
            int columna;
            for (int j = 0; j < columnas.Length; j++)
            {
                columna = columnas[j];
                for (int i = 5; i < count + 5; i++)
                {
                    fila = i + 1;
                    try
                    {
                        resultData.Add(double.Parse(dataset.Tables[0].Rows[i][columnas[j]].ToString()));
                    }
                    catch (Exception)
                    {
                        errores += $"\nError de valor en la Columna {Convert.ToChar(columna + 65)} Fila {fila}\n";
                    }
                }
            }

            return errores;
        }
    }
}
