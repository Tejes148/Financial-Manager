using MediatR;

namespace AccountService.Core.LinkedBankCore.Command
{
    public record LinkBankAccountCommand(
      Guid AccountId,
      string Provider, // Bank Name
      string? ProviderAccountId, // Bank ref Number
      string? RefreshToken,
      string? Metadata // extra field or info like servicea/c
  ) : IRequest<Guid>;
}
