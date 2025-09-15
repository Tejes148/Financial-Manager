using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountService.Core.AccountCore.Commands
{
    public class CloseAccountCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public CloseAccountCommand(string name)
        {
            Name = name;
        }
    }
}
