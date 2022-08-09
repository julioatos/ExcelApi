using System.Collections.Generic;
using System.Linq;

namespace ExcelApi.Services
{
    public static class Validator
    {
        public static bool ValidateSociety(this List<string> list)
        {
            bool sonIguales = list.Distinct().Count()>0;
            return sonIguales;
        }
    }
}
