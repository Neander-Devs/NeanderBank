using System;
using System.Collections.Generic;

namespace NeanderBank.Business.Models
{
    public class AccountDTO : Entity
    {
        public int OwnerId { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string Agency { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxWithDraw { get; set; }
        public decimal MaxOverdraft { get; set; }
        public decimal UsingOverdraft { get; set; }
        public bool IsActive { get; set; }
    }
}   
