using AccountService.Core.Entities;
using MediatR;

namespace AccountService.Core.AccountTypeCore.Command
{
    public record CreateAccountTypeCommand(string TypeCode, string? Description) : IRequest<AccountType>;

}
