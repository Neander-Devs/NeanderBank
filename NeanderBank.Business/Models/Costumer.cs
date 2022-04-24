using System;
using System.Collections.Generic;

namespace NeanderBank.Business.Models
{
    public class Costumer : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Neighboorhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}   
