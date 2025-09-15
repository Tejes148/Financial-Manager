using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountCore.Commands
{
    public class UpdateAccountCommand : IRequest<bool>
    {
        public string AccountType { get; set; }
        public string Name { get; set; } // A/c Name
        public char[] Currency { get; set; }
        public string Provider { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}
