public class BankAccount
{
    // Declare variables
    public string Name { get; }
    public double Balance { get; private set; }

    // Bank Account constructor
    public BankAccount(string name, double initialBalance = 0)
    {
        Name = name;
        Balance = initialBalance;
    }
}
