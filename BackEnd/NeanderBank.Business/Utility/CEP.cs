using NeanderBank.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Utility
{
    public static class CEP
    {
        /// <summary>
        ///  Removes spaces and signs from given CEP.
        /// </summary>
        /// <param name="cep">The string containing the CEP to be trimmed.</param>
        /// <returns>The trimmed CEP</returns>
        public static string Trim(string cep)
        {
            return cep.Trim().Replace("-", "");
        }

        /// <summary>
        /// Verify if CEP is valid, checking it's content and length.
        /// </summary>
        /// <param name="cep">The string containing the CEP to be verified.</param>
        /// <returns>True if is valid, false if not</returns>
        public static bool isValid(string cep)
        {
            if (cep.Count(c => c.Equals('-')) > 1)
                return false;

            string _cep = Trim(cep);

            if (_cep.Length != 8)
                return false;
            
            if (!_cep.All(d => char.IsNumber(d))) 
                return false;

            return true;
        }
    }
}
