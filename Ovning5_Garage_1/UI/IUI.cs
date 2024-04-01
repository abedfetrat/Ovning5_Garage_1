using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1.UI
{
    public interface IUI
    {
        public void DisplayText(string text);

        public void DisplayHeader(string title);

        public void DisplayMenu(Menu menu);

        public void ListVehicles(IVehicle[] vehicles);

        public void Clear();

        public string PromptForText(string prompt, int minLength = 1, int maxLength = int.MaxValue);

        public int PromptForIntegerNumber(string prompt, int min = int.MinValue, int max = int.MaxValue);

        public double PromptForDecimalNumber(string prompt);

        public string PromptForOption(string prompt, string[] options);

        public char PromptForAnyKey(string prompt);

    }
}
