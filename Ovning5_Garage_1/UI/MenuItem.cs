namespace Ovning5_Garage_1.UI
{
    public class MenuItem
    {
        public MenuItem(string title, string key, Action action)
        {
            Title = title;
            Key = key;
            Action = action;
        }

        public string Title { get; }

        public string Key { get; }

        public Action Action { get; }
    }
}
