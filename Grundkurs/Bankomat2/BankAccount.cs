namespace Bankomat2;

class BankAccount(string accountNumber, string currency, decimal interestRate)
{
    public decimal Balance { get; private set; } = 0;
    private readonly decimal _interestRate = interestRate;
    public string Currency { get; init; } = currency;
    public List<Transaction> Transactions { get; private set; } = [];
    public string AccountNumber { get; init; } = accountNumber;

    public bool Deposit(decimal amount)
    {
        if (Balance > decimal.MaxValue - amount)
        {
            return false;
        }
        decimal interest = 0;
        if (Balance >= 1000m)
        {
            interest = Balance * _interestRate;
            if (Balance > decimal.MaxValue - amount - interest)
            {
                return false;
            }
        }
        Balance += amount + interest;
        Transactions.Add(new Transaction(false, amount, DateTime.Now, interest));
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            return false;
        }
        Balance -= amount;
        Transactions.Add(new Transaction(true, amount, DateTime.Now, 0));
        return true;
    }

    public override string ToString()
    {
        return $"{AccountNumber} {Balance:F2}";
    }
}
