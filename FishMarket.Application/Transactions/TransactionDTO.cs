using FishMarket.Domain.Transactions;
using System;

namespace FishMarket.Application.Transactions
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; }
        public double Value { get;}
        public TransactionTypeDTO transactionType { get;}

        public TransactionDTO(Guid transactionId, double value, TransactionType transactionType)
        {
            TransactionId = transactionId;
            Value = value;
            this.transactionType = transactionType == TransactionType.DEPOSIT ? TransactionTypeDTO.DEPOSIT : TransactionTypeDTO.WITHDRAW;

        }
    }
}