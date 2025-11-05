using System.Net;

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

    // Desposit Money
    public void Deposit(double despositAmount)
    {
        bool validDesposit = false;
        while (!validDesposit)
        {
            // Deposit Amount can't be negative or zero
            if (despositAmount < 1)
            {
                Console.WriteLine("Desposit Amount has to be greater than zero.");
            }
            else
            {
                Balance += despositAmount;
                Console.WriteLine("You have desposited an amount of $" + despositAmount);
                Console.WriteLine("Total Bank Account Balance: $" + Balance);
                validDesposit = true;
            }
        }
    }
}
