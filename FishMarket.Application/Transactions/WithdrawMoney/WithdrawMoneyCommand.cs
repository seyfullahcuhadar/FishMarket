using FishMarket.Application.Configuration.Commands;
using System;

namespace FishMarket.Application.Transactions.WithdrawMoney
{
    public class WithdrawMoneyCommand : CommandBase<Guid>
    {

        public Guid AccountId { get; }
        public double Value { get;}

        public WithdrawMoneyCommand(Guid accountId,double value)
        {
            AccountId = accountId;
            this.Value = value;
        }

    }
}
