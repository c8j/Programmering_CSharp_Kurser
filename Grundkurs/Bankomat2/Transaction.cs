namespace Bankomat2;

class Transaction(bool isWithdraw, decimal amount, DateTime timestamp)
{

    public bool IsWithdraw { get; init; } = isWithdraw;
    public decimal Amount { get; init; } = amount;
    public DateTime Timestamp { get; init; } = timestamp;
}
