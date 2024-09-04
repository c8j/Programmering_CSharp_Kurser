namespace Bankomat2;

class Transaction(bool isWithdraw, decimal amount, DateTime timestamp, decimal interest)
{

    public bool IsWithdraw { get; init; } = isWithdraw;
    public decimal Amount { get; init; } = amount + interest;
    public decimal Interest {get; init;} = interest;
    public DateTime Timestamp { get; init; } = timestamp;
}
