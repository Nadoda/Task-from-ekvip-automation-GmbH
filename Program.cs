using Task_from_ekvip_automation_GmbH.ArithmeticCommand;
using Task_from_ekvip_automation_GmbH.Interface;

internal class Program
{
    static void Main(string[] args)
    {
        double result = PromptInitialValue();

        while (true)
        {
            Stack<ICommand> history = new Stack<ICommand>();

            Console.WriteLine($"\nCurrent starting value: {result}");
            Console.WriteLine("Enter a sequence of commands (comma-separated): Commands like,: increment, decrement, double, randadd, undo");

            string inputLine = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrEmpty(inputLine)) continue;

            string[] commands = inputLine.Split(',');

            foreach (string rawCommand in commands)
            {
                string commandInput = rawCommand.Trim();
                if (string.IsNullOrEmpty(commandInput)) continue;

                // make a command variable null in order to set a new command
                ICommand command = null;

                switch (commandInput)
                {
                    case "increment":
                        command = new IncrementCommand();
                        break;
                    case "decrement":
                        command = new DecrementCommand();
                        break;
                    case "double":
                        command = new DoubleCommand();
                        break;
                    case "randadd":
                        command = new RandAddCommand();
                        break;
                    case "undo":
                        if (history.Count > 0)
                        {
                            // last command from a history collection
                            ICommand lastCommand = history.Pop();
                            // undo process execution for the last command
                            result = lastCommand.Undo(result);
                            Console.WriteLine("Result after undo: " + result);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to undo.");
                        }
                        continue;
                    default:
                        Console.WriteLine($"Unknown command: {commandInput}");
                        continue;
                }

                result = command.Execute(result);
                history.Push(command);
                Console.WriteLine($"Result after '{commandInput}': {result}");
            }

            // Ask user what to do next
            Console.WriteLine("\nWhat would you like to do next?");
            Console.WriteLine("1 - Continue with last value");
            Console.WriteLine("2 - Start over with a new value");
            Console.WriteLine("3 - Exit");

            string choice = Console.ReadLine()?.Trim();
            switch (choice)
            {
                case "1":
                    continue; // Loop again with same result
                case "2":
                    result = PromptInitialValue();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Continuing with current result.");
                    break;
            }
        }
    }

    static double PromptInitialValue()
    {
        double result;
        while (true)
        {
            Console.Write("Enter initial value: ");
            string input = Console.ReadLine()?.Trim();

            if (double.TryParse(input, out result))
                return result;

            Console.WriteLine("Invalid input. Please enter a valid value.");
        }
    }
}


