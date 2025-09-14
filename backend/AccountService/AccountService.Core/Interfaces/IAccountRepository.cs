using AccountService.Core.Entities;

namespace AccountService.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Guid> AddAccountAsync(Account account, CancellationToken cancellationToken);
        Task<Guid> UpdateAccountAsync(Account account, CancellationToken cancellationToken);
        Task<Guid> DeleteAccountAsync(Guid AccountNumber, CancellationToken cancellationToken);
        Task<Account> GetAccountByAccountIdAsync(Guid AccountNumber, CancellationToken cancellationToken);
    }
}
