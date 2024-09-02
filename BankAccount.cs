namespace Bankomat2;

class BankAccount(string currency)
{
    public uint Balance { get; private set; }
    public string Currency {get; init;} = currency;
    public List<Transaction> Transactions { get; private set;} = [];

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
}
