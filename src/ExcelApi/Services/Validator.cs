using System.Collections.Generic;
using System.Linq;

namespace ExcelApi.Services
{
    public static class Validator
    {
        public static bool ValidateSociety(this List<string> list)
        {
            bool sonIguales = list.Distinct().Any();
            return sonIguales;
        }

        public static bool ValidateNumbers(this List<double> list, int count)
        {
            bool sonNumeros = (list.Count == (count*9));
            return sonNumeros;
        }
    }
}
