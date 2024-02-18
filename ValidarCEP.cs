using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuscaCEP
{
    public class ValidarCEP
    {
        public static bool Validar(string validacao)
        {
            var regCEP = new Regex(@"^\d{8}");
            return regCEP.IsMatch(validacao);
        }
        
    }
}
