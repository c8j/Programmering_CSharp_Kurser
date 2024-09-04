namespace Bankomat2;

class Program
{
    static void Main()
    {
        var bankAccount = new BankAccount("AZ2345667","kr", 0.02m);
        var menu = new Menu(bankAccount);
        while (menu.Update())
        {
            //Run program
        }
    }
}
