using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1.UI
{
    public class ConsoleUI : IUI
    {
        public string Header { get; set; }

        public ConsoleUI(string appTitle, string header)
        {
            Console.Title = appTitle;
            Header = header;
        }

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public void DisplayHeader(string title)
        {
            Console.Clear();
            Console.WriteLine($"{Header}\n");
            Console.WriteLine($"{title}\n");
        }

        public void DisplayMenu(Menu menu)
        {
            DisplayHeader(menu.Title);

            foreach (var item in menu.Items)
            {
                Console.WriteLine($"{item.Key}. {item.Title}");
            }

            Console.Write($"\n{menu.Prompt}: ");

            string? input = Console.ReadLine();

            MenuItem? menuItem = menu.Items.Where(item => string.Equals(item.Key, input, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (menuItem != null)
            {
                menuItem.Action();
            }

            DisplayMenu(menu);
        }

        public void ListVehicles(IVehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                Console.WriteLine($"{i + 1}.\n{vehicles[i]}\n" + "\n----------------------------------------\n");
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string PromptForText(string prompt, int minLength = 1, int maxLength = int.MaxValue)
        {
            string? input;
            bool valid;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine();
                valid = input != null && input.Length >= minLength && input.Length <= maxLength;
            } while (!valid);

            return input!;
        }

        public int PromptForIntegerNumber(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int number;
            bool parsed;
            do
            {
                Console.Write($"{prompt}: ");
                string? input = Console.ReadLine();
                parsed = int.TryParse(input, out number) && number >= min && number <= max;

            } while (!parsed);

            return number;
        }

        public double PromptForDecimalNumber(string prompt)
        {
            double number;
            bool parsed;
            do
            {
                Console.Write($"{prompt}: ");
                string? input = Console.ReadLine();
                parsed = double.TryParse(input, out number);

            } while (!parsed);

            return number;
        }

        public string PromptForOption(string prompt, string[] options)
        {
            string? option;
            bool valid;
            do
            {
                Console.Write($"{prompt}: ");
                option = Console.ReadLine();
                valid = option != null && options.Any(opt => opt.Equals(option, StringComparison.OrdinalIgnoreCase));
            } while (!valid);

            return option!;
        }

        public char PromptForAnyKey(string prompt)
        {
            Console.Write(prompt);
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar;
        }
    }
}
