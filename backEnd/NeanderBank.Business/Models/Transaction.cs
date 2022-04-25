using System;
using static NeanderBank.Business.Enums.TransactionTypes;

namespace NeanderBank.Business.Models
{
    public class Transaction : Entity
    {
        public decimal Value { get; set; }
        public DateTime TransferDate { get; set; }
        public TransactionType Type { get; set; }
        public int? SenderAccountId { get; set; }
        public virtual Account SenderAccount { get; set; }
        public int? ReceiverAccountId { get; set; }
        public virtual Account ReceiverAccount { get; set; }
        public decimal Balance { get; set; }
    }
}   
