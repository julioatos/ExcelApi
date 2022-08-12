using System.Collections.Generic;
using System.Linq;

namespace ExcelApi.Services
{
    public static class Validator
    {
        public static bool ValidateSociety(this List<string> list)
        {
            bool sonDistintos = (list.Distinct().ToList().Count>1);
            if (sonDistintos)
            {
                return false;
            }
            else
                return true;
        }

        public static bool ValidateNumbers(this List<double> list, int count,int columnas){
            bool sonNumeros = (list.Count == count*columnas);
            return sonNumeros;
        }
    }
}
