public class MenuOption
{
    public int Id { get; }
    public string Label { get; }
    public bool RequiresLogin { get; }
    public bool RequiresNoLogin { get; }

    public MenuOption(int id, string label, bool requiresLogin = false, bool requiresNoLogin = false)
    {
        Id = id;
        Label = label;
        RequiresLogin = requiresLogin;
        RequiresNoLogin = requiresNoLogin;
    }
}
