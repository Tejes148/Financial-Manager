using AccountService.Core.Entities;

namespace AccountService.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Guid> AddAccountAsync(Account account, CancellationToken cancellationToken);
        Task<Guid> UpdateAccountAsync(Account account, CancellationToken cancellationToken);
        Task<bool> DeleteAccountAsync(string AccountNumber, CancellationToken cancellationToken);
        Task<Account> GetAccountByAccountNumberAsync(string AccountNumber, CancellationToken cancellationToken);
        Task<IEnumerable<Account>> GetAllAccountsAsync(Guid userId, CancellationToken cancellation);
    }
}
