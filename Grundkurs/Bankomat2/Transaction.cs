namespace Bankomat2;

class Transaction(bool isWithdraw, uint amount, DateTime timestamp)
{

    public bool IsWithdraw { get; init; } = isWithdraw;
    public uint Amount { get; init; } = amount;
    public DateTime Timestamp { get; init; } = timestamp;
}
