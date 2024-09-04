namespace Bankomat2;

class BankAccount(string accountNumber, string currency)
{
    public uint Balance { get; private set; }
    public string Currency {get; init;} = currency;
    public List<Transaction> Transactions { get; private set;} = [];
    public string AccountNumber {get; init;} = accountNumber;

    public bool Deposit(uint amount)
    {
        if (Balance > uint.MaxValue - amount)
        {
            return false;
        }
        Balance += amount;
        Transactions.Add(new Transaction(false, amount, DateTime.Now));
        return true;
    }

    public bool Withdraw(uint amount){
        if (amount > Balance)
        {
            return false;
        }
        Balance -= amount;
        Transactions.Add(new Transaction(true, amount, DateTime.Now));
        return true;
    }

    public override string ToString()
    {
        return $"{AccountNumber} {Balance}";
    }
}
