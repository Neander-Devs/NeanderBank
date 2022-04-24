using System;
using System.Collections.Generic;

namespace NeanderBank.Business.Models
{
    public class Account : Entity
    {
        public int OwnerId { get; set; }
        public virtual Costumer Owner { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string Agency { get; set; }
        public decimal Balance { get; set; } //Saldo
        public decimal MaxWithDraw { get; set; } //Saque máximo
        public decimal MaxOverdraft { get; set; } //Cheque especial máximo
        public decimal UsingOverdraft { get; set; } //Cheque especial em uso

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}   
