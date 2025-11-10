public enum AccountType
{
    Generic = 1,
    Savings = 2,
    Checking = 3
}

public static class AccountFactory
{
    public static BankAccount Create(AccountType type, int id, string name, int passcode)
    {
        return type switch
        {
            AccountType.Generic => new BankAccount(id, name, passcode),
            AccountType.Savings => new SavingsAccount(id, name, passcode),
            AccountType.Checking => new CheckingsAccount(id, name, passcode),
            _ => throw new ArgumentException("Invalid account type")
        };
    }
}