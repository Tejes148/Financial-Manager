using AccountService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountTypeCore.Command
{
    public record UpdateAccountTypeCommand(string TypeCode, string? Description) : IRequest<AccountType>;
}
