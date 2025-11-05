public class Menu
{
    // Define menu options
    private readonly Dictionary<int, string> _menuOptions = new()
    {
        {1, "Create Account"},
        {2, "Deposit"},
        {3, "Withdraw"},
        {4, "Check Balance"},
        {5, "Exit"}
    };

    // Display and return menu options
    public int Show()
    {
        Console.WriteLine("Welcome to Kevin's Banking!");
        foreach (var option in _menuOptions)
            Console.WriteLine($"{option.Key}: {option.Value}");

        return GetValidSelection();
    }

    // Generic get input method
    public string GetInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    // Validate numeric user inputs
    private int GetValidSelection()
    {
        while (true)
        {
            Console.Write("Please select an option: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && _menuOptions.ContainsKey(choice))
                return choice;

            Console.WriteLine("Invalid input. Try again.");
        }
    }
}
