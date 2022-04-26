using NeanderBank.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Utility
{
    public static class AccountNumber
    {
        /// <summary>
        ///  Removes spaces and signs from given account number.
        /// </summary>
        /// <param name="account">The string containing the account number to be trimmed.</param>
        /// <returns>The trimmed account number</returns>
        public static string Trim(string account)
        {
            return account.Trim().Replace("-", "");
        }

        /// <summary>
        /// Verify if account number is valid, checking it's content, length and verification digit.
        /// </summary>
        /// <param name="account">The string containing the account number to be verified.</param>
        /// <returns>True if is valid, false if not</returns>
        public static bool isValid(string account)
        {
            if (account.Count(c => c.Equals('-')) > 1)
                return false;

            string _account = Trim(account);

            if (_account.Length != 9)
                return false;
            
            if (!_account.All(d => char.IsNumber(d))) 
                return false;

            return true;
        }
    }
}
