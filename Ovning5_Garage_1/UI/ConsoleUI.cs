using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.UI
{
    public class ConsoleUI
    {
        public ConsoleUI(string appTitle)
        {
            Console.Title = appTitle;
        }

        public void DisplayText(string text, bool inline = false)
        {
            if (inline)
                Console.Write(text);
            else
                Console.WriteLine(text);

        }

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
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

            return input;
        }

        public int PromptForIntegerNumber(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int number;
            bool valid;
            do
            {
                Console.Write($"{prompt}: ");
                string? input = Console.ReadLine();
                valid = int.TryParse(input, out number) && number >= min && number <= max;

            } while (!valid);

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

            return option;
        }

        public bool PromptForYesOrNoOption(string prompt)
        {
            string[] options = ["y", "n", "yes", "no"];
            string option = PromptForOption(prompt, options);
            return option == "y" || option == "yes";
        }

        public bool PromptForAnyKey(string prompt)
        {
            Console.Write(prompt);
            Console.ReadLine();
            return true;
        }
    }
}
