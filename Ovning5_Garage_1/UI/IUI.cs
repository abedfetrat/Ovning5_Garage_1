using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.UI
{
    public interface IUI
    {
        public void DisplayText(string text, bool inline = false);

        public void DisplayText(string text);

        public void Clear();

        public string PromptForText(string prompt, int minLength = 1, int maxLength = int.MaxValue);

        public int PromptForIntegerNumber(string prompt, int min = int.MinValue, int max = int.MaxValue);

        public double PromptForDecimalNumber(string prompt);

        public string PromptForOption(string prompt, string[] options);

        public bool PromptForYesOrNoOption(string prompt);

        public bool PromptForAnyKey(string prompt);

    }
}
