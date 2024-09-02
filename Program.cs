namespace Bankomat2;

class Program
{
    static void Main()
    {
        var bankAccount = new BankAccount("kr");
        var menu = new Menu(bankAccount);
        while (menu.Update())
        {
            //Run program
        }
    }
}
