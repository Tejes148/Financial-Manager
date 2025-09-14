using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountCore.Commands
{
    public record UpdateAccountCommand(
        Guid AccountId,
        string AccountTypeCode,
        decimal Balance
    ) : IRequest<bool>;
}
