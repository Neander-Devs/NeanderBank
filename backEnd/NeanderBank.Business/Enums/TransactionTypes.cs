using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeanderBank.Business.Enums
{
    public class TransactionTypes
    {
        public enum TransactionType
        {
            DOC = 1,
            TED = 2,
            TEF = 3,
            PIX = 4,
            BankingBillet = 5, //Boleto
            WithDraw = 6, //Saque
            Deposit = 7
        }
    }
}
