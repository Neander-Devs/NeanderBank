using NeanderBank.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Utility
{
    public static class CPF
    {
        /// <summary>
        ///  Removes spaces and signs from given CPF.
        /// </summary>
        /// <param name="cpf">The string containing the CPF to be trimmed.</param>
        /// <returns>The trimmed CPF</returns>
        public static string Trim(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }

        /// <summary>
        /// Verify if CPF is valid, checking it's content, length and verification digit.
        /// </summary>
        /// <param name="cpf">The string containing the CPF to be verified.</param>
        /// <returns>True if is valid, false if not</returns>
        public static bool isValid(string cpf)
        {
            if (cpf.Count(c => c.Equals('.')) > 2 || cpf.Count(c => c.Equals('-')) > 1)
                return false;

            cpf = Trim(cpf);

            if (cpf.Length != 11)
                return false;
            
            if (!cpf.All(d => char.IsNumber(d))) 
                return false;

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum = 0;
            int rest = 0;

            tempCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }
    }
}
