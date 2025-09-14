namespace AccountService.Core.Entities;

public partial class AccountType
{
    public string TypeCode { get; set; } = null!;

    public string? Description { get; set; }
}
