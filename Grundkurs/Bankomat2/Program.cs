namespace Bankomat2;

class Program
{
    static void Main()
    {
        var bankAccount = new BankAccount("AZ2345667","kr");
        var menu = new Menu(bankAccount);
        while (menu.Update())
        {
            //Run program
        }
    }
}
