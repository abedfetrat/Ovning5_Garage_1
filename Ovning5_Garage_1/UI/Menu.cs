namespace Ovning5_Garage_1.UI
{
    public class Menu
    {
        public Menu(string title, string prompt, MenuItem[] items)
        {
            Title = title;
            Prompt = prompt;
            Items = items;
        }

        public string Title { get; }

        public string Prompt { get; }

        public MenuItem[] Items { get; }
    }
}
