

class Menu
{
    public static void Main()
    {
        var menuOptions = InitializeMenu();
        DisplayMenu(menuOptions);
        ValidUserInput(menuOptions);
    }

    private static Dictionary<int, string> InitializeMenu()
    {
        return new Dictionary<int, string>
        {
            {1, "Create Account"},
            {2, "Deposit"},
            {3, "Withdraw"},
            {4, "Check Balance"},
            {5, "Exit"}
        };
    }

    private static void DisplayMenu(Dictionary<int, string> menuOptions)
    {
        // Display options to user
        Console.WriteLine("Welcome to Kevin's Banking!");
        foreach (var option in menuOptions)
        {
            Console.WriteLine($"{option.Key}: {option.Value}");
        }
    }

    private static void ValidUserInput(Dictionary<int, string> menuOptions)
    {
        // Loop until user inputs a valid number
        bool validInput = false;
        bool existsInMenuOptions = false;
        int menuOptionSelected = 0;
        while (!validInput && !existsInMenuOptions)
        {
            // Prompt for user input
            Console.WriteLine("Please select an option:");
            string? userInput = Console.ReadLine();

            // check if input is a number
            if (int.TryParse(userInput, out menuOptionSelected))
            {
                menuOptionSelected = int.Parse(userInput);
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            // check if input exists in menu options
            foreach (var menuOption in menuOptions)
            {
                if (menuOption.Key == menuOptionSelected)
                {
                    existsInMenuOptions = true;
                    // user input checks out - assign the menu option selected id
                    Console.WriteLine("You have selected menu option: " + menuOption.Value);
                    break;
                }
            }
        }
    }
}