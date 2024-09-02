namespace Bankomat2;

class Menu(BankAccount bankAccount)
{
    enum Option : byte
    {
        Deposit,
        Withdraw,
        Transactions,
        Exit
    }

    enum Prompt
    {
        Balance,
        OptionInput,
        Error,
        Withdraw,
        WithdrawNotEnoughBalance,
        WithdrawSuccess,
        Deposit,
        DepositTooMuch,
        DepositSuccess,
        Transactions,
        TransactionsEmpty
    }

    static readonly string[] _optionText = [
        "Sätta in",
        "Ta ut",
        "Visa transaktioner",
        "Avsluta"
    ];

    static readonly string[] _promptText = [
        "Aktuellt saldo",
        "Välj alternativ",
        "Vänligen ange ett giltigt nummer",
        "Ange belopp för uttag",
        "Belopp större än nuvarande saldo.",
        "uttag genomfört.",
        "Ange belopp för insättning",
        $"Nytt totalbelopp överstiger kapaciteten ({uint.MaxValue}).",
        "insättning genomfört.",
        "Transaktionshistorik",
        "Inga transaktioner än"
    ];

    readonly BankAccount _bankAccount = bankAccount;

    void Display()
    {
        //Print balance and menu options
        Console.WriteLine("{0}: {1} {2}",
            _promptText[(int)Prompt.Balance],
            _bankAccount.Balance,
            _bankAccount.Currency
        );

        foreach (Option option in Enum.GetValues<Option>())
        {
            Console.WriteLine("{0}: {1}",
                (byte)option + 1,
                _optionText[(byte)option]
            );
        }
    }

    static bool ReadInput(
        out uint answer,
        uint minValue,
        uint maxValue,
        string prompt,
        string errorMessage
        )
    {
        Console.Write(prompt);
        if (
                !uint.TryParse(Console.ReadLine(), out answer) ||
                answer < minValue ||
                answer > maxValue
            )
        {
            Console.WriteLine(errorMessage);
            return false;
        }
        return true;
    }

    public bool Update()
    {
        Display();
        if (ReadInput(
            out uint answer,
            1,
            (uint)Option.Exit + 1,
            $"{_promptText[(int)Prompt.OptionInput]}: ",
            $@"{Environment.NewLine}
            {_promptText[(int)Prompt.Error]}
            ({1}-{(uint)Option.Exit + 1})."
            )
            )
        {
            uint amount;
            switch (answer - 1)
            {
                case (uint)Option.Deposit:
                    if (ReadInput(
                        out amount,
                        0,
                        uint.MaxValue,
                        $"{_promptText[(int)Prompt.Deposit]}: ",
                        $"{Environment.NewLine}{_promptText[(int)Prompt.Error]}" +
                        $"({0}-{uint.MaxValue})."
                        )
                        )
                    {
                        if (_bankAccount.Deposit(amount))
                        {
                            Console.WriteLine(_promptText[(int)Prompt.DepositSuccess]);
                        }
                        else
                        {
                            Console.WriteLine(_promptText[(int)Prompt.DepositTooMuch]);
                        }

                    }
                    else
                    {
                        Console.WriteLine(_promptText[(int)Prompt.Error]);
                    }
                    break;
                case (uint)Option.Withdraw:
                    if (ReadInput(
                        out amount,
                        0,
                        uint.MaxValue,
                        $"{_promptText[(int)Prompt.Withdraw]}: ",
                        $"{Environment.NewLine}{_promptText[(int)Prompt.Error]}" +
                        $"({0}-{uint.MaxValue})."
                        )
                        )
                    {
                        if (_bankAccount.Withdraw(amount))
                        {
                            Console.WriteLine(_promptText[(int)Prompt.WithdrawSuccess]);
                        }
                        else
                        {
                            Console.WriteLine(_promptText[(int)Prompt.WithdrawNotEnoughBalance]);
                        }
                    }
                    else
                    {
                        Console.WriteLine(_promptText[(int)Prompt.Error]);
                    }
                    break;
                case (uint)Option.Transactions:
                    Console.WriteLine(
                        $"{Environment.NewLine}{_promptText[(int)Prompt.Transactions]}"
                        );
                    if (_bankAccount.Transactions.Count != 0)
                    {
                        foreach (var transaction in _bankAccount.Transactions)
                        {
                            Console.WriteLine(
                                $"{transaction.Timestamp}: " +
                                $"{(transaction.IsWithdraw ? "-" : "+")}" +
                                transaction.Amount.ToString()
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine(_promptText[(int)Prompt.TransactionsEmpty]);
                    }
                    break;
                case (uint)Option.Exit:
                    return false;
                default:
                    return true;
            }
        }
        return true;
    }
}
