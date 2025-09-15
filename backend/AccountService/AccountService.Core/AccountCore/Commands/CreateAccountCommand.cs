using MediatR;

namespace AccountService.Core.AccountCore.Commands
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; } // A/c Name
        public string Provider { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal AvailableBalance { get; set; }

    }
}
