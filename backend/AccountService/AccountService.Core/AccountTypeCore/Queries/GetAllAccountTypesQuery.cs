using AccountService.Core.Entities;
using MediatR;

namespace AccountService.Core.AccountTypeCore.Queries
{
    public record GetAllAccountTypesQuery : IRequest<IEnumerable<AccountType>>;
}
