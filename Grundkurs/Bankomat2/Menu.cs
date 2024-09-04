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
        AccountInfo,
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
        "Konto (ID, Saldo): ",
        "Aktuellt saldo",
        "Välj alternativ",
        "Vänligen ange ett giltigt nummer",
        "Ange belopp för uttag",
        "Belopp större än nuvarande saldo.",
        "Uttag genomfört.",
        "Ange belopp för insättning",
        $"Nytt totalbelopp överstiger kapaciteten ({decimal.MaxValue}).",
        "Insättning genomfört.",
        "Transaktionshistorik",
        "Inga transaktioner än."
    ];

    readonly BankAccount _bankAccount = bankAccount;

    void Display()
    {
        //Print balance and menu options
        // Console.WriteLine("{0}: {1} {2}",
        //     _promptText[(int)Prompt.Balance],
        //     _bankAccount.Balance,
        //     _bankAccount.Currency
        // );

        Console.WriteLine(
            _promptText[(int)Prompt.AccountInfo] +
            _bankAccount
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
        out decimal answer,
        decimal minValue,
        decimal maxValue,
        string prompt,
        string errorMessage
        )
    {
        Console.Write(prompt);
        if (
                !decimal.TryParse(Console.ReadLine(), out answer) ||
                answer < minValue ||
                answer > maxValue
            )
        {
            PaddedPrompt(errorMessage);
            return false;
        }
        return true;
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
            PaddedPrompt(errorMessage);
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
            _promptText[(int)Prompt.Error] +
            $"({1}-{(uint)Option.Exit + 1})."
            )
            )
        {
            decimal amount;
            switch (answer - 1)
            {
                case (uint)Option.Deposit:
                    if (ReadInput(
                        out amount,
                        0m,
                        decimal.MaxValue,
                        $"{_promptText[(int)Prompt.Deposit]}: ",
                        _promptText[(int)Prompt.Error] +
                        $"({0m}-{decimal.MaxValue})."
                        )
                        )
                    {
                        if (_bankAccount.Deposit(amount))
                        {
                            PaddedPrompt(_promptText[(int)Prompt.DepositSuccess]);
                        }
                        else
                        {
                            PaddedPrompt(_promptText[(int)Prompt.DepositTooMuch]);
                        }

                    }
                    break;
                case (uint)Option.Withdraw:
                    if (ReadInput(
                        out amount,
                        0m,
                        decimal.MaxValue,
                        $"{_promptText[(int)Prompt.Withdraw]}: ",
                        $"{Environment.NewLine}{_promptText[(int)Prompt.Error]}" +
                        $"({0m}-{decimal.MaxValue})."
                        )
                        )
                    {
                        if (_bankAccount.Withdraw(amount))
                        {
                            PaddedPrompt(_promptText[(int)Prompt.WithdrawSuccess]);
                        }
                        else
                        {
                            PaddedPrompt(_promptText[(int)Prompt.WithdrawNotEnoughBalance]);
                        }
                    }
                    break;
                case (uint)Option.Transactions:
                    if (_bankAccount.Transactions.Count != 0)
                    {
                        PaddedPrompt(
                        _promptText[(int)Prompt.Transactions] +
                        new string(' ', 31) +
                        "Rå belopp + Ränta" +
                        $"{Environment.NewLine}" +
                        new string('-', 115)
                        );
                        foreach (var transaction in _bankAccount.Transactions)
                        {
                            Console.WriteLine(
                                $"{transaction.Timestamp}: " +
                                $"{(transaction.IsWithdraw ? "-" : "+") + transaction.Amount,-29:F2}" +
                                (transaction.Interest > 0 ?
                                $" ({transaction.Amount - transaction.Interest:F2} + {transaction.Interest:F2})" : "")
                            );
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        PaddedPrompt(_promptText[(int)Prompt.TransactionsEmpty]);
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

    static void PaddedPrompt(string prompt)
    {
        Console.WriteLine(
            Environment.NewLine +
            prompt +
            Environment.NewLine
        );
    }
}
