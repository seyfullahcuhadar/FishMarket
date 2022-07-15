/*using FishMarket.Domain.Accounts;
using FishMarket.Domain.Customers;
using FishMarket.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishMarket.Infrastructure.Domain.Accounts
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        internal const string AccountsList = "Accounts";
        internal const string TransactionsList = "Transactions";
 
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Transactions)
                        .WithOne()
                        .HasForeignKey(t => t.AccountId);
        }

      
    }
}*/
