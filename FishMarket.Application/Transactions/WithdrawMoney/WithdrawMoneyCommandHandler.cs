using FishMarket.Application.Configuration.Commands;
using System;


namespace FishMarket.Application.Transactions.WithdrawMoney
{
    public class WithdrawMoneyCommandHandler
    {
       /* private readonly IAccountRepository accountRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IUnitOfWork unitOfWork;

        public WithdrawMoneyCommandHandler(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            IUnitOfWork unitOfWork)
        {
            this.accountRepository = accountRepository;
            this.transactionRepository = transactionRepository;

            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var account =await accountRepository.GetAccountAsync(request.AccountId);
            var transaction = account.WithDrawMoney(request.Value);
            var result = await transactionRepository.AddTransactionAsync(transaction);  
            await this.unitOfWork.CommitAsync(cancellationToken);
            return result;
        }*/
    }
}
