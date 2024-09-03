using System.Diagnostics;

namespace Bankomat;

class Program
{
    private enum Options : byte
    {
        Deposit,
        Withdraw,
        Exit
    }

    private enum Prompts
    {
        Balance,
        OptionInput,
        Error,
        Withdraw,
        WithdrawNotEnoughBalance,
        WithdrawSuccess,
        Deposit,
        DepositTooMuch,
        DepositSuccess
    }

    private static readonly string currency = "kr";
    /* private static readonly string[] optionText = [
        "Deposit",
        "Withdraw",
        "Exit"
    ]; */
    private static readonly string[] optionText = [
        "Sätta in",
        "Ta ut",
        "Avsluta"
    ];
    /* private static readonly string[] promptText = [
        "Current balance",
        "Choose option",
        "Please insert a valid number",
        "Enter amount to withdraw (" + currency + ")",
        "Amount greater than current balance.",
        "withdrawn successfully.",
        "Enter amount to deposit (" + currency + ")",
        "New total amount exceeds capacity (" +
            uint.MaxValue + " " + currency + ").",
        "deposited successfully."
    ]; */
    private static readonly string[] promptText = [
        "Aktuellt saldo",
        "Välj alternativ",
        "Vänligen ange ett giltigt nummer",
        "Ange belopp för uttag (" + currency + ")",
        "Belopp större än nuvarande saldo.",
        "uttag genomfört.",
        "Ange belopp för insättning (" + currency + ")",
        "Nytt totalbelopp överstiger kapaciteten (" +
            uint.MaxValue + " " + currency + ").",
        "insättning genomfört."
    ];
    private static uint balance;

    static void Main(string[] args)
    {
        bool exitTriggered = false;
        balance = 1000;
        uint minValue, maxValue;

        while (!exitTriggered)
        {

            //Print menu
            PrintPrompt();

            //Read menu choice
            minValue = 1;
            maxValue = (uint)Options.Exit + 1;
            ReadInput(
                out uint answer,
                minValue,
                maxValue,
                promptText[(int)Prompts.OptionInput] + ": ",
                GetErrorPrompt(minValue, maxValue)
            );

            //Process choice
            bool isWithdrawing = false;
            switch (answer - 1)
            {
                case (uint)Options.Deposit:
                    isWithdrawing = false;
                    break;
                case (uint)Options.Withdraw:
                    isWithdrawing = true;
                    break;
                case (uint)Options.Exit:
                    exitTriggered = true;
                    break;
                default:
                    Debug.WriteLine("Something went wrong...");
                    break;
            }

            //Handle withdraw/deposit
            if (!exitTriggered)
            {
                string amountPrompt =
                isWithdrawing
                ?
                promptText[(int)Prompts.Withdraw] + ": "
                :
                promptText[(int)Prompts.Deposit] + ": ";

                //Get amount from input
                minValue = 0;
                maxValue = uint.MaxValue;
                ReadInput(
                    out uint amount,
                    minValue,
                    maxValue,
                    amountPrompt,
                    GetErrorPrompt(minValue, maxValue)
                );

                //Process amount
                if (isWithdrawing)
                {
                    if (amount > balance)
                    {
                        Console.WriteLine(
                            '\n' +
                            promptText[(int)Prompts.WithdrawNotEnoughBalance]
                        );
                    }
                    else
                    {
                        balance -= amount;
                        Console.WriteLine(
                            '\n' +
                            amount.ToString() + " " +
                            currency + " " +
                            promptText[(int)Prompts.WithdrawSuccess]
                        );
                    }
                }
                else
                {
                    if (balance > uint.MaxValue - amount)
                    {
                        Console.WriteLine(
                            '\n' +
                            promptText[(int)Prompts.DepositTooMuch]
                        );
                    }
                    else
                    {
                        balance += amount;
                        Console.WriteLine(
                            '\n' +
                            amount.ToString() + " " +
                            currency + " " +
                            promptText[(int)Prompts.DepositSuccess]
                        );
                    }
                }
            }
            Console.Write('\n');
        }
    }

    private static void PrintPrompt()
    {
        //Print balance and menu options
        Console.WriteLine(
            promptText[(int)Prompts.Balance] + ": " + balance +
            ' ' + currency
        );
        foreach (Options option in Enum.GetValues<Options>())
        {
            Console.WriteLine(
                (byte)option + 1 + ": " + optionText[(byte)option]
            );
        }
    }

    private static void ReadInput(
        out uint answer,
        uint minValue,
        uint maxValue,
        string prompt,
        string errorMessage
        )
    {
        bool isValid = false;
        answer = 0;
        while (!isValid)
        {
            Console.Write(prompt);
            if (
                uint.TryParse(Console.ReadLine(), out answer) &&
                answer >= minValue &&
                answer <= maxValue
            )
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine(errorMessage + '\n');
                PrintPrompt();
            }
        }
    }

    private static string GetErrorPrompt(uint minValue, uint maxValue)
    {
        return '\n' + promptText[(int)Prompts.Error] +
            " (" + minValue + "-" + maxValue + ").";
    }

}
