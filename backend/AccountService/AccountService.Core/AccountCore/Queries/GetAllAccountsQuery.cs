using AccountService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountCore.Queries
{
    public class GetAllAccountsQuery : IRequest<IEnumerable<Account>>
    {
        public Guid UserId { get; set; }
        public GetAllAccountsQuery(Guid userId)
        {
            UserId= userId; 
        }
    }
}
